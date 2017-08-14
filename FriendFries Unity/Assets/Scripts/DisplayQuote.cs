using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// This script displays the quote randomly on CreditsScene
public class DisplayQuote : MonoBehaviour {
    public string[] quotes =
    {
        "\"For those fries who need a little spice.\"",
        "\"Fries before guys.\"",
        "\"Keep calm and keep frying\"",
		"\"Live, Laugh, Potato\"",
		"\"I'm a tiny potato, and I believe in you\"",
		"\"Keep your friends close, but keep your fries closer\"",
		"\"Exersise? More like extra fries\"",
    };
    public Text quote;

    void Start() {
        quote.text = quotes[(int)Random.Range(0, quotes.Length)];
    }
}
