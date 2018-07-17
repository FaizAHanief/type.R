using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WordDisplay : MonoBehaviour {

    public Text text;
    public float fallSpeed = 1f;
    public bool wordVisible = true;
    public Vector3 shipPos;

    public void SetWord(string word) {
        text.text = word;
    }

    public void RemoveLetter() {
        text.text = text.text.Remove(0, 1);
        text.color = Color.red;
    }

    public void RemoveWord() {
        Destroy(gameObject);
    }

    void Update() {
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
        if (transform.position.y < min.y)
            {
                wordVisible = false;
                RemoveWord();
            }
        shipPos = GetComponentInParent<Enemy>().shipPos;
    }
}
