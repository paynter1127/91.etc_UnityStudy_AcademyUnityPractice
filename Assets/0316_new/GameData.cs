using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable] //이게 없으면 인스펙터 창에서 데이터를 확인 할 수 없다.
public class GameData //Serializable 인스펙터 창에 보여 줄 준비를 하세요 라는 의미인듯
{
    public string name;
    public int level;
    public float attack;
}
