using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int totalPoint; //��������
    public int stagePoint; //�������� ���� ����
    public int stageIndex; //�������� ��ȣ
    public int health;
    public PlayerMove player;
    public GameObject[] Stages;

    //������ ���������� �����Ѵ�
    public void NextStage()
    {
        if(stageIndex < Stages.Length - 1)
        {
            Stages[stageIndex].SetActive(false);
            stageIndex++;
            Stages[stageIndex].SetActive(true);
            PlayerReposition();
        }
        else
        {
            //���� Ŭ����
            Time.timeScale = 0;
            //��� UI
            Debug.Log("GAME CLEAR");
            //����� ��ư UI

        }

        stageIndex += stagePoint;
        stagePoint = 0;
    }

    public void HealthDown()
    {
        if(health > 1) 
            health--;
        else
        {
            //�÷��̾� ���� ����Ʈ
            player.OnDie();
            //��� UI
            Debug.Log("YOU DIE");
            //�ٽý��� ��ư UI

        }
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {   //�÷��̾� ������
            if (health > 1)
            {
                PlayerReposition();
            }
            HealthDown();
        }   
    }

    //�÷��̾� ������ �Լ� �����
    void PlayerReposition()
    {
        player.transform.position = new Vector3(-4, 3, -1);
        player.velocityZero();
    }

}
