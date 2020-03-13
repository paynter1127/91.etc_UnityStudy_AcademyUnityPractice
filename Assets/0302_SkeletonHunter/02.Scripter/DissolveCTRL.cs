using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DissolveCTRL : MonoBehaviour
{
    

    public enum State
    {
        HIDE_ON, HIDE_OFF
    }

    [SerializeField]
    State state = State.HIDE_OFF;

    public Material mat;

    // Start is called before the first frame update
    void Start()
    {
        mat = GetComponent<Renderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        switch(state)
        {
            case State.HIDE_OFF: UpdateHideOff(); break;
            case State.HIDE_ON: UpdateHideOn(); break;
        }
    }


    void UpdateHideOff()
    {
        float dissolveAmount = mat.GetFloat("_DissolveAmount");
        if(dissolveAmount > 0f)
        {
            mat.SetFloat("_DissolveAmount", dissolveAmount - (0.5f * Time.deltaTime));
        }
        else
        {
            mat.SetFloat("_DissolveAmount", 0f);
        }
    }

    void UpdateHideOn()
    {
        float dissolveAmount = mat.GetFloat("_DissolveAmount");
        if (dissolveAmount < 1f)
        {
            mat.SetFloat("_DissolveAmount", dissolveAmount + (0.5f * Time.deltaTime));
        }
        else
        {
            mat.SetFloat("_DissolveAmount", 1f);
        }
    }

    public void ChangeState(State _state)
    {
        state = _state;
    }
}
