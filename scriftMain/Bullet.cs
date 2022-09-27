using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float Bulletdame;
    
    // Start is called before the first frame update
    void Start()
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.AddForce(new Vector2(0,-10f),ForceMode2D.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
