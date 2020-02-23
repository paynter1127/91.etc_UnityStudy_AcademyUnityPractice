using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UnitoInputCtrl : MonoBehaviour
{
    Rigidbody rb;
    Transform tr;
    SphereCollider sc;
    public Animation anim;

    float jumpPower = 0f;
    public float addPower = 500.0f;
    float maxPower = 700.0f;

    //float highest = 0f;

    bool isChechDown = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        tr = GetComponent<Transform>();
        sc = GetComponent<SphereCollider>();
        anim = GetComponent<Animation>();

        anim.Play("01_Idle");
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButton(0))
        {
            jumpPower += (addPower * Time.deltaTime);
            if (jumpPower >= maxPower) jumpPower = maxPower;
        }
        else if(Input.GetMouseButtonUp(0))
        {
            rb.AddForce(jumpPower, jumpPower, 0f);
            jumpPower = 0f;

            //anim.Play("03_jumpup");
            anim.CrossFade("03_jumpup", 0.2f);
            isChechDown = true;
        }

        //리지드바디의 벨로시티 값을 통해 동체의 진행 방향을 알 수 있다.
        if(rb.velocity.y < 0f && isChechDown)
        {
            //anim.Play("04_jumpdown");
            anim.CrossFade("04_jumpdown", 0.2f);
            isChechDown = false;
        }

        //애니메이션 처리
        //정점 구해라
        //if (highest <= tr.position.y)
        //{
        //    highest = tr.position.y;
        //}
        //if(highest > tr.position.y)
        //{
        //    anim.Play("04_jumpdown");
        //}



        //누르면 짜부 되게 처리
        float ratio = 1.0f - (jumpPower / maxPower);
        ratio = Mathf.Clamp(ratio, 0.4f, 1f);
        tr.localScale = new Vector3(tr.localScale.x, ratio, tr.localScale.z);
        sc.radius = ratio;

        if(tr.position.y < - 5.0f)
        {
            SceneManager.LoadScene(1);
        }
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Block")
        {
            //anim.Play("01_Idle");
            anim.CrossFade("01_Idle", 0.2f);
            //rb.Sleep(); //벨로시티값을 초기화 잘 안된다.
            rb.velocity = new Vector3();

            collision.gameObject.GetComponent<CubeCtrl>().timeAttack = true;
        }   
    }



    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Block")
        {
            try
            {
                collision.gameObject.GetComponent<CubeCtrl>().Drop();
            }
            catch
            {
                Debug.Log("Drop() 함수를 호출 할 수 없다!!");
            }

        }
    }


}
