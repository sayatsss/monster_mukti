using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
   
    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 20 * Time.deltaTime, 0);
        //this.gameObject.transform.rotation = Quaternion.AngleAxis(30, Vector3.up);
        //transform.rotation 
    }
}
