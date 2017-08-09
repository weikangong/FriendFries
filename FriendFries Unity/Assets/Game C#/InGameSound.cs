using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameSound : MonoBehaviour {

    // Use this for initialization
    void Start()
    {

    }

    //Play Global
    private static InGameSound instance = null;
    public static InGameSound Instance { get { return instance; } }

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
    //Play Gobal End

    // Update is called once per frame
    void Update()
    {

    }
}
