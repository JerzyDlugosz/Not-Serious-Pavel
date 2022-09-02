using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnDestroyEnemy : MonoBehaviour
{
    private void OnDisable()
    {

        if (AudioManager.instance == null){
            return;
        }
        try // null 
        {
            if (FindObjectOfType<AudioManager>().levelMusic == 1)
            {
                FindObjectOfType<AudioManager>().ChangeVolumeToZero("fight-music");
                FindObjectOfType<AudioManager>().ChangeVolumeToMax("relax-music");
            }
            if (FindObjectOfType<AudioManager>().levelMusic == 2)
            {
                FindObjectOfType<AudioManager>().ChangeVolumeToZero("fight-desert");
                FindObjectOfType<AudioManager>().ChangeVolumeToMax("relax-desert");
            }
        }
        catch
        {

        }
       
    }
}
