using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShip : MonoBehaviour {

    public GameObject playerBullet, bulletPosition, wordMan, explosionPrefab;

    public void ChangeShipDir() {
        Vector3 vectorTar = wordMan.GetComponent<WordManager>().activeWord.ShipPos() - transform.position;
        float angle = (Mathf.Atan2(vectorTar.y, vectorTar.x) * Mathf.Rad2Deg) - 90;
        Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * 50f);
    }

    public void SpawnBullet() {
        GameObject bullet = Instantiate(playerBullet,transform);
        bullet.transform.position = bulletPosition.transform.position;
    }
}
