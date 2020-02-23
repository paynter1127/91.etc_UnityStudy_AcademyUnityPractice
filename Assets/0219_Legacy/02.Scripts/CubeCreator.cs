using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using paynter.LevelData;

public class CubeCreator : MonoBehaviour
{
    public GameObject prefCube;
    Vector3 startPosition;

    GameObject lastCube;
    GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        startPosition = new Vector3(0, 0, 0);
        lastCube = Instantiate(prefCube, startPosition, Quaternion.identity);

    }

    // Update is called once per frame
    void Update()
    {
        

        //큐브 만들어 주는 부분
        if (lastCube.transform.position.x < player.transform.position.x + 5)
        {
            int lastPosX = (int)lastCube.transform.position.x;
            for(int i = 0; i < 5; i++)
            {
                lastCube = Instantiate(prefCube,
                    new Vector3(lastPosX + 1 + i,
                    lastCube.transform.position.y,
                    lastCube.transform.position.z),
                    Quaternion.identity);
            }
        }
    }
}
