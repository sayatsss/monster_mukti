using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatfromView : MonoBehaviour
{
    [SerializeField] private float Z_value;
    // Start is called before the first frame update

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            //this.gameObject.GetComponent<MeshRenderer>().enabled = false;
            LevelGenerator.instance.ReCyclePlatform(this.gameObject.transform.parent.gameObject, Z_value);
        }
       
    }
    
}
