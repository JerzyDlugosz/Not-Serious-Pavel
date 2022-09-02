using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventDogPart2 : MonoBehaviour
{
    private PlayerUI UI;
    public static bool EventWoof;
    public GameObject Secret;
    public GameObject MainDog;
    public bool eventDone;
    public bool dontRepeat;
    public Transform position1;
    private void Start()
    {
        UI = GameObject.FindGameObjectWithTag("UI").GetComponent<PlayerUI>();

    }
    private void OnTriggerStay(Collider other)
    {
        if(other.tag=="Player")
        {
            if (!SecretDogEvent.goodPosition)
            {
                if ((GameObject.Find("Dog1").GetComponent<LiftItem>().isDone == true)
                  && (GameObject.Find("Dog2").GetComponent<LiftItem>().isDone == true)
                  && (GameObject.Find("Dog3").GetComponent<LiftItem>().isDone == true))
                {
                    MainDog.SetActive(true);
                    SecretDogEvent.goodPosition = true;
                    FindObjectOfType<AudioManager>().PlaySound("Explosion");
                    UI.changeTriggerText("Woof Woof", Color.yellow);
                    EventWoof = true;
                    MainDog.GetComponent<Rigidbody>().useGravity = false;
                    MainDog.transform.position = position1.transform.position;
                }
            }
            if (transmittedCode == "abcd")
            {
                eventDone = true;
            }
            if (eventDone && (!dontRepeat))
            {
                dontRepeat = true;
                UI.changecongratulationsText("Aktywowałeś Sekretne pomieszczenie!");
                Secret.SetActive(true);
                transmittedCode = "";
                FindObjectOfType<AudioManager>().PlaySound("applause");
                
            }
        }

    }
    public static string transmittedCode;
    public static void CheckIfGood(string checkifGood, int number)
    {
        switch (number)
        {
            case 0:
                transmittedCode += checkifGood;
                if (transmittedCode == "abcd")
                {

                }
                else
                {
                    transmittedCode = "";
                }
                break;
            case 1:
                transmittedCode = checkifGood;
                if (transmittedCode == "a")
                {

                }
                else
                {
                    transmittedCode = "";
                }
                break;
            case 2:
                transmittedCode += checkifGood;
                if (transmittedCode == "ab")
                {

                }
                else
                {
                    transmittedCode = "";
                }
                break;
            case 3:
                transmittedCode += checkifGood;
                if (transmittedCode == "abc")
                {

                }
                else
                {
                    transmittedCode = "";
                }
                break;
                default:
                break;
        }

    }
}
