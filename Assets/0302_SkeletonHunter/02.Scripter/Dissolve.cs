using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dissolve : MonoBehaviour
{
    public Material[] mat;

    // Start is called before the first frame update
    void Start()
    {
        //mat = GameObject.Find("Object01").GetComponent<Renderer>().material;
        mat[0] = GameObject.Find("Object01").GetComponent<Renderer>().material;
        mat[1] = GameObject.Find("Object02").GetComponent<Renderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        //mat.SetFloat("_DissolveAmount", Mathf.Sin(Time.time) / 2 + 0.5f);
        mat[0].SetFloat("_DissolveAmount", Mathf.Sin(Time.time) / 2 + 0.5f);
        mat[1].SetFloat("_DissolveAmount", Mathf.Sin(Time.time) / 2 + 0.5f);
    }
}
