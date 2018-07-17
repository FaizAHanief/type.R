using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordInput : MonoBehaviour {

    public WordManager wordManager;
    public char letter;

    void Update () {
        foreach(char letter in Input.inputString)
            {
                wordManager.TypeLetter(letter);
            }
	}

    public void KeyboardButton() {
        wordManager.TypeLetter(letter);
    }
}
