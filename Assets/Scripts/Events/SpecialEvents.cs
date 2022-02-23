using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class SpecialEvents : MonoBehaviour
{
    


   
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            StartCoroutine(DragonEvent());
        }
    }

    

    IEnumerator DragonEvent()
    {
        Time.timeScale = 0.5f;
        //SimpleCameraShakeInCinemachine.LookAt = Garuda.transform;
        yield return new WaitForSeconds(1f);
        Time.timeScale = 1f;
        
    }
    
}
