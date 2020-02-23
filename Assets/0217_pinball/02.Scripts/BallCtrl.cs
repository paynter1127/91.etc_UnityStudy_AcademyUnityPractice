using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallCtrl : MonoBehaviour
{
    public float moveSpeed = 4.0f;

    Transform tr;

    // Start is called before the first frame update
    void Start()
    {
        tr = GetComponent<Transform>(); //꺽쇠는 c++에서는 템플릿, C#에서는 제너릭 이라 한다. 
    }

    // Update is called once per frame
    void Update() //매 프레임 도는것(성능에 따라 바뀐다. 1초에 200프레임 이상으로도 가능)
    {
        if(Input.GetKey(KeyCode.A))
        {
            //c#에서 new 사용 이유 
            //값형식과 레퍼런스 형식 두가지로 나뉜다.
            //int, float, struct 등 빼면 전부 레퍼런스 형식이다. 
            //c++ 에서 메모리 동적할당과 같은데, 레퍼런스 형식은 동적할당 받아서 사용할 수 있는 것.
            //C#은 포인터를 더 넓고 광범위하게 사용하고 있고, 이때문에 가비지 컬렉터가 유용해진다.
            //컴포넌트 받아오는것도 역시 레퍼런스 형식이기 때문에 주소를 받아오는 것!!!!
            tr.position = new Vector3(tr.position.x - moveSpeed * Time.deltaTime, tr.position.y, tr.position.z);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            tr.position = new Vector3(tr.position.x + moveSpeed * Time.deltaTime, tr.position.y, tr.position.z);
        }
        //Time.deltaTime
        //은 프레임 사이의 시간 간격을 의미
        //각 프레임 사이의 시간은 각각 다 다르다. 때문에 time.deltatime에 들어오는 각 프레임 간격도 다 다르다. 
        //time.deltatime 은 1초 사이에 몇 프레임인지는 모르지만 각 프레임 사이의 값을 받아오는 것이고, 
        //이 때문에 1초간 일어난 델타타임을 합치면 1초가 된다. 

        if(Input.GetKey(KeyCode.Space))
        {
            GetComponent<Rigidbody>().useGravity = true;
        }
    }
}




