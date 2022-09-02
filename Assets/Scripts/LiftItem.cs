using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiftItem : MonoBehaviour
{
    private PlayerUI UI;
    public GameObject item;
    private Transform guide;
    public bool isCarrying;
    public bool isDone;
    public int number;
    private GameObject MainCamera;
    private GameObject parent;
    private GameObject parentDog;
    public string soundName;
    public string letter;
    private bool clicked;
    void Start()
    {
        item.GetComponent<Rigidbody>().useGravity = true;
        guide = GameObject.Find("guide").transform;
        UI = GameObject.FindGameObjectWithTag("UI").GetComponent<PlayerUI>();
        MainCamera= GameObject.Find("MainCamera");
        parent= GameObject.Find("guide");
        parentDog= GameObject.Find("Dogs");

    }

    // Update is called once per frame
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player" && (!SecretDogEvent.goodPosition) && number!=0)
        {
        
                UI.changeTriggerText("Trzymaj E aby nieść", Color.yellow);
                if (Input.GetKey(KeyCode.E) && (isCarrying || guide.childCount == 0))
                {
                    UI.changeTriggerText("", Color.yellow);
                    item.GetComponent<Rigidbody>().useGravity = false;
                    item.GetComponent<Rigidbody>().isKinematic = true;
                    item.transform.position = guide.transform.position;
                    item.transform.rotation = guide.transform.rotation;
                    item.transform.parent = parent.transform;
                    isCarrying = true;
                    isDone = false;
                }
                else
                {
                item.GetComponent<Rigidbody>().useGravity = true;
                item.GetComponent<Rigidbody>().isKinematic = false;
                item.transform.parent = parentDog.transform;
              

                if(!Input.GetKey(KeyCode.E))
                {
                    StopAllCoroutines();
                    StartCoroutine("IsNotCarrying");
                }

               

            }
        }
        
            if (other.tag == "Player" && EventDogPart2.EventWoof)
            {
            if (number == 4)
            {
                UI.changeTriggerText("Sprawdz (E)", Color.yellow);     
            }
            else
            {
                UI.changeTriggerText("Użyj (E)", Color.yellow);
            }
                if (Input.GetKey(KeyCode.E) &&(!clicked))
                {
                clicked = true;
                FindObjectOfType<AudioManager>().PlaySound(soundName);
                EventDogPart2.CheckIfGood(letter,number);
                StartCoroutine("RefreshClick");
                }

            }
        
    }
    public IEnumerator RefreshClick()
    {
        yield return new WaitForSeconds(1);
        clicked = false;
    }
    public IEnumerator IsNotCarrying()
    {
        yield return new WaitForSeconds(1);
        isCarrying = false;
    }

    private void OnTriggerExit(Collider other)
    {
        UI.changeTriggerText("", Color.yellow);
    }
}
