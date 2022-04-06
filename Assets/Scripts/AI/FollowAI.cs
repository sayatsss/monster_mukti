using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Cinemachine;

public class FollowAI : MonoBehaviour
{


    public static FollowAI Instance;
   
    private bool isAttacking = false;


    private bool isFirstAttack = false;

  

    
    

    private void Awake()
    {
        Instance = this;
    }
    
   
    public IEnumerator FirstAsuraAttack()
    {
        yield return new WaitForSeconds(0.6f);
        StartCoroutine(AsuraAttack(true));
        yield return new WaitForSeconds(6f);
        isFirstAttack = true;
    }
    public void AsuraAction()
    {
        StartCoroutine(AsuraAttack(false));
    }
    public IEnumerator AsuraAttack(bool FirstAttack)
    {
       
        if (!FirstAttack)
        {
            StartCoroutine(CameraManager.instance.ChangeOfCameraAngle());
            
        }
        //SimpleCameraShakeInCinemachine.Instance.VirtualCamera.GetComponent<CinemachineVirtualCamera>().m_Lens.FieldOfView = 90f;
        this.gameObject.GetComponent<Animator>().SetBool("IsAttack", true);
        yield return new WaitForSeconds(1.8f);
        isAttacking = true;
        StartCoroutine(SimpleCameraShakeInCinemachine.Instance.cameraAction());
        yield return new WaitForSeconds(0.2f);
        isAttacking = false;
        this.gameObject.GetComponent<Animator>().SetBool("IsAttack", false);
        
        //SimpleCameraShakeInCinemachine.Instance.VirtualCamera.GetComponent<CinemachineVirtualCamera>().m_Lens.FieldOfView = 80f;
    }
    

}
