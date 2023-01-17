using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSc : MonoBehaviour
{
  

    // Start is called before the first frame update
    void Start()
    {
        
    }
    private static AudioSc instance = null;
    public static AudioSc Instance
    {
        get { return instance; }
    }

    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        else
        {
            instance = this;
        }
        DontDestroyOnLoad(this.gameObject);
    }

}
