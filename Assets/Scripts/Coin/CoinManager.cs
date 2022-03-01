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
            if(child.transform.gameObject.name.Contains("JetPack"))
            {
                Jetpack = child.transform.gameObject;
            }
        }
      
    }

    public void ArrangeCoins()
    {
            for (int i = 0; i < Coins.Count; i++)
            {

                //Coins[i].transform.position = new Vector3(Coins[i].transform.position.x, Coins[i].transform.position.y + 0.5f, i * _coinGap);
                Coins[i].SetActive(false);
            }
            if(Jetpack!=null)
            {
                Jetpack.SetActive(false);
            }
    }

    public void GenerateCoins()
    {

        if (Jetpack != null)
        {
            //Jetpack.SetActive(true);
           int value = Random.Range(0, 3);
            if(value==1)
            {
                Jetpack.SetActive(true);
            }
        }
        if (Coins.Count != 0)
        {
            ArrangeCoins();
            int _coinValue = Random.Range(4, Coins.Count);
            for (int i = 0; i < _coinValue; i++)
            {
                 Coins[i].SetActive(true);
            }
        }
    }


  
}
