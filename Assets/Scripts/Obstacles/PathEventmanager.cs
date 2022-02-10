using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathEventmanager : MonoBehaviour
{
    public GameObject obstacleObject;
    public List<GameObject> pillarsArc;

    private int value;

    private void Awake()
    {
        foreach (Transform child in transform)
        {
            if (child.name.Contains("Block"))
            {
                obstacleObject=child.transform.gameObject;
                obstacleObject.SetActive(false);
            }
            if (child.name.Contains("Ani"))
            {
                pillarsArc.Add(child.transform.gameObject);
                for(int i=0;i<pillarsArc.Count;i++)
                {
                    pillarsArc[i].SetActive(false);
                }
                value = Random.Range(0, pillarsArc.Count);
                pillarsArc[value].SetActive(true);
                pillarsArc[value].GetComponent<Animator>().enabled = false;

            }

        }
        
    }
    public void PillarArcAction()
    {

        pillarsArc[value].GetComponent<Animator>().enabled = true;

    }


}
