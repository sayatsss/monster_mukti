using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHitData : MonoBehaviour
{
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if(hit.transform.tag == "Block")
        {
            StartCoroutine(UIManager.instance.BloodScreenSplash());
            StartCoroutine(GameManager.instance.GameEndAction());
        }
        
    }
}
