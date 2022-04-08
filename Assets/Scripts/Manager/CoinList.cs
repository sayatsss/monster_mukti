using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinList : MonoBehaviour
{


    private List<GameObject> coin = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {

        foreach (Transform child in transform)
        {
            coin.Add(child.gameObject);

        }
    }

    public void ActivateAllCoins()
    {
        for(int i=0;i<coin.Count;i++)
        {
            coin[i].SetActive(true);
        }
    }

    
}
