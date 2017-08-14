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
        "\"Keep calm and keep frying\""
    };
    public Text quote;

    void Start() {
        quote.text = quotes[(int)Random.Range(0, quotes.Length)];
    }
}
