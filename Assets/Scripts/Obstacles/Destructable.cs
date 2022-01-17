using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructable : MonoBehaviour
{
    public GameObject DestructablePrefab;
    public float zValue;

    public void Destruct()
    {
        GameObject GO = Instantiate(DestructablePrefab);
        GO.transform.parent = this.gameObject.transform.parent;
        GO.transform.position = this.gameObject.transform.position;
       // GO.transform.localRotation = Quaternion.Euler(-90f, 0, 180f);
        this.gameObject.SetActive(false);
    }
}
