using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// idle 상태에서 2초 동안 대기
// 랜덤하게 계속 대기
// 랜덤한 위치로 이동을 한다

// walk 상태에서 3초간 이동
//적을 찾는다.
// 적을 찾으면 run 상태로 전환
// 못 찾으면 idle 상태로 전환

// run 상태는 적에게 접근
// 거리가 사정거리 이내면 attack 상태로 전환
// 2초 동안 접근 했는데 사정거리 안에 안 들어오면 idle 상태로 전환

//attack 상태는 공격 애니메이션 나오고
//idle 상태로 전환

public enum EnemyState : int
{
    Idle, Walk, Run, Attack, Death, Hide
}

public class SkeltonAI : MonoBehaviour
{
    Camera eye;//에너미 시야
    public GameObject target;
    bool isFindE = false;

    EnemyState state;
    EnemyState nextState;

    Vector3 targetPos;
    public float moveSpeed = 1f;
    public float rotationSpeed = 20f;

    Animator anim;

    

    // Start is called before the first frame update
    void Start()
    {

        state = EnemyState.Idle;
        anim = GetComponent<Animator>();
        eye = transform.GetComponentInChildren<Camera>();

        StartCoroutine(CoroutineIdle());
        //StartCoroutine("CoroutinIdle"); //스트링으로 호출
        //
        //StopCoroutine("CoroutinIdle"); //스탑 코루틴은 스트링으로 멈출 수 있으나 함수로는 못멈춘다
        //
        //StopAllCoroutines(); //모든 코루틴 종료 시키는 것
    }

    // Update is called once per frame
    void Update()
    {
        //if(Input.GetKeyDown(KeyCode.LeftArrow))
        //{
        //    anim.SetBool("isWalk", true);
        //}
        //else if(Input.GetKeyDown(KeyCode.RightArrow))
        //{
        //    anim.SetBool("isWalk", false);
        //}

        switch(state)
        {
            case EnemyState.Idle: UpdateIdle(); break;
            case EnemyState.Walk: UpdateWalk(); break;
            case EnemyState.Run: UpdateRun(); break;
            case EnemyState.Attack: UpdateAttack(); break;
            case EnemyState.Death: UpdateDeath(); break;
            case EnemyState.Hide: UpdateHide(); break;
        }

    }

    


    // idle 상태에서 2초 동안 대기
    // 랜덤하게 계속 대기
    // 랜덤한 위치로 이동을 한다
    void UpdateIdle()
    {
        //매 프레임 해야하는 실행문
        if(IsFindEnemy())
        {
            ChangeState(EnemyState.Run);
            return;
        }
    }

    void UpdateWalk()
    {
        //if(state != EnemyState.Walk) ChangeState(EnemyState.Walk);

        if (IsFindEnemy())
        {
            ChangeState(EnemyState.Run);
            return;
        }

        //타겟 방향
        Vector3 dir = targetPos - transform.position;
        //dir.Normalize();

        //도착 여부 판별
        if (Vector3.Distance(targetPos, transform.position) < 0.2f)
        {
            ChangeState(EnemyState.Idle);
            return;
        }

        var targetRotation = Quaternion.LookRotation(dir, Vector3.up);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

        transform.position += transform.forward * moveSpeed * Time.deltaTime;
        //tr.position += new Vector3(1 * Time.deltaTime, 0, 0);

    }

    void UpdateRun()
    {

    }

    void UpdateAttack()
    {

    }

    void UpdateDeath()
    {

    }

    private void UpdateHide()
    {

    }


    void ChangeState(EnemyState _state)
    {
        state = _state;

        anim.SetBool("isIdle", false);
        anim.SetBool("isWalk", false);
        anim.SetBool("isRun", false);
        anim.SetBool("isAttack", false);
        anim.SetBool("isDeath", false);

        StopAllCoroutines();
        switch(state)
        {
            case EnemyState.Idle: StartCoroutine(CoroutineIdle()); break;
            case EnemyState.Walk: StartCoroutine(CoroutineWalk()); break;
            case EnemyState.Run: StartCoroutine(CoroutineRun()); break;
            case EnemyState.Attack: StartCoroutine(CoroutineAttack()); break;
            case EnemyState.Death: StartCoroutine(CoroutineDeath()); break;
            case EnemyState.Hide: StartCoroutine(CoroutineHide()); break;
        }
    }

    

    IEnumerator CoroutineIdle()
    {
        //스테이트가 바뀔 때 한번만 실행되는 동작
        anim.SetBool("isIdle", true);

        int randState = UnityEngine.Random.Range(1, 2);
        switch(randState)
        {
            case 0: nextState = EnemyState.Idle; break;
            case 1: nextState = EnemyState.Walk; break;
        }

        //아이들일 때 2초 대기
        while (true)
        {
            Debug.Log("A_idle");
            yield return new WaitForSeconds(2.0f);
            Debug.Log("B_idle");

            ChangeState(nextState);
        }
        
        //yield break;

        //특정 시간이나 조건에 따라 반복되는 실행문
        //while (true)
        //{
        //    Debug.Log("A");
        //    yield return new WaitForSeconds(3.0f);
        //    Debug.Log("B");
        //    yield return new WaitForSeconds(3.0f);
        //
        //    yield return null;//한 프레임??
        //}
        //yield break;
    }

    IEnumerator CoroutineWalk()
    {
        //스테이트가 바뀔 때 한번만 실행되는 동작
        anim.SetBool("isWalk", true);

        targetPos = transform.position + new Vector3(UnityEngine.Random.Range(-4f, 4f), 0f, UnityEngine.Random.Range(-4f, 4f));

        //아이들일 때 2초 대기
        while (true)
        {
            Debug.Log("A_walk");
            yield return new WaitForSeconds(3.0f);
            Debug.Log("B_walk");

            ChangeState(nextState);
        }
    }

    IEnumerator CoroutineRun()
    {
        anim.SetBool("isRun", true);
        
        yield break;
    }

    IEnumerator CoroutineAttack()
    {
        yield break;
    }

    IEnumerator CoroutineDeath()
    {
        yield break;
    }

    IEnumerator CoroutineHide()
    {
        while(true)
        {
            yield return new WaitForSeconds(2f);
            ChangeState(EnemyState.Idle);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            isFindE = true;
            target = other.gameObject;
        }
    }

    bool IsFindEnemy()
    {
        //타겟이 있을 때 일정거리 안에 있으면 찾았다.
        Bounds bounds = target.GetComponentInChildren<SkinnedMeshRenderer>().bounds;
        //eye 대상 캐릭터의 머리에 붙인 카메라
        Plane[] planes = GeometryUtility.CalculateFrustumPlanes(eye);
        isFindE = GeometryUtility.TestPlanesAABB(planes, bounds); //카메라 영역 안이면 찾는다

        //적과 본인 사이에 벽이 있는지 확인
        RaycastHit hit;
        if(Physics.Raycast(transform.position, transform.forward, out hit, 10f,
            1 << LayerMask.NameToLayer("Wall")))
            //1을 wall레이어의 번호만큼 왼쪽으로 옮긴다.
        {
            float distTarget = Vector3.Distance(transform.position, target.transform.position);
            if (distTarget > hit.distance) return false;
        }

        return isFindE;
    }
}
