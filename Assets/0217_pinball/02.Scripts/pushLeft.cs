using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pushLeft : MonoBehaviour
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
        PushLeftArm();
    }


    void PushLeftArm()
    {
        if (Input.GetKey(KeyCode.LeftArrow)) //완료
        {
            if (tr.eulerAngles.z > 30 && tr.eulerAngles.z < 40)
            {
                tr.eulerAngles = new Vector3(0, 0, 30);
            }
            if (tr.eulerAngles.z >= 330 && tr.eulerAngles.z < 360)
            {
                tr.Rotate(Vector3.forward, pushPower * Time.deltaTime);
            }
            if (tr.eulerAngles.z < 30 && tr.eulerAngles.z > 0)
            {
                tr.Rotate(Vector3.forward, pushPower * Time.deltaTime);
            }
        }
        else
        {
            tr.Rotate(Vector3.forward, -returnPower * Time.deltaTime);
            if (tr.eulerAngles.z < 330 && tr.eulerAngles.z > 30)
            {
                tr.eulerAngles = new Vector3(0, 0, 330);
            }
            //Debug.Log(tr.eulerAngles.z);
        }
    }
}
