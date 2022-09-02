using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Statics : MonoBehaviour
{
    public static string playerClass;
    public static string difficulty;

    public void SetClass(string pclass)
    {
        playerClass = pclass;
    }
    public void SetDifficulty(string diff)
    {
        difficulty = diff;
    }

}
