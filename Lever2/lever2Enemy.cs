using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lever2Enemy : MonoBehaviour
{
    public LeverController levercontroller;
    public float Hp;
    public float Damage;
    public float moveSpeed;
    public float delayDame;
    
    private float timer;
    private int direction;
    
    public GameObject bulletPretabs;
    public Transform gunposition;
    
    // Start is called before the first frame update
    void Start()
    {
        timer = 0.5f;
        direction = 1;
        moveSpeed = 2f;
        delayDame = 1f;
        Damage = 20f;
        Hp = 20f;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "playerBullet")
        {
            Destroy(other.gameObject);
            Hp -= other.gameObject.GetComponent<playerBullet>().Bulletdame;
            if (Hp <= 0f)
            {
                Die();
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        #region Move

        
        transform.position += new Vector3(0,-moveSpeed *direction* Time.deltaTime, 0);


        #endregion
        
        #region gunbullet

        if (timer >= delayDame)
        {
            GameObject bulletGameObject=Instantiate(bulletPretabs,gunposition.position, Quaternion.identity);
            Bullet bullet = bulletGameObject.GetComponent<Bullet>();
            bullet.Bulletdame = this.Damage;
            timer = 0f;
        }
        
        #endregion
        
    }

    private void Die()
    {
        Destroy(gameObject);
        levercontroller.Win();
    }
}
