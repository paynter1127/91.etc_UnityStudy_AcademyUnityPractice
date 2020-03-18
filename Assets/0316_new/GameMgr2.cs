using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;//화면 터치 관련 이벤트 처리

public class GameMgr2 : MonoBehaviour
{
    public Camera UIcam;
    Vector3 currPos;
    Vector3 prevPos;
    float dis;


    public Text textName;
    public Text textLevel;
    public Text textAttack;

    // Start is called before the first frame update
    void Start()
    {
        textName.text = "이름 : " + DataMgr.Instance.Datas.name;
        textLevel.text = "레벨 : " + DataMgr.Instance.Datas.level;
        textAttack.text = "공격력 : " + DataMgr.Instance.Datas.attack;
    }

    // Update is called once per frame
    void Update()
    {
        //터치 처리
#if (UNITY_ANDROID || UNITY_IPHONE)

        
        if (Input.touchCount > 0)
        {
            if(Input.touches[0].phase == TouchPhase.Began)
            {
                currPos = Input.touches[0].position;
            }
            else if(Input.touches[0].phase == TouchPhase.Canceled)
            {
                currPos = Vector3.zero;
                dis = 0f;
            }

            if (Input.touches[1].phase == TouchPhase.Began)
            {
                prevPos = Input.touches[1].position;
                dis = prevPos.x - currPos.x;
            }
            else if (Input.touches[1].phase == TouchPhase.Canceled)
            {
                prevPos = Vector3.zero;
                dis = 0f;
            }


            if (Input.touches[0].phase == TouchPhase.Moved &&
                Input.touches[1].phase == TouchPhase.Moved)
            {
                Input.touches[1].position.x - Input.touches[0].position.x;

                //확대
                UIcam.orthographicSize -= (dis / 32) * Time.deltaTime;
            }

        }

       
#else
        if (EventSystem.current.IsPointerOverGameObject()) //UI위에 올라 갔는지 체크
        {

        }
        else//UI에 걸리지 않으면 아래 조건문 진행
        {

            Ray ray = UIcam.ScreenPointToRay(Input.mousePosition); //3D 월드의 레이
            RaycastHit hit;
            if (Physics.Raycast(ray.origin, ray.direction, 100f, 1 << LayerMask.NameToLayer("TouchObject")))
            {
                //아이템 획득

            }


            //pc
            if (Input.GetMouseButtonDown(0))
            {
                currPos = Input.mousePosition;
            }
            else if (Input.GetMouseButtonUp(0))
            {
                currPos = Vector3.zero;
                prevPos = Vector3.zero;
            }

            if (Input.GetMouseButton(0) && currPos.magnitude > 0)
            {
                prevPos = Input.mousePosition;
                float x = prevPos.x - currPos.x;

                //확대
                UIcam.orthographicSize -= (x / 32) * Time.deltaTime;
            }

        }


#endif
    }
}
