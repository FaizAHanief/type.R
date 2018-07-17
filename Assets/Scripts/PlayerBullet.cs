using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour {

    private float speed;

    GameObject wordManager;
    WordManager wordMan;
    
    void Start () {
        speed = 10f;
        wordManager = GameObject.Find("WordManager");
        wordMan = wordManager.GetComponent<WordManager>();
    }
	
	void Update () {
        Vector2 position = transform.position;
        Vector2 direction = wordMan.activeWord.ShipPos() - transform.position;
        position += direction * speed * Time.deltaTime;
        transform.position = position;
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));
        if (transform.position.y > max.y) 
            {
                Destroy(gameObject);
            }
    }

    void OnTriggerEnter2D(Collider2D col) {
        if(col.tag=="EnemyShip")
            {
                Destroy(gameObject);
            }
    } 
}
