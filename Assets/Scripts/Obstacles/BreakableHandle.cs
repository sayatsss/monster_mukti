using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakableHandle : MonoBehaviour
{

    private void OnEnable()
    {
        StartCoroutine(DestroySelf());
    }

    private IEnumerator DestroySelf()
    {
        yield return new WaitForSeconds(5f);
        Destroy(this.gameObject);
    }
   
}
