using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Shoot : MonoBehaviour
{

    
    private RaycastHit hit;
    private int enemyLayer = 1 << 9;
    private float distance=0;
    private int wallLayer = 1 << 10;
    private List<AudioSource> sounds = new List<AudioSource>();
    private AudioManager audioManager;
    public GameObject MainCamera;
    public static int firerate = 0;
    private int gunFirerate = 0;
    private int CurrentWeapon = ChangeWeapon.ChosenWeapon;
    private int ammo;
    private int maxAmmo;
    private PlayerUI pUI;
    public GameObject UI;
    float timer;
    private bool reloading = false; // Is the player reloading?
    private float reloadTimer = 1.1f; // Reload Timer
    public Text text;
    //private GameObject saveGameController;
    private TimeScript timeManager;

    private void Start()
    {
        if(GameObject.Find("Timer"))
        {
            timeManager = GameObject.Find("Timer").GetComponent<TimeScript>();
        }
        //saveGameController = GameObject.Find("SaveGameController");
        pUI = UI.GetComponent<PlayerUI>();
        audioManager = GameObject.Find("AudioManager").GetComponent<AudioManager>();
        for(int i = 15; i<19; i++)
        {
            sounds.Add(audioManager.sounds[i].source);
        }

    }
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.R) && reloading==false && timer==0)
        {
            int remain = gameObject.GetComponentInChildren<GunStats>().remainammunition;
            ammo = gameObject.GetComponentInChildren<GunStats>().ammunitionAmount;
            maxAmmo = gameObject.GetComponentInChildren<GunStats>().maxAmmunition;
            if ( ((maxAmmo == ammo) || ( remain<=0 ) )|| (ChangeWeapon.ChosenWeapon==3))
            {
                //Debug.Log("cant reload");
            }
            else
            {
                reloading = true;
                PlayReloadSound();
          
            }

        }

        if (reloading )
        {
            Reload();
        }

        if (firerate > 0)
        {
            firerate--;
        }

        if (Input.GetKey(KeyCode.Mouse0) &&(reloading==false))
        {
            ////Debug.Log($"{firerate}");
            if (firerate == 0)
            {
                gunFirerate = gameObject.GetComponentInChildren<GunStats>().firerate;
                firerate = gunFirerate;
                           
                    ammo = gameObject.GetComponentInChildren<GunStats>().ammunitionAmount;
                    maxAmmo = gameObject.GetComponentInChildren<GunStats>().remainammunition;



                if (ammo == 0)
                {
                    FindObjectOfType<AudioManager>().PlaySound("EmptyGun");
                    return;
                }
                else
                {
                    _Shoot();
                    ammo = gameObject.GetComponentInChildren<GunStats>().ammunitionAmount;
                    maxAmmo = gameObject.GetComponentInChildren<GunStats>().remainammunition;
                    pUI.ChangeAmmo(ammo, maxAmmo);
                }

            }
        }
        if (CurrentWeapon != ChangeWeapon.ChosenWeapon)
        {
            //StopAllCoroutines();
            gunFirerate = 0;
            firerate = 0;
            CurrentWeapon = ChangeWeapon.ChosenWeapon;
        }
    }
    void _Shoot()
    {
        sounds[ChangeWeapon.ChosenWeapon].PlayOneShot(sounds[ChangeWeapon.ChosenWeapon].clip);
        Physics.Raycast(MainCamera.transform.position, MainCamera.transform.forward, out hit, 160, wallLayer);
        //Debug.DrawRay(MainCamera.transform.position, MainCamera.transform.forward * 160, Color.red,25);
        distance = hit.distance;
        ////Debug.Log($"Shot with dist: {distance}");
        if (Physics.Raycast(MainCamera.transform.position, MainCamera.transform.forward, out hit, 160, enemyLayer))
        {
            ////Debug.Log($"Shot enemy at dist:{hit.distance}");
            if (distance > hit.distance || distance == 0)
            {
                CharacterStats characterStats = hit.transform.gameObject.GetComponentInParent<CharacterStats>();
                ////Debug.Log(characterStats.remainingHealth);
                if (characterStats != null && characterStats.isBox==false)
                {
                    HealthBar bar = hit.transform.gameObject.GetComponentInParent<HealthBar>();               
                    TakeDamage(characterStats, gameObject.GetComponentInChildren<GunStats>().gunDamage);
                    bar.ChangeHealth(characterStats.remainingHealth, characterStats.maxHealth);
                }
                else
                {
                    TakeDamage(characterStats, gameObject.GetComponentInChildren<GunStats>().gunDamage);
                    FindObjectOfType<AudioManager>().PlaySound("box-shoot");
                }
            }
        }
        gameObject.GetComponentInChildren<GunStats>().ammunitionAmount -= 1;
        if (ChangeWeapon.ChosenWeapon == 3)
        {

          if (gameObject.GetComponentInChildren<GunStats>().remainammunition == 0)
            {
                gameObject.GetComponentInChildren<GunStats>().ammunitionAmount = 0;
            }
            else
            {
                gameObject.GetComponentInChildren<GunStats>().remainammunition -= 1;
                gameObject.GetComponentInChildren<GunStats>().ammunitionAmount = 1;
            }
          
          
  
        }
    }

    void TakeDamage(CharacterStats characterStats,float gunDamage)
    {

        if (characterStats.remainingHealth > 0)
        {   
            characterStats.remainingHealth -= gunDamage;
        }

        if (characterStats.remainingHealth <= 0 && characterStats.isBoss)
        {
            foreach (var item in dontdestroyonload.GetDestroyDontDestroys)
            {
                if (item.gm != null)
                {
                    SceneManager.MoveGameObjectToScene(item.gm, SceneManager.GetActiveScene());
                }
                else
                {
                    //Debug.Log("?????");
                }
            }

            dontdestroyonload.GetDestroyDontDestroys.Clear();
            SceneManager.LoadScene(7);
        }
        else if (characterStats.remainingHealth <= 0 && characterStats.isBox==false)
        {
            characterStats.gameObject.SetActive(false);
            ScoreManager.score += characterStats.points;
            FindObjectOfType<AudioManager>().PlaySound(characterStats.sound);
            text.text = (int.Parse(text.text) - 1).ToString();
            //if(int.Parse(text.text) == 0 && timeManager.currentTime == 0)
            //{
            //    saveGameController.GetComponent<SaveGame>().GameSave(1);
            //}
        }
        else if (characterStats.remainingHealth <= 0 && characterStats.isBox == true)
        {
            Destroy(characterStats.gameObject);
            FindObjectOfType<AudioManager>().PlaySound("box-break");
            ScoreManager.score += 50;
        }
    }

    public void Reload()
    {
        timer += Time.fixedDeltaTime;
        if (timer > reloadTimer)
        {

            int max = gameObject.GetComponentInChildren<GunStats>().maxAmmunition;
            int remain = gameObject.GetComponentInChildren<GunStats>().remainammunition;
            int current =gameObject.GetComponentInChildren<GunStats>().ammunitionAmount;

            int fired = max - current;
            int check = remain - fired;

            gameObject.GetComponentInChildren<GunStats>().remainammunition = check;
            if (remain+current >= max)
            {
                remain = max;
                gameObject.GetComponentInChildren<GunStats>().ammunitionAmount = max;
            }
            else
            {
                gameObject.GetComponentInChildren<GunStats>().ammunitionAmount = remain+current;
                remain += current;
                check = 0;
                gameObject.GetComponentInChildren<GunStats>().remainammunition = check;
            }

            pUI.ChangeAmmo(remain, check);
            reloading = false;
            timer = 0;
        }
    }

    public void PlayReloadSound()
    {
        if (ChangeWeapon.ChosenWeapon == 0)
        {
            FindObjectOfType<AudioManager>().PlaySound("beretta_reload");
        }
        else if (ChangeWeapon.ChosenWeapon == 1)
        {
            FindObjectOfType<AudioManager>().PlaySound("reload");
        }
        else if (ChangeWeapon.ChosenWeapon == 2)
        {
            FindObjectOfType<AudioManager>().PlaySound("Uzi-Reload");
        }
    }
    //IEnumerator ShootCooldown()
    //{
    //    for (int i = 0; i < gunFirerate; i++)
    //    {
    //        //Debug.Log(firerate);
    //        firerate--;
    //        yield return null;
    //    }
    //}
}
