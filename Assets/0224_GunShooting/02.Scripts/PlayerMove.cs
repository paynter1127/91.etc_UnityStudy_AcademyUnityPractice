using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//과제 : 주변에 포탑 만들어 물리 총알을 플레이어에게 발사 하기
//플레이어는 회전을 하면서 주변 포탑을 피하며 전투 할 수 있도록 처리

public class PlayerMove : MonoBehaviour
{

    Transform mTransform = null;
    Transform cachedTransform
    {
        get
        {
            if (mTransform == null) mTransform = transform;
            return mTransform; 
        }
    }

    Rigidbody rb;
    public GameObject gun;

    float moveSpeed = 0f;

    // Start is called before the first frame update
    void Start()
    {
        mTransform = cachedTransform;

        moveSpeed = 8f;
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //건 컨트롤에서 해당 엑티브 행동을 처리 하지 않았다.
        //이유는 주체인 플레이어가 해당 행동을 한다 를 코드상으로 표현 한 것
        if(Input.GetMouseButtonDown(0))
        {
            //건 컨트롤로 접근하여 파이어 함수를 호출
            gun.GetComponent<GunCtrl>().Fire();

        }

        float xInput = Input.GetAxis("Horizontal");
        float zInput = Input.GetAxis("Vertical");

        float xSpeed = xInput * moveSpeed;
        float zSpeed = zInput * moveSpeed;

        rb.velocity = new Vector3(xSpeed, 0f, zSpeed);

       // if(Input.GetKey(KeyCode.LeftArrow))
       // {
       //
       // }
       // else if(Input.GetKey(KeyCode.RightArrow))
       // {
       //
       // }
        
    }
}
