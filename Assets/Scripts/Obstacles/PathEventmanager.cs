using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathEventmanager : MonoBehaviour
{
    public GameObject obstacleObject;
    public List<GameObject> pillarsArc;

    private int value;

    private void Start()
    {
        foreach (Transform child in transform)
        {
            if (child.name.Contains("Block"))
            {
                obstacleObject=child.transform.gameObject;
                obstacleObject.GetComponent<Animator>().enabled = false;
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

    public IEnumerator BlockAction()
    {
        obstacleObject.SetActive(true);
        obstacleObject.GetComponent<Animator>().enabled = true;
        yield return new WaitForSeconds(4f);
        obstacleObject.GetComponent<Animator>().enabled = false;
        obstacleObject.SetActive(false);
    }
    public IEnumerator PillarArcAction()
    {
//        Debug.Log("Pillar hil");

        pillarsArc[value].GetComponent<Animator>().enabled = true;
        yield return new WaitForSeconds(4f);
        pillarsArc[value].GetComponent<Animator>().enabled = false;
        pillarsArc[value].SetActive(false);
        yield return new WaitForSeconds(3f);
        pillarsArc[value].SetActive(true);
    }


}
