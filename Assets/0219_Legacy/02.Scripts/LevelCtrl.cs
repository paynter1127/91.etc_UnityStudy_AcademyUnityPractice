using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace paynter.LevelData
{
    //외부 텍스트 데이터 받아올 구조체
    public struct ST_LEVEL_DATA
    {
        public float time;
        public float speed;
        public int floorMin;
        public int floorMax;
        public int holeMin;
        public int holeMax;
        public int heightMin;
        public int heightMax;
    }

    //C++에서는 구조체와 클래스의 차이는 없다(상속도 되고 다 된다.) 단, 접근 지정자만 다르다(new 안쓰면 클래스도 스텍에)
    public class LevelCtrl : MonoBehaviour
    {
        //가져올 데이터 파일 
        public TextAsset levelData;

        //가져온 데이터 파일을 담을 구조체
        public List<ST_LEVEL_DATA> listLevelData = new List<ST_LEVEL_DATA>();


        // Start is called before the first frame update
        void Start()
        {
            LoadData();
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(1))
            {
                //ST_LEVEL_DATA temp = listLevelData[2];
                //temp.time = 3f;
                //listLevelData[2] = temp;
            }
        }


        void LoadData()
        {
            string text = levelData.text;

            string[] lines = text.Split('\n');

            foreach (var line in lines)
            {
                if (line == "") continue;

                ST_LEVEL_DATA data = new ST_LEVEL_DATA();

                string[] words = line.Split('\t');
                int index = 0; //증감 연산자 역할

                foreach (var word in words)
                {
                    if (word == "") continue;

                    if (word[0] == '#') break;

                    switch (index)
                    {
                        case 0:
                            data.time = float.Parse(word); //스트링을 float 로 형 변환
                            break;
                        case 1:
                            data.speed = float.Parse(word);
                            break;
                        case 2:
                            data.floorMin = int.Parse(word);
                            break;
                        case 3:
                            data.floorMax = int.Parse(word);
                            break;
                        case 4:
                            data.holeMin = int.Parse(word);
                            break;
                        case 5:
                            data.holeMax = int.Parse(word);
                            break;
                        case 6:
                            data.heightMin = int.Parse(word);
                            break;
                        case 7:
                            data.heightMax = int.Parse(word);
                            break;
                    }
                    index++;
                }

                if (index > 7)
                {
                    index = 0;
                    listLevelData.Add(data);
                }
            }

            Debug.Log("test");
        }
    }
}
