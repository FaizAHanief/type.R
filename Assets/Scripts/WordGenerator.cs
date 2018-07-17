using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordGenerator : MonoBehaviour {

    private static string[] wordList;

    void Start() {
        ReadText.ReadWordPool();
        wordList = ReadText.wordPool.ToArray();
    }

	public static string GetRandomWord() {
        int randomIndex = Random.Range(0, wordList.Length);
        string randomWord = wordList[randomIndex];

        return randomWord;
    }
}
