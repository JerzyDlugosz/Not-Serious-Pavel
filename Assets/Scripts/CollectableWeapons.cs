using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectableWeapons : MonoBehaviour
{
    public GameObject CollectableUzi, ShotgunCollect, RocketCollect;
    public GameObject UI;
    private PlayerUI pUI;
    void Start()
    {
        UI = GameObject.Find("UI");
        pUI = UI.GetComponent<PlayerUI>();
    }
    private void OnTriggerEnter(Collider other)
    {

        if ((other.tag == "Player") && (gameObject.CompareTag("Uzii")))
        {
            GameObject.Find("UziTest").GetComponent<GunStats>().newGun = true;
            GameObject.Find("UziTest").GetComponent<GunStats>().isCollected = true;
            pUI.changeTriggerText("Uzi",Color.white);
            pUI.StartCoroutine("NewGunToFalse");
            FindObjectOfType<AudioManager>().PlaySound("gun-pickup");
            CollectableUzi.SetActive(false);
        }

        if ((other.tag == "Player") && (gameObject.CompareTag("Shotgun")))
        {
            GameObject.Find("Shotgun").GetComponent<GunStats>().newGun = true;
            GameObject.Find("Shotgun").GetComponent<GunStats>().isCollected = true;
            pUI.changeTriggerText("Shotgun",Color.white);
            pUI.StartCoroutine("NewGunToFalse");
            FindObjectOfType<AudioManager>().PlaySound("gun-pickup");
            ShotgunCollect.SetActive(false);
        }

        if ((other.tag == "Player") && (gameObject.CompareTag("RocketLauncher")))
        {
            if (GameObject.Find("Level").GetComponent<level>().levelNumber == 1)
            {
                GameObject.Find("RocketLauncher").GetComponent<GunStats>().newGun = true;
                GameObject.Find("RocketLauncher").GetComponent<GunStats>().isCollected = true;
                FindObjectOfType<AudioManager>().PlaySound("BasicRock");
                pUI.changeTriggerText("Wyrzutnia rakiet!", Color.white);
                pUI.StartCoroutine("NewGunToFalse");
                RocketCollect.SetActive(false);
            }
            else
            {
                GameObject.Find("RocketLauncher").GetComponent<GunStats>().newGun = true;
                GameObject.Find("RocketLauncher").GetComponent<GunStats>().isCollected = true;
                FindObjectOfType<AudioManager>().PlaySound("BasicRock");
                pUI.changeTriggerText("Sekretna wyrzutnia rakiet!", Color.white);
                pUI.StartCoroutine("NewGunToFalse");
                RocketCollect.SetActive(false);
            }

        }
    }


}
