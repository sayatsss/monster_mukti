using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level3GateOpen : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            this.gameObject.transform.GetComponentInParent<Level3Gate>().GateUp();
            this.gameObject.transform.GetComponentInParent<Level3Gate>().GateDown();
        }
        
    }
}
