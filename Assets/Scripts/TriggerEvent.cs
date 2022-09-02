using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TriggerEvent : MonoBehaviour
{
    public int Scene;
    private void OnTriggerEnter(Collider other)
    {

        //Debug.Log(other.tag);
       
            if (other.tag == "Player")
            {
            foreach (var item in dontdestroyonload.GetDestroyDontDestroys)
            {
                SceneManager.MoveGameObjectToScene(item.gm, SceneManager.GetActiveScene());
            }

            dontdestroyonload.GetDestroyDontDestroys.Clear();
            SceneManager.LoadScene(Scene);
            }
        
     

    }

}
