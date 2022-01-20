using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinGenerator : MonoBehaviour
{

    public List<GameObject> CoinManagers;
    private int CoinManagerActiveValue;
    private GameObject Skull;
    private GameObject pillarArc;

    private void OnEnable()
    {
        
        foreach (Transform child in transform)
        {
            if(child.name.Contains("Coin"))
            {
                CoinManagers.Add(child.transform.gameObject);
            }
            if(child.name.Contains("skull"))
            {
                Skull = child.gameObject;
            }
            if (child.name.Contains("pillararch"))
            {
                pillarArc = child.gameObject;
            }
        }
        

    }

    private void Start()
    {
        ReArrangeCoinManagers();
    }

    public void ReArrangeCoinManagers()
    {
        if (Skull != null)
        {
           /* int value = Random.Range(0, 2);
            if (value == 1)
            {
                Skull.SetActive(true);
            }
            else
            {
                Skull.SetActive(false);
            }*/
        }
        if (pillarArc != null)
        {
            int value = Random.Range(0, 2);
            if (value == 1)
            {
                pillarArc.SetActive(true);
            }
            else
            {
                pillarArc.SetActive(false);
            }
        }

        if (CoinManagers.Count!=0)
        {
            for (int i = 0; i < CoinManagers.Count; i++)
            {
                CoinManagers[i].SetActive(false);
            }
            CoinManagerActiveValue = CoinManagerValue();
            CoinManagers[CoinManagerActiveValue].SetActive(true);
            CoinManagers[CoinManagerActiveValue].GetComponent<CoinManager>().GenerateCoins();
        }
        
    }

    private int CoinManagerValue()
    {
        int value=Random.Range(0, CoinManagers.Count);
        return value;
    }
   
}
