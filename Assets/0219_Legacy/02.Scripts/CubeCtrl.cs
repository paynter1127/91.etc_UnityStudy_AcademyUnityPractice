using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeCtrl : MonoBehaviour
{
    Rigidbody rb;
    Material mat;

    public bool timeAttack = false;

    private void Awake()
    {
        mat = GetComponent<MeshRenderer>().material;

        rb = GetComponent<Rigidbody>();
        rb.useGravity = false;
        rb.isKinematic = true;
        
    }

    private void Update()
    {
        if (timeAttack)
        {
            if (mat.color.a > 0f)
            {
                //컬러값을 직접 바꿀 수 없기 때문에 이와 같이 처리
                float alpha = mat.color.a - (Time.deltaTime / 3.0f); //3초간 알파 감소
                mat.color = new Color(mat.color.r, mat.color.g, mat.color.b, alpha);
            }
            else
            {
                timeAttack = false;
                Destroy(this.gameObject, 0.2f);
            }
        }
    }

    public void Drop()
    {
        rb.useGravity = true;
        rb.isKinematic = false;

        //3초 뒤에 사라지도록
        Destroy(this.gameObject, 3f);
    }


}
