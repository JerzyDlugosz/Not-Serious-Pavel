using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OnDestroyBoss : MonoBehaviour
{
    private void BossKill()
    {

        foreach (var item in dontdestroyonload.GetDestroyDontDestroys)
        {
            SceneManager.MoveGameObjectToScene(item.gm, SceneManager.GetActiveScene());
        }

        dontdestroyonload.GetDestroyDontDestroys.Clear();
        SceneManager.LoadScene(7);

    }
}
