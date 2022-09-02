using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Trudnosci : MonoBehaviour
{
    public Button Easy;
    public Button Normal;
    public Button Hard;
    public Button Extreme;
    public Button Cofnij;

    void Start()
    {
        Easy.onClick.AddListener(toGame1);
        Normal.onClick.AddListener(toGame2);
        Hard.onClick.AddListener(toGame3);
        Extreme.onClick.AddListener(toGame4);
        Cofnij.onClick.AddListener(Turn);
       
    }
    void toGame1()
    {
        SceneManager.LoadScene("MainGame");
    }
    void toGame2()
    {
        SceneManager.LoadScene("MainGame");
    }
    void toGame3()
    {
        SceneManager.LoadScene("MainGame");
    }
    void toGame4()
    {
        SceneManager.LoadScene("MainGame");
    }
    void Turn()
    {
        SceneManager.LoadScene("Options");
    }
}
