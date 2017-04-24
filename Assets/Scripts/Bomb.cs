using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour {

    public float blastRadius = 5;
    public bool isActive = false;

    private new Rigidbody2D rigidbody2D;
    private new Collider2D collider2D;

    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        collider2D = GetComponent<Collider2D>();
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1") && isActive) {
            Throw();
        }
    }
    
    void OnCollisionEnter2D(Collision2D coll)
    {
        var player = coll.gameObject.GetComponent<Player>();
        if (player != null && !isActive) {
            GetPickedUp(player);
        }
        if (isActive && player == null) {
            Explode();
        }
    }

    public void Throw()
    {
        collider2D.enabled = true;
        rigidbody2D.isKinematic = false;
        rigidbody2D.velocity = new Vector2(5, 0);
        transform.parent = null;
    }

    public void GetPickedUp(Player player)
    {
        Debug.Log("Got picked up");
        isActive = true;
        collider2D.enabled = false;
        rigidbody2D.isKinematic = true;
        rigidbody2D.velocity = new Vector2();
        transform.parent = player.transform;
        transform.localScale = new Vector3(.2f, .2f);
        transform.localPosition = new Vector3(.2f, .2f);

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
                e.gameObject.SetActive(false);
            }
        }

        //  Set myself (aka the bomb) to NOT-Active. That way the bomb disappears, and can not be picked up again.
        gameObject.SetActive(false);

    }
}
