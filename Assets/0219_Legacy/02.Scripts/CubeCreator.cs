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

    int addLevel = 0;

    LevelCtrl Level;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        startPosition = new Vector3(0, 0, 0);
        lastCube = Instantiate(prefCube, startPosition, Quaternion.identity);

        Level = gameObject.GetComponent<LevelCtrl>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            addLevel++;
            Debug.Log("레벨 : " + addLevel);
        }

        if(Time.time > Level.listLevelData[addLevel + 1].time)
        {
            Debug.Log(Time.time);
            addLevel++;
        }

        if (addLevel > 4) addLevel = 4;
        //Debug.Log(Time.time);

        //if (Input.GetKeyDown(KeyCode.Return))
        //{
        //    int a = Random.Range(9, 11);
        //    Debug.Log(a);
        //}

        //큐브 만들어 주는 부분
        if (lastCube.transform.position.x < player.transform.position.x + 5)
        {
            int lastPosX = (int)lastCube.transform.position.x;

            
            int floorNum = Random.Range(Level.listLevelData[addLevel].floorMin, Level.listLevelData[addLevel].floorMax + 1);
            int holeGap = Random.Range(Level.listLevelData[addLevel].holeMin, Level.listLevelData[addLevel].holeMax + 1);
            
            //Debug.Log("박스/홀겝/높이 : " + floorNum + "/" + holeGap + "/" + height);

            for (int i = 0; i < floorNum; i++)
            {
                int height = Random.Range(Level.listLevelData[addLevel].heightMin, Level.listLevelData[addLevel].heightMax + 1);

                lastCube = Instantiate(prefCube,
                    new Vector3(lastPosX + holeGap + i,
                    height,
                    lastCube.transform.position.z),
                    Quaternion.identity);
            }
        }
    }
}
