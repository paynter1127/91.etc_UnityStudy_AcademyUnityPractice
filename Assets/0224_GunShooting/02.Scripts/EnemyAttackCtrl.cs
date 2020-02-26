using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//길어지는 if 문 관리하기 위해
public enum AttackPattern
{
    Wait, Attack, Rotation
}

public class EnemyAttackCtrl : MonoBehaviour
{
    public GameObject prefBullet; //성 총알

    [SerializeField]
    AttackPattern pattern = AttackPattern.Wait;

    //발사
    public float attackRate = 1.5f; //총 쏘는 간격

    //회전
    //Transform tr;
    public float rotationSpeed = 10f;
    public float rotationRate = 2f;
    private float timeRotation;
    private float timeWait;

    //대기
    public float waitRate = 1f;
    //bool isRotate = false;

    [SerializeField]
    EnemyFirePos[] firePosition; //총구 네개


    // Start is called before the first frame update
    void Start()
    {
        //총구 찾아 오기
        //firePosition = transform.Find("FirePos"); //이건 하나 밖에 못찾는다.
        
        //EnemyFirePos 라는 스크립트가 붙은 모든 오브젝트를 찾오 오는 방법
        firePosition = gameObject.GetComponentsInChildren<EnemyFirePos>();

        //타워 트렌스폼
        //tr = GetComponent<Transform>();

        timeRotation = 0f;
        timeWait = 0f;
    }

    // Update is called once per frame
    void Update()
    {

        /*
        timeAttack += Time.deltaTime;

        if(timeAttack >= attackRate)
        {
            //발사
            foreach(var firePos in firePosition)
            {
                Transform trFirePos = firePos.gameObject.transform;
                Instantiate(prefBullet, trFirePos.position, trFirePos.rotation);
            }
            timeAttack = 0f;
            isRotate = true;
        }

        //내가 짠 회전 처리
        if(timeAttack >= attackRate / 2 && isRotate)
        {
            angle += 30;
            tr.rotation = Quaternion.Euler(0f, angle, 0f);
            isRotate = false;
        }
        */

        if(pattern == AttackPattern.Wait)
        {
            if(timeWait < waitRate)
            {
                timeWait += Time.deltaTime;
            }
            else
            {
                pattern = AttackPattern.Rotation;
            }
        }
        else if(pattern == AttackPattern.Attack)
        {
            //발사
            foreach (var firePos in firePosition)
            {
                Transform trFirePos = firePos.gameObject.transform;

                //새로 생성해서 발사
                //Instantiate(prefBullet, trFirePos.position, trFirePos.rotation);

                ObjectPooler.instance.SpawnFromPool("EnemyBullet", trFirePos.position, trFirePos.rotation);
            }

            pattern = AttackPattern.Wait;

            //초기화
            timeRotation = 0f;
            timeWait = 0f;
        }
        else if(pattern == AttackPattern.Rotation)
        {
            if(timeRotation < rotationRate)
            {
                timeRotation += Time.deltaTime;
                transform.Rotate(transform.up, rotationSpeed * Time.deltaTime);
            }
            else
            {
                pattern = AttackPattern.Attack;
            }
        }

    }

    //총 쏘기
    void Fire()
    {
        //총알 발사 간격 처리 timeBetFire 수치 만큼 겝을 만들어 준다. 
        //if (Time.time >= timeLastFire + timeBetFire)
        //{
        //    timeLastFire = Time.time;
        //    Instantiate(prefBullet, firePos.position, firePos.rotation);
        //}
    }

}
