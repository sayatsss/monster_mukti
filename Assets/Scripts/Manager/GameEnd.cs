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
        //CameraShaker.Instance.ShakeOnce(4f, 4f, 0.1f, 1f);
        yield return new WaitForSeconds(0.1f);
        PlayerController.instance.speed = 8;
        //yield return new WaitForSeconds(0.8f);
        //GameManager.instance.GameStateChange(GameManager.GameState.gameEnd);
        //UIManager.instance.GameEndPanel.SetActive(true);
        //UIManager.instance.GamePanel.SetActive(false);
        //Time.timeScale = 0;

    }
}
