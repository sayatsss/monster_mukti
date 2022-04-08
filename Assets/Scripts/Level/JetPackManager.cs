using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JetPackManager : MonoBehaviour
{
    public List<GameObject> JetpackPoint = new List<GameObject>();

    public GameObject JetPack;

    private void Start()
    {
        InvokeRepeating("GenerateJetpack", 10f, 40f);
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
        

        int val = Random.Range(0, 5);
        if(val==3)
        {
            int value = Random.Range(0, JetpackPoint.Count - 1);
            GameObject Go = Instantiate(JetPack);
            Go.transform.position = JetpackPoint[value].transform.position;
        }
        
    }
}
