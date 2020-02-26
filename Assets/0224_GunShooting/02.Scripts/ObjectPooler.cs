using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    //클래스를 시리얼 라이즈 필드 한 것
    [System.Serializable]
    public class Pool
    {
        public string tag;
        public GameObject prefabs;
        public int size;
    }

    //오브젝트 풀로 구성하고 싶은 오브젝트의 종류
    public List<Pool> listPool;

    //종류별로 생성. 딕셔너리(키와 벨류), C++에선 맵과 동일
    public Dictionary<string, Queue<GameObject>> dictionaryPool;

    //오브젝트 풀러를 싱글톤으로 만들기
    public static ObjectPooler instance;
    //public static ObjectPooler Instance { get => instance; }
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        dictionaryPool = new Dictionary<string, Queue<GameObject>>();

        foreach(Pool pool in listPool)
        {
            Queue<GameObject> objectPool = new Queue<GameObject>();

            for(int i = 0; i < pool.size; i++)
            {
                GameObject go = Instantiate(pool.prefabs);
                go.SetActive(false);
                objectPool.Enqueue(go);
            }

            dictionaryPool.Add(pool.tag, objectPool);
        }
    }


    //풀 스폰 시키기
    public GameObject SpawnFromPool(string tag, Vector3 position, Quaternion rotation)
    {
        //테그 없으면 바로 리턴
        if (!dictionaryPool.ContainsKey(tag)) return null;

        GameObject objectFromPool = dictionaryPool[tag].Dequeue(); //큐 라서 먼저 넣은거 부터 나온다.

        objectFromPool.SetActive(true);
        objectFromPool.transform.position = position;
        objectFromPool.transform.rotation = rotation;

        dictionaryPool[tag].Enqueue(objectFromPool);

        return objectFromPool;
    }
}
