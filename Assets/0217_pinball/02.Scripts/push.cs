using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class push : MonoBehaviour
{
    Transform tr;
    float pushPower = 160;
    float returnPower = 90;

    // Start is called before the first frame update
    void Start()
    {
        tr = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        PushRightArm();
    }


    void PushRightArm()
    {
        if (Input.GetKey(KeyCode.RightArrow)) //완료
        {
            tr.Rotate(Vector3.forward, -pushPower * Time.deltaTime);
            if (tr.eulerAngles.z < 330 && tr.eulerAngles.z > 30)
            {
                tr.eulerAngles = new Vector3(0, 0, 330);
            }
        }
        else
        {
            if (tr.eulerAngles.z > 30 && tr.eulerAngles.z < 40)
            {
                tr.eulerAngles = new Vector3(0, 0, 30);
            }
            if (tr.eulerAngles.z >= 330 && tr.eulerAngles.z < 360)
            {
                tr.Rotate(Vector3.forward, returnPower * Time.deltaTime);
            }
            if (tr.eulerAngles.z < 30 && tr.eulerAngles.z > 0)
            {
                tr.Rotate(Vector3.forward, returnPower * Time.deltaTime);
            }
        }
    }
}
