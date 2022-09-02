using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketSecret : MonoBehaviour
{
    // Start is called before the first frame update
    public bool _triggered;
    private void OnTriggerEnter(Collider other)
    {
        if (_triggered)
        {
            return;
        }
        _triggered = true;

       
            FindObjectOfType<AudioManager>().StopSound("fight-music");
            FindObjectOfType<AudioManager>().StopSound("relax-music");
            FindObjectOfType<AudioManager>().PlaySound("2012");
        
    
    }

    private void OnTriggerExit(Collider other)
    {
        if (!_triggered)
        {
            return;
        }
        _triggered = false;
        FindObjectOfType<AudioManager>().PlaySound("fight-music");
        FindObjectOfType<AudioManager>().PlaySound("relax-music");
        FindObjectOfType<AudioManager>().StopSound("2012");
    }
}
