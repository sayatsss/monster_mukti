using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NFTCustomisation : MonoBehaviour
{
    [SerializeField] private List<GameObject> NFTOptions = new List<GameObject>();



    private void Start()
    {
        NFTOptionChange(0);
    }
    private void NFTOptionDefault()
    {
        for(int i=0;i<NFTOptions.Count;i++)
        {
            NFTOptions[i].SetActive(false);
        }


    }
    public void NFTOptionChange(int value)
    {
        NFTOptionDefault();
        NFTOptions[value].SetActive(true);
    }
}
