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
    //float turn = 0;
    //float turnSpeed = 0f;

    // Start is called before the first frame update
    void Start()
    {
        //mTransform = cachedTransform;

        moveSpeed = 8f;
        //turnSpeed = 180f;
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

        //위치 이동
        //rb.velocity = new Vector3(xSpeed, 0f, zSpeed);
        //rb.velocity = new Vector3(xSpeed, 0f, zSpeed);//절대 좌표인데, 이걸 상대 좌표로 변경을 못하겠다.

        Vector3 aa = new Vector3(xSpeed, 0f, zSpeed);
        


        //트렌스폼 처리는 easy
        //transform.position += transform.forward * zSpeed * Time.deltaTime;
        //transform.position += transform.right * xSpeed * Time.deltaTime;


        //회전 처리 할 땐 트렌스폼에서 처리 해라(예외상황이 적다)

        //회전 처리
        if (Input.GetKey(KeyCode.Q))//좌회전
        {
            //rb.AddTorque(Vector3.up);
            //rb.AddTorque(new Vector3(0f, -10f, 0f));
            //turn -= turnSpeed * Time.deltaTime;

            transform.Rotate(0f, -30f * Time.deltaTime, 0f);
        }
        else if (Input.GetKey(KeyCode.E))
        {
            //rb.AddTorque(new Vector3(0f, 10f, 0f));
            //turn += turnSpeed * Time.deltaTime;
            transform.Rotate(0f, 30f * Time.deltaTime, 0f);
        }
        //rb.rotation = Quaternion.Euler(0f, turn, 0f);

    }


}
