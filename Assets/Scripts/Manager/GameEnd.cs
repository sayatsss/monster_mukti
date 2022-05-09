using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameEnd : MonoBehaviour
{

   
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag=="Player")
        {
            if (this.gameObject.name.Contains("Die"))
            {
                //Debug.Log(gameObject.name);
                StartCoroutine(GameEndAction());
            }
            if (this.gameObject.name.Contains("Cam"))
            {
                AudioManager.Instance.DamageLow.Play();
                StartCoroutine(GameEndActionCameraShake());
                FollowAI.Instance.AsuraAction();
            }
        }
       

    }

  

    IEnumerator GameEndAction()
    {
        PlayerController.instance.characterAnimator.SetBool("IsDead", true);
        GameManager.instance.GameStateChange(GameManager.GameState.gameEnd);
        UIManager.instance.GameEndPanel.SetActive(true);
        UIManager.instance.GamePanel.SetActive(false);
        yield return new WaitForSeconds(2f);
       // Time.timeScale = 0;
    }
    IEnumerator GameEndActionCameraShake()
    {
       
        StartCoroutine(SimpleCameraShakeInCinemachine.Instance.cameraAction());
        StartCoroutine(UIManager.instance.BloodScreenSplash());
        PlayerController.instance.characterAnimator.SetBool("IsHit", true);
        yield return new WaitForSeconds(0.3f);
        PlayerController.instance.characterAnimator.SetBool("IsHit", false);
        if (PlayerController.instance.speed>12)
        {
            PlayerController.instance.speed = PlayerController.instance.speed - 2f;
        }
        

    }
}
