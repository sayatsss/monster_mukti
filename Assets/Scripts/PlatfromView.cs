using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatfromView : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            LevelGenerator.instance.ReCyclePlatform(this.gameObject.transform.parent.gameObject);
        }
       
    }
    
}
