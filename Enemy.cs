using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class Enemy : MonoBehaviour, Idameage
{
    public int MaxHp;
    protected int nowHp;
    public int Damage;
    public int speedRun;
    protected Rigidbody2D rb;
    protected Vector2 direction;
    public Image ImageHelthBar;
    
    // Start is called before the first frame update
    public virtual void Start()
    {
        
    }

    public virtual void Awake()
    {
        nowHp = MaxHp;
        ImageHelthBar.fillAmount = 1.0f * nowHp / MaxHp;
        rb = GetComponent<Rigidbody2D>();
    }

    public virtual void FixedUpdate()
    {
        
    }

    // Update is called once per frame
    public virtual void Update()
    {
        ImageHelthBar.fillAmount = 1.0f * nowHp / MaxHp;
    }
    
    public void takeDamage(int mount)
    {
        if (nowHp - mount <= 0)
        {
            nowHp = 0;
            Die();
        }
        else
        {
            nowHp -= mount;
        }
    }

    public virtual void Die()
    {
        Destroy(gameObject);
    }

    public abstract void Move();

    public abstract void Animation();
}
