using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHitData : MonoBehaviour
{
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        Debug.Log(hit.gameObject.name);
        if(hit.transform.tag == "Block")
        {
            StartCoroutine(UIManager.instance.BloodScreenSplash());
            StartCoroutine(GameManager.instance.GameEndAction());
        }
        
    }
}
