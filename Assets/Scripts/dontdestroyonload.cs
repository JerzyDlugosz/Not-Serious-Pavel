using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dontdestroyonload : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        if (this.gameObject.name != "AudioManager")
        {
            DontDestroyOnLoad(this.gameObject);
            GetDestroyDontDestroys.Add(new DestroyDontDestroy(this.gameObject));
        }
        else
        {
            DontDestroyOnLoad(this.gameObject);
        }
    }
  //  public static List<string> DontDestroyStrings = new List<string>();
    public static List<DestroyDontDestroy> GetDestroyDontDestroys = new List<DestroyDontDestroy>();
}
public class DestroyDontDestroy
{
    public GameObject gm;
    public DestroyDontDestroy(GameObject _gm)
    {
        gm = _gm;
    }
}
