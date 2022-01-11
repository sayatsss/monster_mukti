using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinGenerator : MonoBehaviour
{

    public List<GameObject> CoinManagers;
    private int CoinManagerActiveValue;

    private void OnEnable()
    {
        foreach (Transform child in transform)
        {
            if(child.name.Contains("Coin"))
            {
                CoinManagers.Add(child.transform.gameObject);
            }
        }
        

    }

    private void Start()
    {
        ReArrangeCoinManagers();
    }

    private void ReArrangeCoinManagers()
    {
        for(int i=0;i<CoinManagers.Count;i++)
        {
            CoinManagers[i].SetActive(false);
        }
        CoinManagerActiveValue = CoinManagerValue();
        CoinManagers[CoinManagerActiveValue].SetActive(true);
        CoinManagers[CoinManagerActiveValue].GetComponent<CoinManager>().GenerateCoins();
    }

    private int CoinManagerValue()
    {
        int value=Random.Range(0, CoinManagers.Count);
        return value;
    }
   
}
