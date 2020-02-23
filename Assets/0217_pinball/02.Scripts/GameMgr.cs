using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameMgr : MonoBehaviour
{
    public Text textScore;

    public int score = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddScore(int add)
    {
        score += add;
        textScore.text = "Score : " + score;
    }


    //회전관련 힌지 조인트가 있다.
}
