using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeath : MonoBehaviour
{

    private CharacterStats player;
    public GameObject menu;
    public GameObject opcje;
    public GameObject resume;
    public GameObject blood;
    public GameObject text;
    public PauseController pauseController;

    private void Start()
    {
        player = GameObject.Find("Player").GetComponent<CharacterStats>();
    }

    // Update is called once per frame
    void Update()
    {
        if(player.remainingHealth <= 0)
        {
            pauseController.PauseGame();
            menu.SetActive(true);
            opcje.SetActive(false);
            resume.SetActive(false);
            blood.SetActive(true);
            text.SetActive(true);
        }
    }
}
