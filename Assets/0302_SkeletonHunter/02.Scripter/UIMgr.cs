using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIMgr : MonoBehaviour
{
    //싱글톤
    public static UIMgr instance = null;
    private void Awake()
    {
        if (instance == null) instance = this;
    }

    //델리게이트 - 부르고 싶은 함수의 반환형과 매개변수 타입이 같아야한다.
    delegate void OnButtonAction();
    //델리게이트 인스턴스화
    //인스턴스화된 변수를 통해 등록된 함수를 호출할 수 있다.
    OnButtonAction onButtonAction;

    public void RegistAction(SkeltonAI ai)
    {
        onButtonAction += ai.Die;
    }

    public void FuncTest()
    {
        onButtonAction();
    }




    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
}
