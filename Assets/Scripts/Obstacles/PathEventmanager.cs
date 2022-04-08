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
               // pillarsArc[value].GetComponent<Animator>().enabled = false;

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

        pillarsArc[value].GetComponent<Animator>().SetBool("IsAttack", true);
        yield return new WaitForSeconds(2f);
        pillarsArc[value].GetComponent<Animator>().SetBool("IsAttack", false);

    }


}
