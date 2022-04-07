using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructable : MonoBehaviour
{
    public GameObject DestructablePrefab;
   

    public void Destruct(bool arc)
    {
         GameObject GO = Instantiate(DestructablePrefab);
         //GO.transform.parent = this.gameObject.transform.parent;
         GO.transform.position = this.gameObject.transform.position;
        if(arc)
        {
            GO.transform.localScale = new Vector3(0.8f, 0.8f, 0.8f);
        }
        else
        {
            GO.transform.localScale = this.gameObject.transform.localScale;
        }
         //GO.transform.localScale = this.gameObject.transform.localScale;
        // GO.transform.localRotation = Quaternion.Euler(-90f, 0, 180f);
         this.gameObject.SetActive(false);
    }
}
