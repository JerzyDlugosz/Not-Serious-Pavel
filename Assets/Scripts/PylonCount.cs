using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PylonCount : MonoBehaviour
{
    static private Text enemiesRemaining;
    void Start()
    {
        enemiesRemaining = this.GetComponent<Text>();
        this.GetComponent<Text>().text = "4";
    }

    private void OnLevelWasLoaded(int level)
    {
        try
        {
            this.GetComponent<Text>().text = (5 - GameObject.FindGameObjectWithTag("Pylon").GetComponent<PylonData>().pylonNumber).ToString();
        }
        catch
        {
            //blond
        }
 
        
    }

    static public void RefreshEnemiesCount()
    {
        enemiesRemaining.text = (4 - GameObject.FindGameObjectWithTag("Pylon").GetComponent<PylonData>().pylonNumber).ToString();
    }
}

