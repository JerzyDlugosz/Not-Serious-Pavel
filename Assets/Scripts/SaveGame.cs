using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.UI;

public class SaveGame : MonoBehaviour
{
    private GameObject player;
    private Text points;
    private Transform playerTransform;
    private int pylonNumber;
    private GameObject saveText;

    private void Start()
    {
        player = GameObject.Find("Player");
        points = GameObject.Find("ScoreText").GetComponent<Text>();
        playerTransform = GameObject.Find("FPSController").transform;
        saveText = GameObject.Find("saveText");
        saveText.SetActive(false);
    }

    public void GameSave(int saveFile, int level)
    {
        pylonNumber = GameObject.FindGameObjectWithTag("Pylon").GetComponent<PylonData>().pylonNumber;
        Save save = CreateSaveGameObject(level);
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create
            (Application.persistentDataPath + $"/gamesave{saveFile}.txt");
        bf.Serialize(file, save);
        file.Close();
        StartCoroutine(TextShowCooldown(4));
        //Debug.Log($"Game Saved in {Application.persistentDataPath}/gamesave{saveFile}.txt");
    }

    Save CreateSaveGameObject(int level)
    {
        Save save = new Save();
        save.points = int.Parse(points.text);
        save.health = player.GetComponent<CharacterStats>().remainingHealth;
        save.level = level;
        save.savedPositionPosx = playerTransform.position.x;
        save.savedPositionPosy = playerTransform.position.y;
        save.savedPositionPosz = playerTransform.position.z;
        save.nextPylon = pylonNumber;
        return save;
    }

    public IEnumerator TextShowCooldown(float time)
    {
        float myTime = time;
        do
        {
            yield return new WaitForSeconds(1f);
            if (myTime == time)
            {
                saveText.SetActive(true);
                saveText.GetComponent<Text>().text = "Zapisano gre";
            }

            if (myTime > 0f)
            {
                myTime -= 1f;
            }

            if (myTime <= 0f)
            {
                saveText.SetActive(false);
            }
        } while (myTime > 0f);
    }
}

