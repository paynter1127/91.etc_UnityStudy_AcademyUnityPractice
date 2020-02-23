using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCtrl : MonoBehaviour
{
    GameObject target;

    //트렌스 폼 할 때 이런식으로 케시해서 쓰자. 속도가 빠르다. (유니티 기술 블로그에서 장려 + 속도테스트 빠르더라)
    private Transform mTransform = null;
    private Transform CachedTransform
    {
        get
        {
            if (mTransform == null) mTransform = transform;
            return mTransform;
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player");

        mTransform = CachedTransform;
    }


    // Update is called once per frame
    void Update()
    {
        //Vector3 originPosition = tr.position;
        Vector3 originPosition = CachedTransform.position;


        //Lerp : 선형 보간
        //Slerp : 곡선 보간
        CachedTransform.position = Vector3.Lerp(originPosition, 
            new Vector3(target.transform.position.x, target.transform.position.y, originPosition.z), 
            1.4f * Time.deltaTime);   
    }
}
