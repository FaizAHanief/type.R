using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public Vector3 shipPos;
    public float speed;

    GameObject playerShip;
    
    void Start () {
        playerShip = GameObject.Find("PlayerShip");
	}
	
	void Update () {
        Vector2 position = transform.position;
        Vector2 direction = playerShip.transform.position - transform.position;
        position += direction * speed * Time.deltaTime;
        transform.position = position;
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
        if (transform.position.y < min.y) 
            {
                Destroy(gameObject);
            }
        if(!GetComponentInChildren<EnemyShip>())
            {
                Destroy(gameObject);
            } else
                {
                    shipPos = GetComponentInChildren<EnemyShip>().shipPos;
                }
	}
}
