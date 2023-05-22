using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    Rigidbody2D rigid;
    public float maxSpeed;
    public float jumpPower;
    SpriteRenderer spriteRenderer;
    Animator anim;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        rigid.freezeRotation = true;
        spriteRenderer = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }
    //�ﰢ���� Ű �Է�, Ű���忡 ���� ������
    private void Update()
    {
        if (Input.GetButtonUp("Horizontal"))
        {
            rigid.velocity = new Vector2(rigid.velocity.normalized.x * 0.5f, rigid.velocity.y);
        }

        //������ȯ flip
        if (Input.GetButtonDown("Horizontal"))
        {
            spriteRenderer.flipX = (Input.GetAxisRaw("Horizontal")) == -1;
        }

        //����
        if (Input.GetButtonDown("Jump"))
        {
            rigid.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
        }
        
        //�ִϸ��̼�
        if (Mathf.Abs(rigid.velocity.x) < 0.3)
        {
            anim.SetBool("isWalk", false);
        } else
        {
            anim.SetBool("isWalk", true);
        }
    }


    private void FixedUpdate()
    {
        float h = Input.GetAxisRaw("Horizontal");

        rigid.AddForce(Vector2.right * h, ForceMode2D.Impulse);

        if (rigid.velocity.x > maxSpeed)
        {
            rigid.velocity = new Vector2(maxSpeed, rigid.velocity.y);
        }
        else if (rigid.velocity.x < maxSpeed * (-1))
        {
            rigid.velocity = new Vector2(maxSpeed * (-1), rigid.velocity.y);

        }
    }
}