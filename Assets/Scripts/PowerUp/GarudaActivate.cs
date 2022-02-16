using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GarudaActivate : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag=="Player")
        {
            
            StartCoroutine(CharacterStateManager.Instance.Character_Garuda_Transition(this.gameObject));
           
        }
    }
}
