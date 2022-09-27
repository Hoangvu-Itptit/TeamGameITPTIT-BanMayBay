using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    public LeverController levercontroller;
    public float moveSpeed;
    public float Hp;
    public GameObject BulletGameObject;
    public Transform gunposition;
    public float Damage;
    private float timer;
    private float delayDame;

    // Start is called before the first frame update
    void Start()
    {
        Damage = 30f;
        moveSpeed = 5f;
        timer = 0f;
        delayDame = 0.25f;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Coliable")
        {
            Hp -= 50f;
            if (Hp <= 0f)
            {
                Die();
            }
            Destroy(other.gameObject);
        }
        else if (other.gameObject.tag == "bullet")
        {
            Hp -= other.gameObject.GetComponent<Bullet>().Bulletdame;
            if (Hp <= 0f)
            {
                Die();
            }
            Destroy(other.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        moveSpeed = 5f;
        #region Keyinput
        if(Input.GetKey(KeyCode.W)&&Input.GetKey(KeyCode.A))
        {
            moveSpeed /= Mathf.Sqrt(2);
            transform.position += new Vector3(-moveSpeed * Time.deltaTime, moveSpeed * Time.deltaTime, 0);
        }
        else if(Input.GetKey(KeyCode.W)&&Input.GetKey(KeyCode.D))
        {
            moveSpeed /= Mathf.Sqrt(2);
            transform.position += new Vector3(moveSpeed * Time.deltaTime, moveSpeed * Time.deltaTime, 0);
        }
        else if(Input.GetKey(KeyCode.S)&&Input.GetKey(KeyCode.A))
        {
            moveSpeed /= Mathf.Sqrt(2);
            transform.position += new Vector3(-moveSpeed * Time.deltaTime, -moveSpeed * Time.deltaTime, 0);
        }
        else if(Input.GetKey(KeyCode.S)&&Input.GetKey(KeyCode.D))
        {
            moveSpeed /= Mathf.Sqrt(2);
            transform.position += new Vector3(moveSpeed * Time.deltaTime, -moveSpeed * Time.deltaTime, 0);
        }
        else if (Input.GetKey(KeyCode.W))
            transform.position += new Vector3(0, moveSpeed * Time.deltaTime, 0);
        else if (Input.GetKey(KeyCode.A))
            transform.position += new Vector3(-moveSpeed * Time.deltaTime, 0, 0);
        else if(Input.GetKey(KeyCode.S))
            transform.position += new Vector3(0, -moveSpeed * Time.deltaTime, 0);
        else if (Input.GetKey(KeyCode.D))
            transform.position += new Vector3(moveSpeed * Time.deltaTime, 0, 0);
        #endregion

        #region MouseInput
        
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0;
        // transform.position = mousePosition;
        Vector3 direction = mousePosition - transform.position;
        direction.z = 0;
        float a = Mathf.Sqrt(Mathf.Pow(direction.x, 2) + Mathf.Pow(direction.y, 2));
        direction.Normalize();
        transform.position += direction*moveSpeed*Time.deltaTime;

        if (Input.GetMouseButtonDown(0))
        {
            if (timer >= delayDame)
            {
                GameObject bulletGameObject=Instantiate(BulletGameObject,gunposition.position, Quaternion.identity);
                playerBullet bullet = bulletGameObject.GetComponent<playerBullet>();
                bullet.Bulletdame = this.Damage;
                timer = 0f;
            }
        }
        
        #endregion
        
        Vector3 temp = transform.position;
        temp.x = Mathf.Clamp(temp.x, -globalValue.screenWidth/2f, globalValue.screenWidth/2f);
        temp.y = Mathf.Clamp(temp.y, -globalValue.screenHeight/2f, globalValue.screenHeight/2f);
        transform.position = temp;
    }

    private void Die()
    {
        Destroy(gameObject);
        levercontroller.Lose();
    }
}
