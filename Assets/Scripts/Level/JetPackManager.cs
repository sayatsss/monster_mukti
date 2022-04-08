using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JetPackManager : MonoBehaviour
{
    public List<GameObject> JetpackPoint = new List<GameObject>();

    public GameObject JetPack;

    private void Start()
    {
        InvokeRepeating("GenerateJetpack", 10f, 30f);
    }
    private void Awake()
    {
        foreach (Transform child in transform)
        {
            JetpackPoint.Add(child.gameObject);

        }
    }

    public void GenerateJetpack()
    {
        if(GameStart.instance.Game_Start)
        {
            int val = Random.Range(0, 4);
            if (val == 2)
            {
                int value = Random.Range(0, JetpackPoint.Count - 1);
                GameObject Go = Instantiate(JetPack);
                Go.transform.position = JetpackPoint[value].transform.position;
            }
        }

        
        
    }
}
