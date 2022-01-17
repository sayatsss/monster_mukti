using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatfromView : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if(this.gameObject.name.Contains("End"))
            {
                LevelGenerator.instance.ReCyclePlatform(this.gameObject.transform.parent.gameObject);
            }

            if (this.gameObject.name.Contains("Start"))
            {
                Debug.Log("Destruct start");
                this.gameObject.transform.parent.GetComponent<DestructableManager>().DestructAction();
            }

        }
       
    }
    
}
