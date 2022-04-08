using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinManager : MonoBehaviour
{
    public List<GameObject> Coins=new List<GameObject>();
    public GameObject Jetpack;
    private float _coinGap = 1;

    private void OnEnable()
    {
        foreach (Transform child in transform)
        {
            Coins.Add(child.transform.gameObject);
            
        }
      
    }

    public void ArrangeCoins()
    {
            for (int i = 0; i < Coins.Count; i++)
            {

                //Coins[i].transform.position = new Vector3(Coins[i].transform.position.x, Coins[i].transform.position.y + 0.5f, i * _coinGap);
                Coins[i].SetActive(false);
            }
            
    }

    public void GenerateCoins()
    {

        
        if (Coins.Count != 0)
        {
            ArrangeCoins();
            int _coinValue = Random.Range(8, Coins.Count);
            for (int i = 0; i < _coinValue; i++)
            {
                 Coins[i].SetActive(true);
            }
        }
    }


  
}
