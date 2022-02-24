using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TilesValues : MonoBehaviour
{


    public GameObject Dragon; 
    public float TileZValue;
    public float TileYValue;
    public float TileXValue;

    public Vector3 RotationValue;

    private void Start()
    {
        foreach (Transform child in transform)
        {
            if (child.name.Contains("Dragon"))
            {
                Dragon = child.gameObject;
            }

        }
    }
}
