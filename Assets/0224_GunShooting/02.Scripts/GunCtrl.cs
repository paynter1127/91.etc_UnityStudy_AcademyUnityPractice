using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunCtrl : MonoBehaviour
{
    public GameObject prefDamageEffect;

    Transform mTransform = null;
    Transform firePos;

    public float damage = 25f;
    private float fireDist = 50;

    public float timeBetFire = 0.15f;
    private float timeLastFire;

    // Start is called before the first frame update
    void Start()
    {
        //자식 관계에 있는 오브젝트 찾을 때 transform.Find
        firePos = transform.Find("FirePos");
        timeLastFire = 0f;
    }


    public void Fire()
    {
        //총알 발사 간격 처리 timeBetFire 수치 만큼 겝을 만들어 준다. 
        if(Time.time >= timeLastFire + timeBetFire)
        {
            Shot();
            timeLastFire = Time.time;
        }
    }

    private void Shot()
    {
        RaycastHit hit;

        //out 은 리턴하는 명령어. 레퍼런스로의 접근과 비슷
        if(Physics.Raycast(firePos.position, firePos.forward, out hit, fireDist))
        {
            //I는 인터페이스를 의미
            /*
             *인터페이스는 특정 기능을 구현할 것을 약속한 추상 형식을 말합니다. 
             * Java나 C# 등의 다른 OOP언어에서는 인터페이스 형식을 제공합니다. 
             * C++언어에서는 인터페이스 형식을 제공하지는 않지만 순수 가상 메서드를 이용하여 정의할 수 있습니다.
             */

            //wall 로 받아도 되지만 IDamageable 인터페이스를 상속받은 오브젝트 모두를 대상으로 하기 위해 인터페이스 사용
            IDamageable target = hit.collider.GetComponent<IDamageable>();
            //IDamageable target = hit.collider.GetComponent<Wall>();

            if(target != null)
            {
                //float damage, vector3 hitPoint, vector3 hitNormal
                target.OnDamage(damage, hit.point, hit.normal);

                //이펙트 호출
                Instantiate(prefDamageEffect, hit.point, Quaternion.identity);
            }

        }
    }
}
