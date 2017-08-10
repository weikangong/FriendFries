using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]

// This script plays the click sound on pressing button
public class ClickSound : MonoBehaviour {
    public AudioClip sound;
    private Button button { get { return GetComponent<Button>(); } }
    private AudioSource source { get { return GetComponent<AudioSource>(); } }

    void Start() {
        gameObject.AddComponent<AudioSource>();
        source.clip = sound;
        source.playOnAwake = false;
        button.onClick.AddListener(() => PlaySound());
    }

    void PlaySound() { source.PlayOneShot(sound); }
} 
