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
        yield return new WaitForSeconds(7f);
        Destroy(this.gameObject);
    }
   
}
