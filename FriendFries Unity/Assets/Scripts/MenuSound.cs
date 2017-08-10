using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuSound : MonoBehaviour {
    public AudioClip sound;
    private AudioSource source { get { return GetComponent<AudioSource>(); } }

    void Start() {
        gameObject.AddComponent<AudioSource>();
        source.clip = sound;
        source.Play();

        if (InGameSound.getInstance != null) {
            InGameSound.instance = null;
        }
    }
}
