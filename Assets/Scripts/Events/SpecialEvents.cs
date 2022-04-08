using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class SpecialEvents : MonoBehaviour
{

    private GameObject Dragon;


    private void Start()
    {
        Dragon = transform.GetComponentInParent<TilesValues>().Dragon;
    }
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
       // SimpleCameraShakeInCinemachine.Instance.VirtualCamera.aim
        SimpleCameraShakeInCinemachine.Instance.VirtualCamera.LookAt = Dragon.transform;
        Dragon.GetComponent<AudioSource>().Play();
            Dragon.GetComponent<Animator>().SetBool("IsRoar", true);
        yield return new WaitForSeconds(1.5f);
        SimpleCameraShakeInCinemachine.Instance.VirtualCamera.LookAt = CharacterStateManager.Instance.MainCharacter.transform;
        Dragon.GetComponent<Animator>().SetBool("IsRoar", false);
        Time.timeScale = 1f;
        
    }
    
}
