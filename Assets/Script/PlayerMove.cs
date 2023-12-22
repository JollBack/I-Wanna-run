using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class PlayerMove : MonoBehaviour
{
    public GameManager gameManager;
    public float maxSpeed; // 최대속도
    public float jumpPower; // 점프파워
    public static Action ps;
    Rigidbody2D rigid;
    SpriteRenderer spriteRenderer;
    Animator anim;
    bool isJumping;
    UiManager uimanager;

    private void Start()
    {
        Time.timeScale = 1;
    }
    void Awake()
    {

        rigid = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        isJumping = false;
        uimanager = GetComponent<UiManager>();

        ps = () =>
        {
            StopGame();
        };

    }

    void Update()
    {
        //Jump
        if (Input.GetButtonDown("Jump") && !isJumping)
        {
            isJumping = true;
            rigid.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse); // 점프
        }
        // Stop Speed 
        if (Input.GetButtonUp("Horizontal"))
        {
            rigid.velocity = new Vector2(rigid.velocity.normalized.x * 0.5f, rigid.velocity.y);//float곱할때는 f붙여줘야한다.

        }

        // change Direction
        if (Input.GetButtonDown("Horizontal"))
            spriteRenderer.flipX = Input.GetAxisRaw("Horizontal") == -1;
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Floor")
        {
            isJumping = false;
        }
        if (collision.gameObject.tag == "Enemy")
        {
            OnDamaged(collision.transform.position);
            UiManager.php();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Item")
        {
            //코인 제거
            gameManager.stagePoint += 1;
            collision.gameObject.SetActive(false);
        }

        if (collision.gameObject.tag == "Finish")
        {
            //next stage
            gameManager.NextStage();
        }
    }

    void FixedUpdate()
    {
        // 이동
        float h = Input.GetAxisRaw("Horizontal");
        rigid.AddForce(Vector2.right * h, ForceMode2D.Impulse);

        if (rigid.velocity.x > maxSpeed)// rigid
            rigid.velocity = new Vector2(maxSpeed, rigid.velocity.y);
        else if (rigid.velocity.x < maxSpeed * (-1)) // Left Maxspeed
            rigid.velocity = new Vector2(maxSpeed * (-1), rigid.velocity.y);

        // 점프
        if (rigid.velocity.y < 0)
        {
            //Debug.DrawRay(rigid.position, Vector3.down, new Color(0, 1, 0)); //에디터 상에서만 레이를 그려준다
            RaycastHit2D rayHit = Physics2D.Raycast(rigid.position, Vector2.down, 1, LayerMask.GetMask("Platform"));
            if (rayHit.collider != null)
            {
                if (rayHit.distance < 0.5f)
                {
                    anim.SetBool("isJumping", false);
                }
            }
        }

    }


   

    void OnDamaged(Vector2 targetPos)
    {
        // health down
        gameManager.health--;

        gameObject.layer = 6;

        spriteRenderer.color = new Color(1, 1, 1, 0.4f);

        int dirc = transform.position.x - targetPos.x > 0 ? 1 : -1;
        rigid.AddForce(new Vector2(dirc,1)*6, ForceMode2D.Impulse);

        jumpPower = 0;
        Invoke("OffDamage", 3);
        Invoke("OffJump", 0.4f);
        
    }

    void OffDamage()
    {
        
        gameObject.layer = 7;
        spriteRenderer.color = new Color(1, 1, 1, 1);
    }

    void OffJump()
    {
        jumpPower = 14;
    }
    
    void StopGame()
    {
        Time.timeScale = 0;
    }
}
