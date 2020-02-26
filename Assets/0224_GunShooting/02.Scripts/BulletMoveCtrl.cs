using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMoveCtrl : MonoBehaviour
{
    Rigidbody rg;
    Transform tr;

    public float moveSpeed = 4f;

    // Start is called before the first frame update
    void Start()
    {
        rg = GetComponent<Rigidbody>();
        tr = GetComponent<Transform>();

        //Destroy(gameObject, 3f);
    }

    // Update is called once per frame
    void Update()
    {
        //내가 한 add 포스
        //rg.AddForce(tr.forward * 50);
        //썜
        tr.position += tr.forward * moveSpeed * Time.deltaTime;
    }
}
