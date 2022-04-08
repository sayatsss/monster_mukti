using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JetPackManager : MonoBehaviour
{
    public List<GameObject> JetpackPoint = new List<GameObject>();

    public GameObject JetPack;
    private void Awake()
    {
        foreach (Transform child in transform)
        {
            JetpackPoint.Add(child.gameObject);

        }
    }
}
