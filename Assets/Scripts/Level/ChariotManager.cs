using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChariotManager : MonoBehaviour
{
    public List<GameObject> ChariotPoints = new List<GameObject>();

    public GameObject Chariot;

    private void Start()
    {
        InvokeRepeating("GenerateChairot", 10f, 30f);
    }
    private void Awake()
    {
        foreach (Transform child in transform)
        {
            ChariotPoints.Add(child.gameObject);

        }
    }
    public void GenerateChairot()
    {
        if (GameStart.instance.Game_Start)
        {

            int val = Random.Range(0, 2);
            Debug.Log("Chairot Generated");
            
            int value = Random.Range(0, ChariotPoints.Count - 1);
            Debug.Log(value);
            GameObject Go = Instantiate(Chariot);
            Go.transform.position = ChariotPoints[value].transform.position;

            /*if (val == 2)
                {
                    int value = Random.Range(0, ChariotPoints.Count - 1);
                    GameObject Go = Instantiate(Chariot);
                    Go.transform.position = ChariotPoints[value].transform.position;
                }
            }*/
        }

    }
}
