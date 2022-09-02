using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class PlayerUI : MonoBehaviour
{
    public static float timePlay;
    public Text HP, ammo,time;
    public  Text triggetext,dogEventText,congratulations,texttochange,classText;
    private GameObject player;
    public GameObject map;
    public GameObject Image1, Image2;

    void Start()
    {
        triggetext = GameObject.Find("TriggerText").GetComponent<Text>();
        timePlay = 0;
        HP = GameObject.Find("currentHP").GetComponent<Text>();
        HP.text = GameObject.Find("Player").GetComponent<CharacterStats>().remainingHealth.ToString();
        CharacterStats Player = GameObject.Find("Player").GetComponent<CharacterStats>();
        ammo = GameObject.Find("ammo").GetComponent<Text>();
        ammo.text = "20" + " / " + "Ꝏ";
        classText= GameObject.Find("Klasa").GetComponent<Text>();
        classText.text = Statics.playerClass;
        if (Statics.playerClass == "Tank")
        {
            BaseClass Tank = new Tank();
            Player.remainingHealth = Tank.health;
            Player.maxHealth = Tank.health;
            HP.text = Tank.health.ToString();

            GameObject.Find("UziTest").GetComponent<GunStats>().remainammunition += Tank.uziMaxAmmo;
            GameObject.Find("Shotgun").GetComponent<GunStats>().remainammunition += Tank.shotgunAmmoMax;
            GameObject.Find("RocketLauncher").GetComponent<GunStats>().remainammunition += Tank.rocketStartAmmo;

            GameObject.Find("Berettta").GetComponent<GunStats>().maxAmmunition += Tank.berettaMaxAmmo;
            GameObject.Find("UziTest").GetComponent<GunStats>().maxAmmunition += Tank.uziMaxAmmo;
            GameObject.Find("Shotgun").GetComponent<GunStats>().maxAmmunition += Tank.shotgunAmmoMax;

            GameObject.Find("Berettta").GetComponent<GunStats>().ammunitionAmount = Tank.berettaStartAmmo;
            GameObject.Find("UziTest").GetComponent<GunStats>().ammunitionAmount = Tank.uziStartAmmo;
            GameObject.Find("Shotgun").GetComponent<GunStats>().ammunitionAmount = Tank.shotgunStartAmmo;

            GameObject.Find("Player").GetComponent<CharacterStats>().PickupHP = Tank.pickupHP;
            ammo.text = "25" + " / " + "Ꝏ";
        }
        if (Statics.playerClass == "Sprinter")
        {
            BaseClass sprinter = new Sprinter();
            Player.remainingHealth = sprinter.health;
            Player.maxHealth = sprinter.health;
            Player.PickupHP = sprinter.pickupHP;
            HP.text = sprinter.health.ToString();

            GameObject.Find("FPSController").GetComponent<FirstPersonController>().m_WalkSpeed = sprinter.walkspeed;
            GameObject.Find("FPSController").GetComponent<FirstPersonController>().m_RunSpeed = sprinter.sprintspeed;
        }
        if (Statics.playerClass == "Connqueror")
        {

            BaseClass Connqueror = new Conqueror();
            Player.remainingHealth = Connqueror.health;
            Player.maxHealth = Connqueror.health;
            Player.PickupHP = Connqueror.pickupHP;
            HP.text = Connqueror.health.ToString();

            GameObject.Find("UziTest").GetComponent<GunStats>().gunDamage *= Connqueror.uziDamage;
            GameObject.Find("Shotgun").GetComponent<GunStats>().gunDamage *= Connqueror.shotgunDamage;
            GameObject.Find("Berettta").GetComponent<GunStats>().gunDamage *= Connqueror.berretaDamage;
            GameObject.Find("RocketLauncher").GetComponent<GunStats>().gunDamage *= Connqueror.rocketDamage;
        }

        if (Statics.difficulty == "Extreme")
        {
            Player.PickupHP = 1;
            Player.remainingHealth = 1;
            Player.maxHealth = 100; //??
            HP.text = Player.remainingHealth.ToString();
        }
    }
    public void OnLevelWasLoaded(int level)
    {
        if (level == 6)
        {
            Text text;
            text= GameObject.Find("pozostalo").GetComponent<Text>();
            text.text = "Klucze do zebrania:";
        }
        if (level == 11)
        {
            GameObject game;
            game = GameObject.Find("pozostalo");
            game.SetActive(false);
            game = GameObject.Find("EnemyCount");
            game.SetActive(false);
            game = GameObject.Find("PylonCount");
            game.SetActive(false);
            game = GameObject.Find("pozostalo (1)");
            game.SetActive(false);
            game = GameObject.Find("TimeLeft");
            game.SetActive(false);
            game = GameObject.Find("TimeLeftText");
            game.SetActive(false);
            game = GameObject.Find("TeleporterIcon");
            game.SetActive(false);
            game = GameObject.Find("TeleporterIcon");
            game.SetActive(false);
            texttochange.text = "brak mapy";
            Destroy(map);
            Image1.SetActive(false);
            Image2.SetActive(false);
            FindObjectOfType<AudioManager>().StopSound("fight-desert");
            FindObjectOfType<AudioManager>().StopSound("relax-desert");
            FindObjectOfType<AudioManager>().StopSound("relax-desert");
            FindObjectOfType<AudioManager>().StopSound("relax");


        }


    }
    void Update()
    {

        timePlay += Time.deltaTime;
        time.text = Convert.ToInt32( timePlay).ToString();
    }


    public void ChangeAmmo(int currentAmmo, int maxAmmo)
    {
    
        string MAXIMUM;
        if (ChangeWeapon.ChosenWeapon == 0)
        {
               MAXIMUM = "Ꝏ";
        }
        else
        {
            MAXIMUM = maxAmmo.ToString();
        }
        
        ammo = GameObject.Find("ammo").GetComponent<Text>();
        ammo.text = currentAmmo.ToString() + " / " + MAXIMUM;
        
    }

    public  void changeTriggerText(string message, Color color)
    {
        triggetext.color = color;
        triggetext.text = message;
        StopAllCoroutines();
        StartCoroutine("ClearText");

    }
    public void changeDogEventText(string message)
    {
        dogEventText.text = message;
        StopAllCoroutines();
        StartCoroutine("ClearTextDogEvent");
    }

    public void changecongratulationsText(string message)
    {
        congratulations.text = message;
        StartCoroutine("ClearCongratulations");
    }
    public IEnumerator ClearCongratulations()
    {
        yield return new WaitForSeconds(4);
        congratulations.text = "";
    }
    public IEnumerator ClearTextDogEvent()
    {
        yield return new WaitForSeconds(3);
        dogEventText.text = "";
    }
    public IEnumerator ClearText()
    {    
        yield return new WaitForSeconds(5);
        triggetext.text = "";
    }

    public IEnumerator NewGunToFalse()
    {
        yield return new WaitForSeconds(0.01f);
        GameObject.Find("UziTest").GetComponent<GunStats>().newGun = false;
        GameObject.Find("Shotgun").GetComponent<GunStats>().newGun = false;
        GameObject.Find("RocketLauncher").GetComponent<GunStats>().newGun = false;
    }

}
