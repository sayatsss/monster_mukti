using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinManager : MonoBehaviour
{
    private List<GameObject> Coins=new List<GameObject>();
    private float _coinGap = 1;

    private void OnEnable()
    {
        foreach (Transform child in transform)
        {
            Coins.Add(child.transform.gameObject);
        }
        ArrangeCoins();
    }

    private void ArrangeCoins()
    {
        for(int i=0;i<Coins.Count;i++)
        {

            Coins[i].transform.position = new Vector3(Coins[i].transform.position.x, Coins[i].transform.position.y+0.5f, i * _coinGap);
        }
    }

  
}
