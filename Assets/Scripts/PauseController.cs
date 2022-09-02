using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityStandardAssets.Characters.FirstPerson;

public class PauseController : MonoBehaviour
{
    public AudioManager audioManager;
    public   bool gameIsPaused=false;
    public bool ismapVisible = false;
    public GameObject Pause;
    public GameObject Player;
    public MouseAim mouseAim;
    public GameObject ChangeWeapon;

    public GameObject Checkpoint;
    public GameObject Map;
    public GameObject position;
    public GameObject options;
    public GameObject textUI;

    public GameObject resume;
    public GameObject wczytaj;
    public GameObject wyjdz;
    public GameObject wyjdzaledobrze;
    public GameObject opcje;

    public GameObject blood;
    public GameObject bloodText;

    public bool showoptionisclicked = false;

    public void OnLevelWasLoaded(int level)
    {
        if (level == 6)
        {
            Map.GetComponentInChildren<Camera>().orthographicSize = 57.2f;
        }
        if (level == 11)
        {
            Map.GetComponentInChildren<Camera>().orthographicSize = 100.2f;
        }


    }
    private void Start()
    {
        if(audioManager == null)
        {
            audioManager = GameObject.Find("AudioManager").GetComponent<AudioManager>();
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {

            if (options.activeInHierarchy == true)
            {
                HideOptions();
            }

            if (gameIsPaused == true && Player.GetComponentInChildren<CharacterStats>().remainingHealth > 0)
            {
                ResumeGame();

            }
            else
            {
                PauseGame();
            }



        }

        if (Input.GetKeyDown(KeyCode.M))
        {
            if (ismapVisible)
            {
                HideMap();
            }
            else
            {   
                ShowMap();
            }
        }
    }

    void ShowMap()
    {
        position.SetActive(true);
        Map.SetActive(true);
        textUI.SetActive(true);
        ismapVisible = true;
    }

    void HideMap()
    {
        position.SetActive(false);
        Map.SetActive(false);
        textUI.SetActive(false);
        ismapVisible = false; 
    }

     public void PauseGame()
    {
        gameIsPaused = true;
        Cursor.lockState = CursorLockMode.Confined;
        Time.timeScale = 0f;
        Pause.SetActive(true);
        Player.GetComponent<FirstPersonController>().enabled = false;
        mouseAim.enabled = false;
        ChangeWeapon.GetComponent<ChangeWeapon>().enabled = false;
        Cursor.visible = true;
    }
    public void ResumeGame()
    {
        gameIsPaused = false;
        Time.timeScale = 1;
        Pause.SetActive(false);
        Player.GetComponent<FirstPersonController>().enabled = true;
        mouseAim.enabled = true;
        ChangeWeapon.GetComponent<ChangeWeapon>().enabled = true;
        Cursor.visible = false;
    }


    public void ShowOptions()
    {
        Pause.SetActive(false);
        options.SetActive(true); 
    }

    public void HideOptions()
    {
        Pause.SetActive(true);
        options.SetActive(false);

    }

    public void QuitGame()
    {
      Application.Quit();
    }

    public void LoadGame()
    {
        resume.SetActive(true);
        wczytaj.SetActive(true);
        wyjdz.SetActive(true);
        wyjdzaledobrze.SetActive(true);
        opcje.SetActive(true);

        blood.SetActive(false);
        bloodText.SetActive(false);
    }

    public void BackToMenu(int level)
    {
        Time.timeScale = 1;
        foreach (var item in dontdestroyonload.GetDestroyDontDestroys)
        {
            if (item.gm != null)
            {
                SceneManager.MoveGameObjectToScene(item.gm, SceneManager.GetActiveScene());
            }
            else
            {
                ////Debug.Log("?????");
            }
        }

        dontdestroyonload.GetDestroyDontDestroys.Clear();
     //   dontdestroyonload.DontDestroyStrings.Clear();

        audioManager.ChangeSounds(level);
        SceneManager.LoadScene("MainMenu");
    }


}

