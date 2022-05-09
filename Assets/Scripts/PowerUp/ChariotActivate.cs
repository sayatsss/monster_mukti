using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChariotActivate : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            StartCoroutine(CharacterStateManager.Instance.Player_Chariot_Transition(this.gameObject));


        }
    }


    
}
