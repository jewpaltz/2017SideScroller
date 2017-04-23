using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour {

    public float blastRadius = 5;

    void OnCollisionEnter2D(Collision2D coll)
    {
        var player = coll.gameObject.GetComponent<Player>();
        if (player != null) {

            //  Get a reference to all enemies
            var enemies = FindObjectsOfType<Enemy>();

            //  Loop through each enemy in the list
            foreach(var e in enemies) {

                //  Check if that enemy is within the blast radius
                if(Vector3.Distance(this.transform.position, e.transform.position) < blastRadius) {

                    //  Set that enemy to NOT-Active
                    e.gameObject.SetActive(false);
                }
            }

            //  Set myself (aka the bomb) to NOT-Active. That way the bomb disappears, and can not be picked up again.
            gameObject.SetActive(false);
        }
    }
}
