using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyStaticElemetns : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag=="Player")
        {
             this.gameObject.transform.parent.transform.parent.gameObject.SetActive(false);
        }
    }
}
