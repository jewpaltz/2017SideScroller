using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour {

    void OnCollisionEnter2D(Collision2D coll)
    {
        var player = coll.gameObject.GetComponent<Player>();
        if (player != null) {
            var enemies = FindObjectsOfType<Enemy>();
            foreach(var e in enemies) {
                if(Vector3.Distance(this.transform.position, e.transform.position) < 10) {
                    e.gameObject.SetActive(false);
                }
            }
        }
    }
}
