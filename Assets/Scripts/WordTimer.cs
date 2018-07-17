using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordTimer : MonoBehaviour {

    public WordManager wordManager;
    public float wordDelay = 4f;

    private float nextWordTime = 0f;

    void Update() {
        if(Time.time >= nextWordTime)
            {
                wordManager.AddWord();
                nextWordTime = Time.time + wordDelay;
                wordDelay *= .99f;
            }
    }
}
