using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class player : MonoBehaviour,Idameage
{
    public int maxHp;
    public float speedRun;
    public float speedJump;
    public int dame;
    public Image healthbar;
    private int nowHp;
    private Animator animator;
    private Rigidbody2D rb;
    private Vector2 direction;
    private int maxJump;
    private bool isJump;
    public Text applepoint;
    private int nowdirection;
    public Image ImageHealthBar;
    // Start is called before the first frame update
    void Start()
    {
        // Sử dụng vật lí để di chuyển
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        maxJump = 0;
        isJump = true;
        speedJump = 15;
        speedRun = 5;
        nowHp = maxHp;
        healthbar.fillAmount = 1.0f * nowHp / maxHp;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "apple")
        {
            Destroy(other.gameObject);
            GameController.gameController.Add(1);
        }
        if (other.gameObject.tag == "end")
        {
            SceneManager.LoadScene("Endscene");
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag=="enemy")
        {
            Vector3 contactPoint = other.GetContact(0).point; //Vị trí điểm va chạm
            float RectWidth = other.gameObject.GetComponent<BoxCollider2D>().bounds.size.x; //Độ rộng collider other
            Vector3 center = other.gameObject.GetComponent<BoxCollider2D>().bounds.center; //tọa độ của vị trí chung tâm
            //Kiểm tra tọa độ va chạm Y của vị trí va chạm phải lớn hơn vị trí chung tâm và tọa độ va chạm x phải nằm trong khoảng yêu cầu;
            if (center.y < contactPoint.y &&
                (contactPoint.x < center.x + RectWidth / 2 && contactPoint.x > center.x - RectWidth / 2))
            {
                other.gameObject.GetComponent<Enemy>().takeDamage(10000);
            }
            else
            {
                this.takeDamage(other.gameObject.GetComponent<Enemy>().Damage);
            }
        }


            //
        direction = Vector2.zero;
        isJump = false;
        maxJump = 1;
        // Debug.Log(other.collider.name);
    }

    // Update is called once per frame
    void Update()
    {
        healthbar.fillAmount = 1.0f * nowHp / maxHp;
        //di chuyen
        //sử dụng Input.getaxxisraw để trả về giá trị di chuyển;
        Move();
        
        //animation
        Animation();
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector2(direction.x , rb.velocity.y);
    }

    private void Move()
    {
        direction = Vector2.right * Input.GetAxisRaw("Horizontal") * speedRun;
        if (direction.x > 0)
        {
            nowdirection = 1;
            transform.localScale=new Vector3(nowdirection, transform.localScale.y, transform.localScale.z);
        }
        else if (direction.x < 0)
        {
            nowdirection = -1;
            transform.localScale=new Vector3(nowdirection, transform.localScale.y, transform.localScale.z);
        }
        ImageHealthBar.transform.localScale = new Vector3(nowdirection, ImageHealthBar.transform.localScale.y, ImageHealthBar.transform.localScale.z);
        
        if (maxJump!=0)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                rb.AddForce(Vector2.up * speedJump,ForceMode2D.Impulse);
                maxJump--;
                isJump = true;
                AudioController.Instance.Playaudiosources("playerJump");
            }
        }
    }

    private void Animation()
    {
        
        if (isJump == false)
        {
            if (direction == Vector2.zero)
            {
                animator.Play("idleAnimation");
            }
            else if (direction.x > 0)
            {
                animator.Play("runAnimations");
                transform.localScale = new Vector3(1, transform.localScale.y, transform.localScale.z);
                // AudioController.Instance.Playaudiosources("PlayerRun");
            }
            else if (direction.x < 0) 
            {
                transform.localScale = new Vector3(-1, transform.localScale.y, transform.localScale.z);
                animator.Play("runAnimations");
                // AudioController.Instance.Playaudiosources("PlayerRun");
            }

        }
        else
        {
            if(rb.velocity.y>0) animator.Play("JumpAnimation");
            else animator.Play("falseAnimation");
            // AudioController.Instance.Playaudiosources("playerJump");
        }
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

    private void Die()
    {
        //Lose
        SceneManager.LoadScene("Endscene");
        //Destroy
        Destroy(gameObject);
    }
}
