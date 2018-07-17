using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordSpawner : MonoBehaviour {

    public GameObject wordPrefab;
    public Transform wordCanvas;

    public WordDisplay SpawnWord() {
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));
        Vector3 randomPosition = new Vector3(Random.Range(min.x, max.x), max.y);

        GameObject wordObj = Instantiate(wordPrefab, wordCanvas);
        wordObj.transform.position = randomPosition;
        WordDisplay wordDisplay = wordObj.GetComponentInChildren<WordDisplay>();

        return wordDisplay;
    }
}
