using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeWeapon : MonoBehaviour
{
    public List<GameObject> Weapons;
    public List<Sprite> WeaponSprites;
    public GameObject Placeholder;
    public static int ChosenWeapon;
    public static float gunDamage;
    public static int firerate;
    public static int ChangeWeaponTime = 10;
    public Image bron;
    public GameObject UI;
    private PlayerUI pUI;
    private void Start()
    {
        ChosenWeapon = 0;
        bron = GameObject.Find("BronNaUI").GetComponent<Image>();
        Weapons[0].transform.SetParent(transform);
        Weapons[0].transform.position = gameObject.transform.position;
        Weapons[0].transform.rotation = Camera.main.transform.rotation;
        pUI = UI.GetComponent<PlayerUI>();
    }

    private void Update()
    {

        if (Input.GetKey(KeyCode.Alpha1))
        {
            ChosenWeapon = 0;
            Weapons[0].transform.SetParent(transform);
            Weapons[0].transform.position = gameObject.transform.position;
            Weapons[0].transform.rotation = Camera.main.transform.rotation;

            Weapons[1].transform.SetParent(Placeholder.transform);
            Weapons[1].transform.position = Placeholder.transform.position;
            Weapons[2].transform.SetParent(Placeholder.transform);
            Weapons[2].transform.position = Placeholder.transform.position;
            Weapons[3].transform.SetParent(Placeholder.transform);
            Weapons[3].transform.position = Placeholder.transform.position;
            bron.sprite = WeaponSprites[0];
            pUI.ChangeAmmo(gameObject.GetComponentInChildren<GunStats>().ammunitionAmount, gameObject.GetComponentInChildren<GunStats>().remainammunition);
        }
        if (Input.GetKey(KeyCode.Alpha2) && GameObject.Find("Shotgun").GetComponent<GunStats>().isCollected == true || GameObject.Find("Shotgun").GetComponent<GunStats>().newGun == true)
        {
            ChosenWeapon = 1;
            Weapons[1].transform.SetParent(transform);
            Weapons[1].transform.position = gameObject.transform.position;
            Weapons[1].transform.rotation = Camera.main.transform.rotation;
            Weapons[0].transform.SetParent(Placeholder.transform);
            Weapons[0].transform.position = Placeholder.transform.position;
            Weapons[2].transform.SetParent(Placeholder.transform);
            Weapons[2].transform.position = Placeholder.transform.position;
            Weapons[3].transform.SetParent(Placeholder.transform);
            Weapons[3].transform.position = Placeholder.transform.position;
            bron.sprite = WeaponSprites[1];
            pUI.ChangeAmmo(gameObject.GetComponentInChildren<GunStats>().ammunitionAmount, gameObject.GetComponentInChildren<GunStats>().remainammunition);
        }
        if (Input.GetKey(KeyCode.Alpha3) && GameObject.Find("UziTest").GetComponent<GunStats>().isCollected == true || GameObject.Find("UziTest").GetComponent<GunStats>().newGun == true)
        {
            //Debug.Log(GameObject.Find("UziTest").GetComponent<GunStats>().isCollected.ToString());
            ChosenWeapon = 2;
            Weapons[2].transform.SetParent(transform);  
            Weapons[2].transform.position = gameObject.transform.position;
            Weapons[2].transform.rotation = Camera.main.transform.rotation;

            Weapons[1].transform.SetParent(Placeholder.transform);
            Weapons[1].transform.position = Placeholder.transform.position;
            Weapons[0].transform.SetParent(Placeholder.transform);
            Weapons[0].transform.position = Placeholder.transform.position;
            Weapons[3].transform.SetParent(Placeholder.transform);
            Weapons[3].transform.position = Placeholder.transform.position;
            bron.sprite = WeaponSprites[2];
            pUI.ChangeAmmo(gameObject.GetComponentInChildren<GunStats>().ammunitionAmount, gameObject.GetComponentInChildren<GunStats>().remainammunition);
        }

        if (Input.GetKey(KeyCode.Alpha4) && GameObject.Find("RocketLauncher").GetComponent<GunStats>().isCollected == true || GameObject.Find("RocketLauncher").GetComponent<GunStats>().newGun == true)
        {
            ChosenWeapon = 3;
            Weapons[3].transform.SetParent(transform);
            Weapons[3].transform.position = gameObject.transform.position;
            Weapons[3].transform.rotation = Camera.main.transform.rotation;
            Weapons[1].transform.SetParent(Placeholder.transform);
            Weapons[1].transform.position = Placeholder.transform.position;
            Weapons[2].transform.SetParent(Placeholder.transform);
            Weapons[2].transform.position = Placeholder.transform.position;
            Weapons[0].transform.SetParent(Placeholder.transform);
            Weapons[0].transform.position = Placeholder.transform.position;
            bron.sprite = WeaponSprites[3];
            pUI.ChangeAmmo(gameObject.GetComponentInChildren<GunStats>().ammunitionAmount, gameObject.GetComponentInChildren<GunStats>().remainammunition);

        }
    }
}
