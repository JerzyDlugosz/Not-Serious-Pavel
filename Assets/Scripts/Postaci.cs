using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Postaci : MonoBehaviour
{
    public Button Cofnij;
    void Start()
    {
        Cofnij.onClick.AddListener(toOption);
    }


    void toOption()
    {
        SceneManager.LoadScene("Options");
    }
}
