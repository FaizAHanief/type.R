using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordManager : MonoBehaviour {

    public List<Word> words;
    public WordSpawner wordSpawner;
    public GameObject playerShip, gameScreen, gameOver;
    public Word activeWord;

    private bool hasActiveWord;

    PlayerShip pShip;

    void Awake() {
        pShip = playerShip.GetComponent<PlayerShip>();
    }

    void Update() {
        RemoveWord();
    }

    public void AddWord() {
        Word word = new Word(WordGenerator.GetRandomWord(), wordSpawner.SpawnWord());

        words.Add(word);
    }

    public void TypeLetter (char letter) {
        if(hasActiveWord)
            {
                if(activeWord.GetNextLetter() == letter)
                    {
                        pShip.ChangeShipDir();
                        pShip.SpawnBullet();
                        activeWord.TypeLetter();
                    }
            } else
                {
                    foreach(Word word in words)
                        {
                            if(word.GetNextLetter() == letter)
                                {
                                    activeWord = word;
                                    hasActiveWord = true;
                                    pShip.ChangeShipDir();
                                    pShip.SpawnBullet();
                                    word.TypeLetter();
                                    break;
                                }
                        }
                }
        
        if(hasActiveWord && activeWord.WordTyped())
            {
                hasActiveWord = false;
                words.Remove(activeWord);
            }
    }

    public void RemoveWord() {
        List<Word> wordRemove = new List<Word>();
        foreach (Word word in words)
            {
                if (!word.OnScreen())
                    {
                        wordRemove.Add(word);
                    }
            }
        foreach(Word word in wordRemove)
            {
                if(word==activeWord)
                    {
                        hasActiveWord = false;
                    }
                words.Remove(word);
            }
    }
}
