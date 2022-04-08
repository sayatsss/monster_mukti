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
        GO.transform.localScale = this.gameObject.transform.localScale;
      
         this.gameObject.SetActive(false);
        
    }
}
