using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    Rigidbody2D rigid;
    public float maxSpeed;
    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    //�ﰢ���� Ű �Է�, Ű���忡 ���� ���� ��
    private void Update()
    {
        if (Input.GetButtonUp("Horizontal"))
        {
            rigid.velocity = new Vector2(rigid.velocity.normalized.x * 0.5f, rigid.velocity.y);
        }
    }

    private void FixedUpdate()
    {
        float h = Input.GetAxisRaw("Horizontal");

        rigid.AddForce(Vector2.right * h, ForceMode2D.Impulse);

        if(rigid.velocity.x > maxSpeed)
        {
            rigid.velocity = new Vector2(maxSpeed, rigid.velocity.y);
        } else if(rigid.velocity.x < maxSpeed * (-1))
        {
            rigid.velocity = new Vector2(maxSpeed * (-1), rigid.velocity.y);
        }
    }
}
