using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Word {

    public string word;

    private int typeIndex;

    WordDisplay display;

    public Word(string _word, WordDisplay _display) {
        word = _word;
        typeIndex = 0;

        display = _display;
        display.SetWord(word);
    }

    public char GetNextLetter() {
        return word[typeIndex];
    }

    public void TypeLetter() {
        typeIndex++;
        display.RemoveLetter();
    }

    public bool WordTyped() {
        bool wordTyped = (typeIndex == word.Length);
        if(wordTyped)
            {
                display.RemoveWord();
            }
        return wordTyped;
    }

    public bool OnScreen() {
        bool onScreen = true;
        if (!display.wordVisible)
            {
                onScreen = false;
            }
        return onScreen;
    }

    public Vector3 ShipPos() {
        Vector3 shipPos = display.shipPos;

        return shipPos;
    }
}
