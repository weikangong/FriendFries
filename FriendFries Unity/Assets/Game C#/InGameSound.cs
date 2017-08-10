using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This script plays the global in game sound and gets
// destoryed by MenuSound script when that is activated
public class InGameSound : MonoBehaviour {
    public static InGameSound instance = null;
    public static InGameSound getInstance { get { return instance; } }

    void Awake() {
        if (instance != null && instance != this) {
            Destroy(this.gameObject);   
            return;
        }
        else { instance = this; }

        DontDestroyOnLoad(this.gameObject);
    }

    void Update() {
        if (instance == null) {
            Destroy(this.gameObject);
            Debug.Log("In game sound cut");
            return;
        }
    }
}
