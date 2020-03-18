using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class DataMgr : MonoBehaviour
{
    static GameObject container;
    static GameObject Container { get => container; } //프로퍼티 게터(람다식)

    static DataMgr instance;
    public static DataMgr Instance
    {
        get
        {
            if(!instance)
            {
                container = new GameObject();
                container.name = "DataMgr";
                instance = container.AddComponent(typeof(DataMgr)) as DataMgr;
                DontDestroyOnLoad(container); //씬을 전환해도 오브젝트 유지 시키는 것
            }
            return instance;
        }
    }

    [SerializeField] //Serializable 키워드를 쓴 클래스의 변수를 볼 수 있다.
    GameData datas; //게임 데이터 스크립트 컴포넌트
    public GameData Datas
    {
        get
        {
            if(datas == null)
            {
                //데이터 로드
                LoadData(); //파일 읽어오기
                SaveData(); //파일 저장

            }
            return datas;
        }
    }

    void LoadData()
    {
        //윈도우, 맥, android, iOS 플랫폼에 따라 다른 데이터 패스가 지정된다.
        string filePath = Application.persistentDataPath + "\\saveData.json";

        if(File.Exists(filePath))
        {
            string fromJsonData = File.ReadAllText(filePath);
            datas = JsonUtility.FromJson<GameData>(fromJsonData); //역 직렬화
        }
        else
        {
            datas = new GameData();
        }
    }

    void SaveData()
    {
        string toJsonData = JsonUtility.ToJson(datas); //직렬화를 통해 문자열로 변환
        string filePath = Application.persistentDataPath + "\\saveData.json";
        File.WriteAllText(filePath, toJsonData);
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
