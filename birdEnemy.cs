using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class birdEnemy : Enemy
{
    // Start is called before the first frame update

    public override void Start()
    {
        base.Start();
    }

    // Update is called once per frame

    public override void Update()
    {
        base.Update();
        Move();
    }

    public override void Move()
    {
        Vector2 playerposition = GameObject.FindGameObjectWithTag("Player").transform.position;
        transform.position = Vector2.MoveTowards(transform.position,playerposition,speedRun*Time.deltaTime);
    }

    public override void Animation()
    {
        
    }
}
