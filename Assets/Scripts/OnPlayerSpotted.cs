using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class OnPlayerSpotted : MonoBehaviour
{
    private NavMeshAgent navMeshAgent;
    private bool spotted;
    public Transform ParentTransform;
    private int ShootCooldown;
    private CharacterStats playerHealth;
    private float damage;
    public Text text;
    private int wallLayer = 1 << 10;
    private Animator animator;
    private AudioManager audioManager;
    private CharacterStats stats;

    private void Start()
    {
        audioManager = GameObject.Find("AudioManager").GetComponent<AudioManager>();
        navMeshAgent = gameObject.GetComponentInParent<NavMeshAgent>();
        damage = gameObject.GetComponentInParent<CharacterStats>().damage;
        GameObject test = GameObject.Find("currentHP");
        text = test.GetComponent<Text>();
        animator = ParentTransform.GetComponentInChildren<Animator>();
        if (gameObject.GetComponentInParent<CharacterStats>().isBoss == false)
        {
            animator.SetBool("seesPlayer", false);
            animator.SetBool("seenPlayer", false);
        }
        stats = this.GetComponentInParent<CharacterStats>();
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            if (gameObject.GetComponentInParent<CharacterStats>().isBoss == false)
            {
                animator.SetBool("seesPlayer", false);
            }
            if(FindObjectOfType<AudioManager>().levelMusic == 1)
            {
                FindObjectOfType<AudioManager>().ChangeVolumeToZero("fight-music");
                FindObjectOfType<AudioManager>().ChangeVolumeToMax("relax-music");
            }
            if(FindObjectOfType<AudioManager>().levelMusic == 2)
            {
                FindObjectOfType<AudioManager>().ChangeVolumeToZero("fight-desert");
                FindObjectOfType<AudioManager>().ChangeVolumeToMax("relax-desert");
            }
            //Debug.Log("Exit Trigger");
            if (spotted == true)
            {
                navMeshAgent.isStopped = false;
            }
        }
    }

    private void FixedUpdate()
    {
        if (!navMeshAgent.pathPending)
        {
            if (navMeshAgent.remainingDistance <= navMeshAgent.stoppingDistance)
            {
                if (!navMeshAgent.hasPath || navMeshAgent.velocity.sqrMagnitude == 0f)
                {
                    if (gameObject.GetComponentInParent<CharacterStats>().isBoss == false)
                    {
                        animator.SetBool("seenPlayer", false);
                    }
                }
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {   
        if (other.gameObject.name == "Player")
        {
            if (FindObjectOfType<AudioManager>().levelMusic == 1)
            {
                FindObjectOfType<AudioManager>().ChangeVolumeToMax("fight-music");
                FindObjectOfType<AudioManager>().ChangeVolumeToZero("relax-music");
            }
            if (FindObjectOfType<AudioManager>().levelMusic == 2)
            {
                FindObjectOfType<AudioManager>().ChangeVolumeToMax("fight-desert");
                FindObjectOfType<AudioManager>().ChangeVolumeToZero("relax-desert");
            }
            NavMeshHit hit;
            if (!navMeshAgent.Raycast(other.transform.position, out hit))
            {
                RaycastHit rayHit;
                Vector3 raycastDir = other.transform.position - transform.position;
                Physics.Raycast(ParentTransform.position + new Vector3(0, 0.5f, 0), raycastDir, out rayHit, Mathf.Infinity, wallLayer);
                //Debug.DrawRay(ParentTransform.position + new Vector3(0, 0.5f, 0), raycastDir, Color.red, 0.2f);
                if (rayHit.distance > hit.distance || rayHit.distance == 0)
                {
                    float random = Random.Range(1 - (hit.distance / 40), 1);
                    //Debug.Log(random);
                    
                    if (random > 0.93f)
                    {

                        if (playerHealth == null)
                        {
                            playerHealth = other.GetComponent<CharacterStats>();
                        }
                        spotted = true;

                        ParentTransform.LookAt(other.transform.position + new Vector3(0, 0, 0));

                        navMeshAgent.destination = other.transform.position;
                        if (!stats.isMelee)
                        {
                            navMeshAgent.isStopped = true;
                            if (gameObject.GetComponentInParent<CharacterStats>().isBoss == false)
                            {
                                animator.SetBool("seesPlayer", true);
                                animator.SetBool("seenPlayer", true);
                            }
                            if (ShootCooldown == 0)
                            {
                                //Debug.Log($"Enemy: {ParentTransform.name} has fired");
                                FindObjectOfType<AudioManager>().PlaySound(stats.gunSound);
                                playerHealth.remainingHealth -= damage;
                                ShootCooldown = 60;
                                text.text = playerHealth.remainingHealth.ToString();
                            }
                        }
                        else
                        {

                            animator.SetBool("seenPlayer", true);
                            if (stats.isWithinRange)
                            {
                                animator.SetBool("seesPlayer", true);
                                if (ShootCooldown == 0)
                                {
                                    //Debug.Log($"Enemy: {ParentTransform.name} has meleed");
                                    FindObjectOfType<AudioManager>().PlaySound(stats.gunSound);
                                    playerHealth.remainingHealth -= damage;
                                    ShootCooldown = 60;
                                    text.text = playerHealth.remainingHealth.ToString();
                                }
                            }
                            else
                            {
                                animator.SetBool("seesPlayer", false);
                            }
                        }
                    }
                }
                else
                {
                    if (spotted == true)
                    {
                        navMeshAgent.isStopped = false;
                        navMeshAgent.destination = other.transform.position;
                    }
                }
            }
            else
            {
                if(spotted == true)
                {
                    navMeshAgent.isStopped = false;
                    navMeshAgent.destination = other.transform.position;
                }
            }
        }
        if (ShootCooldown > 0)
        {
            ShootCooldown--;
        }
    }
}
