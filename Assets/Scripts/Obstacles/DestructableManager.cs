using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructableManager : MonoBehaviour
{
    public List<GameObject> DestructableElements = new List<GameObject>();

    private void OnEnable()
    {
        foreach (Transform child in transform)
        {
            if(child.name.Contains("pillar"))
            {
                DestructableElements.Add(child.transform.gameObject);
            }
           
        }

    }

    public void activeDestruc()
    {
        for(int i=0;i<DestructableElements.Count;i++)
        {
            DestructableElements[i].SetActive(true);
        }
    }
    public void DestructAction()
    {
        //int value = Random.Range(0, 2);
        int value = 2;
        if(value == 2)
        {
            //Debug.Log("Baccaoo");
            int RandomValue = Random.Range(0, DestructableElements.Count);
            DestructableElements[RandomValue].GetComponent<Destructable>().Destruct();
        }
    }
}
