using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadState : MonoBehaviour
{
    public int secondarySaveFile;

    public void ChangeSaveFile(int saveFileNumber)
    {
        secondarySaveFile = saveFileNumber;
    }
}
