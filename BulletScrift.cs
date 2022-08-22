using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScrift : MonoBehaviour
{
    public GameObject plant;
    public int dame;
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        dame = plant.GetComponent<PlantEnemy>().Damage;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "map")
        {
            Destroy(gameObject);
        }else if (col.gameObject.tag=="Player")
        {
            Destroy(gameObject);
            col.GetComponent<player>().takeDamage(dame);
        }
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 direction = Vector2.left * 10;
        rb.velocity = direction;
    }
}
