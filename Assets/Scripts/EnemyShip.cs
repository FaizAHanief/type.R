using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShip : MonoBehaviour {

    public Vector3 shipPos;
    public GameObject word, explosionPrefab;

    private int def;
    private bool firstContact = true;

    GameObject playerShip,wordMan;
    
    void Start () {
        playerShip = GameObject.Find("PlayerShip");
        wordMan = GameObject.Find("WordManager");
	}

    public void ChangeShipDir() {
        Vector3 vectorTar = playerShip.transform.position - transform.position;
        float angle = (Mathf.Atan2(vectorTar.y, vectorTar.x) * Mathf.Rad2Deg) - 90;
        Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * 50f);
    }
	
	void Update () {
        shipPos = transform.position;
        ChangeShipDir();
    }

    void OnTriggerEnter2D(Collider2D col) {
        if(col.tag=="PlayerShip")
            {
                Destroy(col.gameObject);
                PlayExplosion();
                Destroy(gameObject);
                wordMan.GetComponent<WordManager>().gameOver.SetActive(true);
                wordMan.GetComponent<WordManager>().gameScreen.SetActive(false);
            }
        if(col.tag=="PlayerBullet" && firstContact)
            {
                def = wordMan.GetComponent<WordManager>().activeWord.word.Length;
                def--;
                firstContact = false;
            } else if(col.tag == "PlayerBullet" && !firstContact)
                {
                    def--;
                    if(def==0)
                        { 
                            PlayExplosion();
                            Destroy(gameObject);
                        }
                }
    } 
    
    void PlayExplosion() {
        GameObject explosion = Instantiate(explosionPrefab);
        explosion.transform.position = transform.position;
    }
}
