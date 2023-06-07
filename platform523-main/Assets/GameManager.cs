using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int totalPoint; //현재점수
    public int stagePoint; //스테이지 상의 점수
    public int stageIndex; //스테이지 번호
    public int health;
    public PlayerMove player;
    public GameObject[] Stages;

    //점수와 스테이지를 관리한다
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
            //게임 클리어
            Time.timeScale = 0;
            //결과 UI
            Debug.Log("GAME CLEAR");
            //재시작 버튼 UI

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
            //플레이어 죽음 이팩트
            player.OnDie();
            //결과 UI
            Debug.Log("YOU DIE");
            //다시시작 버튼 UI

        }
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {   //플레이어 리스폰
            if (health > 1)
            {
                PlayerReposition();
            }
            HealthDown();
        }   
    }

    //플레이어 리스폰 함수 만들기
    void PlayerReposition()
    {
        player.transform.position = new Vector3(-4, 3, -1);
        player.velocityZero();
    }

}
