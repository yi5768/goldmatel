using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int totalPoint; //현재점수
    public int stagePoint; //스테이지 상의 점수
    public int stageIndex; //스테이지 번호
    public int health;

    //점수와 스테이지를 관리한다
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

            //플레이어 리스폰
            collision.attachedRigidbody.velocity = Vector2.zero;
            collision.transform.position = new Vector3(-4, 3, -1);
        }
    }

}
