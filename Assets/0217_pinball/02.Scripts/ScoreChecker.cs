using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreChecker : MonoBehaviour
{
    GameMgr gameMgr;

    // Start is called before the first frame update
    void Start()
    {
        //게임 매니저 스크립트 받아 오기 !!!!
        gameMgr = GameObject.Find("GameMgr").GetComponent<GameMgr>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //온 콜리전 엔터 - 온 트리거 엔터
    //트리거가 체크가 안되어 있으면 콜리전 엔터 호출을 하고,
    //트리거 체크 되어 있으면 트리거 엔터를 호출한다.

    //트리거 세개
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Ball")
        {
            gameMgr.AddScore(10);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        
    }

    private void OnTriggerExit(Collider other)
    {
        
    }



    //콜리전 세개
    private void OnCollisionEnter(Collision collision)
    {
        
    }

    private void OnCollisionStay(Collision collision)
    {
        
    }

    private void OnCollisionExit(Collision collision)
    {
        
    }
}
