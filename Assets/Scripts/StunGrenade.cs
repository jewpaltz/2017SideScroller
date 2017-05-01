using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StunGrenade : Throwable {

    public float blastRadius = 5;
    
    void OnCollisionEnter2D(Collision2D coll)
    {
        var player = coll.gameObject.GetComponent<Player>();
        if (isActive && player == null) {
            Explode();
        }
    }

    public void Explode()
    {
        //  Get a reference to all enemies
        var enemies = FindObjectsOfType<Enemy>();

        //  Loop through each enemy in the list
        foreach (var e in enemies) {

            //  Check if that enemy is within the blast radius
            if (Vector3.Distance(this.transform.position, e.transform.position) < blastRadius) {

                //  Set that enemy to NOT-Active
                StartCoroutine( Stun(e) );
            }
        }

        //  Set myself (aka the bomb) to NOT-Active. That way the bomb disappears, and can not be picked up again.
        collider2D.enabled = false;
        GetComponent<SpriteRenderer>().enabled = false;

    }

    IEnumerator Stun(Enemy e)
    {
        var renderer = e.GetComponent<SpriteRenderer>();

        e.enabled = false;
        renderer.color = new Color(1, 1, 1, .4f);
        yield return new WaitForSeconds(5);

        e.enabled = true;
        renderer.color = new Color(1, 1, 1, 1);
    }
}
