using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RaycastForInteracting : MonoBehaviour
{
    private GameObject nextPylon;
    private GameObject mainCamera;
    private bool keyPressed = false;
    private int pylonmask = 1 << 11;
    private GameObject waveController;
    private int pylonNumber;
    public GameObject UI;
    private PlayerUI pUI;
    private float currentTime;
    private TimeScript timeManager;

    private void Start()
    {
        UI = GameObject.Find("UI");
        pUI = UI.GetComponent<PlayerUI>();
        waveController = GameObject.Find("WaveController");
        mainCamera = GameObject.Find("MainCamera");
        pylonNumber = GetComponentInParent<PylonData>().pylonNumber;
        nextPylon = GetComponentInParent<PylonData>().nextPylon;
        timeManager = GameObject.Find("Timer").GetComponent<TimeScript>();
    }

    private void OnTriggerStay(Collider other)
    {
        if(Physics.Raycast(mainCamera.transform.position,mainCamera.transform.forward,3f,pylonmask))
        {
            if (GameObject.Find("Level").GetComponent<level>().levelNumber == 1 && timeManager.currentTime == 0)
            {
                pUI.changeTriggerText("Nacisnij E, by aktywowac generator", Color.white);
            }
            if ((GameObject.Find("Level").GetComponent<level>().levelNumber == 1) && (timeManager.currentTime != 0))
            {
                pUI.changeTriggerText("Pokonaj fale, zeby aktywowac generetor", Color.white);
            }
            if (GameObject.Find("Level").GetComponent<level>().levelNumber == 6 && timeManager.currentTime == 0)
            {
                pUI.changeTriggerText("Nacisnij E, aby zebrac klucz", Color.white);
            }
            if ((GameObject.Find("Level").GetComponent<level>().levelNumber == 6) && (timeManager.currentTime != 0))
            {
                pUI.changeTriggerText("Pokonaj fale, by zebrac klucz", Color.white);
            }
            if (GetComponentInParent<PylonData>().refreshClick == true)
            {
                keyPressed = false;
                GetComponentInParent<PylonData>().refreshClick = false;
            }
            
            if (Input.GetKey(KeyCode.E) && (keyPressed == false && timeManager.currentTime == 0))
            {

                if (GameObject.Find("Level").GetComponent<level>().levelNumber == 1)
                {
                    FindObjectOfType<AudioManager>().PlaySound("electric");
                }
                if (GameObject.Find("Level").GetComponent<level>().levelNumber == 6)
                {
                    FindObjectOfType<AudioManager>().PlaySound("door_lock");
                }
                pUI.changeTriggerText("",Color.white);
                //Debug.Log("Wave Start");
                keyPressed = true;
                GetComponentInParent<PylonData>().refreshClick = true;
                waveController.GetComponent<WaveController>().StartWave(pylonNumber);
                CheckEnemies.RefreshEnemiesCount();
                PylonCount.RefreshEnemiesCount();
                timeManager.StartCour(30f);
                nextPylon.SetActive(true);
                this.GetComponentInParent<PylonData>().gameObject.SetActive(false);
            }
        }

    }
}
