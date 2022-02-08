using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameEnd : MonoBehaviour
{

   
    private void OnTriggerEnter(Collider other)
    {
       if(this.gameObject.name.Contains("Death"))
        {
            StartCoroutine(GameEndAction());
        }
        if (this.gameObject.name.Contains("Cam"))
        {
            StartCoroutine(GameEndActionCameraShake());
        }

    }

    


    IEnumerator GameEndAction()
    {
        GameManager.instance.GameStateChange(GameManager.GameState.gameEnd);
        UIManager.instance.GameEndPanel.SetActive(true);
        UIManager.instance.GamePanel.SetActive(false);
        yield return new WaitForSeconds(0.2f);
        Time.timeScale = 0;
    }
    IEnumerator GameEndActionCameraShake()
    {
        StartCoroutine(SimpleCameraShakeInCinemachine.Instance.cameraAction());
        StartCoroutine(UIManager.instance.BloodScreenSplash());
   
        yield return new WaitForSeconds(0.1f);
        if(PlayerController.instance.speed>12)
        {
            PlayerController.instance.speed = PlayerController.instance.speed - 2f;
        }
        

    }
}
