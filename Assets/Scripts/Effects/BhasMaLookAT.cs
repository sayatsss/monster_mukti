using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BhasMaLookAT : MonoBehaviour
{


    public static BhasMaLookAT instance;
    public Transform target;


    private void Awake()
    {
        instance = this;
    }

    void Update()
    {
        // Point the object at the world origin (0,0,0)

       
            transform.LookAt(target);

       
    }
}
