using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AddNewHighscore : MonoBehaviour
{
    private AudioManager audioManager;
    public Text score,rank,time,empty,Thanks,Error,max,trudnosc,bonus;
    public GameObject InputField;
    public Button button;
    private string username, timePlay,rankDB;
    private int scoreDB, timeDB;
    string leveldiff, bonuss;
    int points;
    void Start()
    {
        audioManager = GameObject.Find("AudioManager").GetComponent<AudioManager>();
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Confined;

    
        timeDB = Convert.ToInt32(PlayerUI.timePlay);
        checkPoints();
        scoreDB = ScoreManager.score;
        CheckRang(scoreDB);
        bonus.text = bonus.text+" " + bonuss;
        trudnosc.text = trudnosc.text + ": "+ leveldiff;
        score.text = score.text+": " +ScoreManager.score.ToString();
        timePlay= Leaderboard.ChangeTime(timeDB.ToString());
        time.text = time.text+" " + timePlay;
        rank.text ="ranga: "+ rankDB;
        scoreDB = ScoreManager.score;
    }

    public void checkPoints()
    {
        if (Statics.difficulty == "Normal")
        {
            leveldiff = "Normal";
            bonuss = ScoreManager.score.ToString() +" + "+ "7000";
            ScoreManager.score += 7000;
        }
        if (Statics.difficulty == "Hard")
        {
            leveldiff = "Hard";
            bonuss = ScoreManager.score.ToString() + " + " + "20000";
            ScoreManager.score += 20000;
        }
        if (Statics.difficulty == "Extreme")
        {
            leveldiff = "Extreme";
            bonuss = ScoreManager.score.ToString() + " + " + "50000";
            ScoreManager.score +=50000;
        }
        if (Statics.difficulty == "Easy")
        {
            leveldiff = "Easy";
            bonuss = ScoreManager.score.ToString() + " + " + "1000";
            ScoreManager.score += 1000;

        }
    }

    public void SendNewHighscore()
    {
        max.text = "";
        Error.text = "";
        empty.text = "";
        username = InputField.GetComponent<Text>().text;
        if (string.IsNullOrWhiteSpace(username))
        {
            empty.text = "Proszę wypełnić pole";
            return;
        }
        if (username.Length > 14)
        {
            max.text = "Maksymalnie 14 liter";
            return;
        }
        button.interactable = false;
        Leaderboard.AddNewRow(username, scoreDB, timeDB, rankDB);

    }

    public void ErrorSend()
    {
        Error.text = "Wystąpił błąd, spróbuj ponownie";
        button.interactable = true;
    }

    public void Success()
    {
        Thanks.text = "Dziękujemy za przesłanie swojego wyniku! Za chwilę przeniesz się do menu";
        StartCoroutine("ChangeToMenuAfterFiveSec");
        SceneManager.MoveGameObjectToScene(GameObject.Find("UI"), SceneManager.GetActiveScene());
    }
    public void CheckRang(int points)
    {


        if (points > 30000)
        {
            rankDB = "B";
        }
        if (points > 45000)
        {
            rankDB = "A";
        }
        if (points >= 70000)
        {
            rankDB = "S";
        }
        if (points <=30000)
        {
            rankDB = "F";
        }

        rankDB = rankDB  +" ("+ Statics.difficulty +")";
    }

    public void BacktoMenu()
    {
        SceneManager.MoveGameObjectToScene(GameObject.Find("UI"), SceneManager.GetActiveScene());
        ScoreManager.score = 0;
        audioManager.ChangeSounds(0);
        SceneManager.LoadScene(0);
    }
    public IEnumerator ChangeToMenuAfterFiveSec()
    {
        yield return new WaitForSeconds(3);
        audioManager.ChangeSounds(0);
        SceneManager.LoadScene(0);
    }
}
