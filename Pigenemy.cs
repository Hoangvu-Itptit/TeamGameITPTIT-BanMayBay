using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class Pigenemy : Enemy
{
    private int nowdirection;
    public LayerMask terrian;

    private float timer;
    public override void Awake()
    {
        base.Awake();
    }

    public override void Start()
    {
        base.Start();
        nowdirection = -1;
        speedRun = 2;
        timer = 1f;
    }

    public override void FixedUpdate()
    {
        base.FixedUpdate();
        rb.velocity = new Vector2(direction.x, rb.velocity.y);
    }

    public override void Update()
    {
        timer += Time.deltaTime;
        base.Update();
        Move();
        direction = Vector2.left * nowdirection * speedRun;
    }

    public override void Die()
    {
        base.Die();
    }
    
    public override void Move()
    {
        RaycastHit2D rightraycast = Physics2D.Raycast(transform.position, transform.right, 0.6f, terrian);
        RaycastHit2D leftraycast = Physics2D.Raycast(transform.position, -transform.right, 0.6f, terrian);
        if (timer>1f&&(rightraycast.collider != null || leftraycast.collider != null))
        {
            nowdirection *= -1;
            transform.localScale = new Vector3(nowdirection, transform.localScale.y, transform.localScale.z);
            ImageHelthBar.transform.localScale =
                new Vector3(nowdirection * -1, ImageHelthBar.transform.localScale.y, ImageHelthBar.transform.localScale.z);
            timer = 0f;
        }
    }

    public override void Animation()
    {
        
    }
}
