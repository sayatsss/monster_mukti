using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinGenerator : MonoBehaviour
{
    public GameObject coinPrefab;
    private bool coinSpawnRandom=false;

    private void Start()
    {
        SpawnCoins();
    }

    public void SpawnCoins()
    {
        int value = Random.Range(0, 4);
        if (value == 1)
        {
            coinSpawnRandom = true;
        }
        else
        {
            coinSpawnRandom = false;
        }
        int coinSpawnCount = Random.Range(4, 6);
        for(int i=0;i<coinSpawnCount;i++)
        {
            GameObject coin = Instantiate(coinPrefab);
            coin.transform.parent = this.gameObject.transform;
            coin.transform.position = GetRandomPointOnCollider(GetComponent<Collider>());
           // coin.transform.localPosition = new Vector3(coin.transform.position.x, 0, coin.transform.position.z);
        }
    }

    Vector3 GetRandomPointOnCollider(Collider collider)
    {
        Vector3 point = new Vector3(
            Random.Range(collider.bounds.min.x, collider.bounds.max.x),
             Random.Range(collider.bounds.min.y, collider.bounds.max.y),
              Random.Range(collider.bounds.min.z, collider.bounds.max.z));

        if(point!=collider.ClosestPoint(point))
        {
            point = GetRandomPointOnCollider(collider);
        }
        point.y = this.gameObject.transform.position.y;
        return point;
    }

}
