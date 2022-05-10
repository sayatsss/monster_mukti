using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeightCalculator : MonoBehaviour
{
    private RaycastHit hit;
    private float dist;
    private Vector3 dir ;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        dist = 10;
        dir =  new Vector3(0, -1, 0);
        //edit: to draw ray also//
        Debug.DrawRay(transform.position, dir * dist, Color.green);
        Physics.Raycast(transform.position, dir, out hit);
        //end edit//
       // Debug.Log(hit.collider.gameObject.name);
    }
}
