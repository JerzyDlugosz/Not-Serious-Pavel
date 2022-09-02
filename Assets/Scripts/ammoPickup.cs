using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ammoPickup : MonoBehaviour
{
    public GameObject Player;
    private CharacterStats pUI;
    private PlayerUI UI;
    private int ammoPickupAmmount;

    void Start()
    {
        Player = GameObject.Find("Player");
        pUI = Player.GetComponent<CharacterStats>();
        UI = GameObject.FindGameObjectWithTag("UI").GetComponent<PlayerUI>();
    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {

        if ((other.tag == "Player") && (gameObject.CompareTag("UziAmmo")))
        {
            GunStats uzi = GameObject.Find("UziTest").GetComponent<GunStats>();
            ammoPickupAmmount = uzi.maxAmmunition;
            uzi.remainammunition += ammoPickupAmmount;
            FindObjectOfType<AudioManager>().PlaySound("ammopickup");
            UI.changeTriggerText($"Amunicja Uzi +{ammoPickupAmmount}", Color.white);
            if (ChangeWeapon.ChosenWeapon == 2)
            {
                UI.ChangeAmmo(uzi.ammunitionAmount, uzi.remainammunition);
            }
            Destroy(gameObject);
        }

        if ((other.tag == "Player") && (gameObject.CompareTag("ShotgunAmmo")))
        {
            GunStats shotgun = GameObject.Find("Shotgun").GetComponent<GunStats>();
            ammoPickupAmmount = shotgun.maxAmmunition;
            shotgun.remainammunition += ammoPickupAmmount;
            FindObjectOfType<AudioManager>().PlaySound("ammopickup");
            UI.changeTriggerText($"Amunicja Shotgun +{ammoPickupAmmount}", Color.white);
            if (ChangeWeapon.ChosenWeapon == 1)
            {
                UI.ChangeAmmo(shotgun.ammunitionAmount, shotgun.remainammunition);
            }
            Destroy(gameObject);
        }

        if ((other.tag == "Player") && (gameObject.CompareTag("RocketAmmo")))
        {
            GunStats rocket = GameObject.Find("RocketLauncher").GetComponent<GunStats>();
            ammoPickupAmmount = 4;
            if (rocket.ammunitionAmount == 0)
            {
                rocket.remainammunition += ammoPickupAmmount-1;
                rocket.ammunitionAmount = 1;
                if (ChangeWeapon.ChosenWeapon == 3)
                {
                    UI.ChangeAmmo(rocket.ammunitionAmount, rocket.remainammunition);
                }

            }
            else
            {
                rocket.remainammunition += ammoPickupAmmount;
                if (ChangeWeapon.ChosenWeapon == 3)
                {
                    UI.ChangeAmmo(rocket.ammunitionAmount, rocket.remainammunition);
                }
            }

            FindObjectOfType<AudioManager>().PlaySound("ammopickup");
            UI.changeTriggerText($"Amunicja Bazzoka +{ammoPickupAmmount}", Color.white);
            Destroy(gameObject);
        }
    }
}
