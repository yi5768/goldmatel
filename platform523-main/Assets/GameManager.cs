using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int totalPoint; //��������
    public int stagePoint; //�������� ���� ����
    public int stageIndex; //�������� ��ȣ
    public int health;

    //������ ���������� �����Ѵ�
    public void NextStage()
    {
        stageIndex += stagePoint;
        stagePoint = 0;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            health--;

            //�÷��̾� ������
            collision.attachedRigidbody.velocity = Vector2.zero;
            collision.transform.position = new Vector3(-4, 3, -1);
        }
    }

}
