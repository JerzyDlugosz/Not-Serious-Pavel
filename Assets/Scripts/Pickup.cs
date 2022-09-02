using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pickup : MonoBehaviour
{
    public GameObject Player;
    private CharacterStats pUI;
    public Text text;
    private float plusHP;
    private float hpAfterPickup;
    private PlayerUI UI;
    public int points;
    void Start()
    {
        Player = GameObject.Find("Player");
        text = GameObject.Find("currentHP").GetComponent<Text>();
        pUI = Player.GetComponent<CharacterStats>();
        plusHP = pUI.PickupHP;
        UI = GameObject.FindGameObjectWithTag("UI").GetComponent<PlayerUI>();


    }
    private void OnTriggerEnter(Collider other)
    {


        if ((other.tag == "Player") && !(gameObject.CompareTag("ExtraPoints")))
        {
            hpAfterPickup = pUI.remainingHealth + plusHP;
            FindObjectOfType<AudioManager>().PlaySound("pickup");
            text.text = hpAfterPickup.ToString();
            pUI.remainingHealth += plusHP;
            UI.changeTriggerText($"+{plusHP}",Color.red);
            Destroy(gameObject);
        }

        if ((other.tag == "Player") && (gameObject.CompareTag("ExtraPoints")))
        {
            ScoreManager.score += points;
            FindObjectOfType<AudioManager>().PlaySound("pickup");
            UI.changeTriggerText($"+{points} punktów", Color.green);
            Destroy(gameObject);
        }

    }
   
}
