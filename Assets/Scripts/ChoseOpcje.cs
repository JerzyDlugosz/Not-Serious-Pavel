using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ChoseOpcje : MonoBehaviour
{
    public Button Poziom;
    public Button Postaci;

    void Start()
    {
        Poziom.onClick.AddListener(toOption);
        Postaci.onClick.AddListener(toOption1);
    }

    void toOption()
    {
        SceneManager.LoadScene("PoziomyTrudnosci");
    }

    void toOption1()
    {
        SceneManager.LoadScene("Postaci");
    }

}