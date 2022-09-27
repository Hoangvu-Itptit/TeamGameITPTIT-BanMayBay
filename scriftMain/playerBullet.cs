using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerBullet : MonoBehaviour
{
    public float Bulletdame;
    
    // Start is called before the first frame update
    void Start()
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.AddForce(new Vector2(0,10f),ForceMode2D.Impulse);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Coliable" )
        {
            Destroy(other.gameObject);
            Destroy(this.gameObject);
        }else if (other.gameObject.tag == "bullet")
        {
            Destroy(other.gameObject);
            Destroy(this.gameObject);
        }else if (other.gameObject.tag == "Player")
        {
            Destroy(this.gameObject);
        }else if (other.gameObject.tag == "enemy")
        {
            Destroy(this.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
