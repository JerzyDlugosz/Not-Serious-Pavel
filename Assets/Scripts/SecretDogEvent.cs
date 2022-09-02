using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecretDogEvent : MonoBehaviour
{
    public Transform position1, position2, position3, position4;
    private PlayerUI UI;
    public static bool goodPosition;
    void Start()
    {
        UI = GameObject.FindGameObjectWithTag("UI").GetComponent<PlayerUI>();
        goodPosition = false;
    }

    private void OnTriggerStay(Collider other)
    {
        if ((GameObject.Find("Dog1").GetComponent<LiftItem>().isCarrying == true) || (GameObject.Find("Dog2").GetComponent<LiftItem>().isCarrying == true) || (GameObject.Find("Dog3").GetComponent<LiftItem>().isCarrying == true))
        {
        
            if ((other.tag == "Player") && (gameObject.CompareTag("FirstDog")))
            {
                    if (Input.GetKey(KeyCode.E))
                    {
                        UI.changeDogEventText("Puść E aby ułożyć statuetkę");
                    }
                    else
                    {
                        UI.changeDogEventText("");
                        if ((GameObject.Find("Dog1").GetComponent<LiftItem>().number == 1) && (GameObject.Find("Dog1").GetComponent<LiftItem>().isCarrying == true))
                        {
                            GameObject.Find("Dog1").transform.position = position1.transform.position;
                            GameObject.Find("Dog1").transform.rotation = position1.transform.rotation;
                            GameObject.Find("Dog1").GetComponent<LiftItem>().isCarrying = false;
                            GameObject.Find("Dog1").GetComponent<LiftItem>().isDone = true;
                        GameObject.Find("Dog1").GetComponent<Rigidbody>().mass = 50;
                    }
                       else if ((GameObject.Find("Dog2").GetComponent<LiftItem>().number == 2) && (GameObject.Find("Dog2").GetComponent<LiftItem>().isCarrying == true))
                        {
                            GameObject.Find("Dog2").transform.position = position1.transform.position;
                            GameObject.Find("Dog2").transform.rotation = position1.transform.rotation;
                            GameObject.Find("Dog2").GetComponent<LiftItem>().isCarrying = false;
                        GameObject.Find("Dog2").GetComponent<Rigidbody>().mass = 50;
                    }
                       else if ((GameObject.Find("Dog3").GetComponent<LiftItem>().number == 3) && (GameObject.Find("Dog3").GetComponent<LiftItem>().isCarrying == true))
                        {
                            GameObject.Find("Dog3").transform.position = position1.transform.position;
                            GameObject.Find("Dog3").transform.rotation = position1.transform.rotation;
                            GameObject.Find("Dog3").GetComponent<LiftItem>().isCarrying = false;
                        GameObject.Find("Dog3").GetComponent<Rigidbody>().mass = 50;
                    }
                    }
            
            }

            if ((other.tag == "Player") && (gameObject.CompareTag("SecondDog")))
            {
           
                    if (Input.GetKey(KeyCode.E))
                    {
                        UI.changeDogEventText("Puść E aby ułożyć statuetkę");
                    }
                    else
                    {
                        UI.changeDogEventText("");
                    if ((GameObject.Find("Dog1").GetComponent<LiftItem>().number == 1) && (GameObject.Find("Dog1").GetComponent<LiftItem>().isCarrying == true))
                    {
                        GameObject.Find("Dog1").transform.position = position2.transform.position;
                        GameObject.Find("Dog1").transform.rotation = position2.transform.rotation;
                        GameObject.Find("Dog1").GetComponent<LiftItem>().isCarrying = false;
                        GameObject.Find("Dog1").GetComponent<Rigidbody>().mass = 50;

                    }
                    else if ((GameObject.Find("Dog2").GetComponent<LiftItem>().number == 2) && (GameObject.Find("Dog2").GetComponent<LiftItem>().isCarrying == true))
                    {
                        GameObject.Find("Dog2").transform.position = position2.transform.position;
                        GameObject.Find("Dog2").transform.rotation = position2.transform.rotation;
                        GameObject.Find("Dog2").GetComponent<LiftItem>().isCarrying = false;
                        GameObject.Find("Dog2").GetComponent<LiftItem>().isDone = true;
                        GameObject.Find("Dog2").GetComponent<Rigidbody>().mass = 50;
                    }
                    else if ((GameObject.Find("Dog3").GetComponent<LiftItem>().number == 3) && (GameObject.Find("Dog3").GetComponent<LiftItem>().isCarrying == true))
                    {
                        GameObject.Find("Dog3").transform.position = position2.transform.position;
                        GameObject.Find("Dog3").transform.rotation = position2.transform.rotation;
                        GameObject.Find("Dog3").GetComponent<LiftItem>().isCarrying = false;
                        GameObject.Find("Dog3").GetComponent<Rigidbody>().mass = 50;

                    }
                }
            
            }

            if ((other.tag == "Player") && (gameObject.CompareTag("ThirdDog")))
            {
            
                    if (Input.GetKey(KeyCode.E))
                    {
                        UI.changeDogEventText("Puść E aby ułożyć statuetkę");
                    }
                    else
                    {
                        UI.changeDogEventText("");
                    if ((GameObject.Find("Dog1").GetComponent<LiftItem>().number == 1) && (GameObject.Find("Dog1").GetComponent<LiftItem>().isCarrying == true))
                    {
                        GameObject.Find("Dog1").transform.position = position3.transform.position;
                        GameObject.Find("Dog1").transform.rotation = position3.transform.rotation; 
                        GameObject.Find("Dog1").GetComponent<LiftItem>().isCarrying = false;
                        GameObject.Find("Dog1").GetComponent<Rigidbody>().mass = 50;
                    }
                    else if ((GameObject.Find("Dog2").GetComponent<LiftItem>().number == 2) && (GameObject.Find("Dog2").GetComponent<LiftItem>().isCarrying == true))
                    {
                        GameObject.Find("Dog2").transform.position = position3.transform.position;
                        GameObject.Find("Dog2").transform.rotation = position3.transform.rotation;
                        GameObject.Find("Dog2").GetComponent<LiftItem>().isCarrying = false;
                        GameObject.Find("Dog2").GetComponent<Rigidbody>().mass = 50;
                    }
                    else if ((GameObject.Find("Dog3").GetComponent<LiftItem>().number == 3) && (GameObject.Find("Dog3").GetComponent<LiftItem>().isCarrying == true))
                    {
                        GameObject.Find("Dog3").transform.position = position3.transform.position;
                        GameObject.Find("Dog3").transform.rotation = position3.transform.rotation;
                        GameObject.Find("Dog3").GetComponent<LiftItem>().isCarrying = false;
                        GameObject.Find("Dog3").GetComponent<LiftItem>().isDone = true;
                        GameObject.Find("Dog3").GetComponent<Rigidbody>().mass = 50;
                    }
                }
            
            }

        
        }

        if (goodPosition)
        {
            GameObject.Find("Dog1").transform.position = position1.transform.position;
            GameObject.Find("Dog1").transform.rotation = position1.transform.rotation;
            GameObject.Find("Dog2").transform.position = position2.transform.position;
            GameObject.Find("Dog2").transform.rotation = position2.transform.rotation;
            GameObject.Find("Dog3").transform.position = position3.transform.position;
            GameObject.Find("Dog3").transform.rotation = position3.transform.rotation;
            GameObject.Find("Dog4").transform.position = position4.transform.position;
            GameObject.Find("Dog4").transform.rotation = position4.transform.rotation;
        }
    }


    private void OnTriggerExit(Collider other)
    {
        UI.changeDogEventText("");
        UI.changecongratulationsText("");
    }
    // Update is called once per frame
    void Update()
    {

    }
}
