using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuSound : MonoBehaviour {
    public AudioClip sound;
    private AudioSource source { get { return GetComponent<AudioSource>(); } }

    // Use this for initialization
    void Start () {
        gameObject.AddComponent<AudioSource>();
        source.clip = sound;
        source.Play();
        InGameSound.Instance.gameObject.GetComponent<AudioSource>().Pause();
    }
}
