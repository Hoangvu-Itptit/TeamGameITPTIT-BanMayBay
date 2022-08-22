using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantEnemy : Enemy
{
    public int speedJump;
    public Animator animator;
    public GameObject PlantBullet;
    public Transform instan;
    private bool isshot;
    
    // Start is called before the first frame update
    public override void Awake()
    {
        base.Awake();
        isshot = false;
        Move();
    }

    public override void Update()
    {
        base.Update();
    }
    public IEnumerator Teleport()
    {
        while (true)
        {
            for(int i=1;i<=3;i++)
            {
                isshot = false;
                rb.AddForce(Vector2.up*speedJump,ForceMode2D.Impulse);
                Animation();
                yield return new WaitForSeconds(2*i);
            }

            isshot = true;
            // yield return new WaitForSecondsRealtime(1);
            for (int i = 1; i <= 3; i++)
            {
                isshot = true;
                Animation();
                yield return new WaitForSecondsRealtime(0.08f);
                Instantiate(PlantBullet, instan.position, Quaternion.identity);
                isshot = false;
                Animation();
                yield return new WaitForSecondsRealtime(1);
                
            }
        }
    }

    public override void Move()
    {
        StartCoroutine(Teleport());
    }
    
    public override void Animation()
    {
        if (isshot)
        {
            animator.Play("PlantHitAnimation");
        }
        else
        {
            animator.Play("PlantAnimation");
        }
    }

    // Update is called once per frame
    public override void Start()
    {
        base.Start();
    }
    
}
