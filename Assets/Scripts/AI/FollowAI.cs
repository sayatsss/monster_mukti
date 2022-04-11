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

    public int AttackCal = 0;


    public GameObject BhasamsuraFollower;
    //[SerializeField] private Vector3 AttackPosition;

    public GameObject SoulSucker;

    
    

    private void Awake()
    {
        Instance = this;
        SoulSucker.SetActive(false);
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
        AttackCal += 1;
        if(AttackCal>=3)
        {
            StartCoroutine(AsuraLastAttack());
        }
        else
        {
            StartCoroutine(AsuraAttack(false));
        }
        
    }

    public IEnumerator AsuraLastAttack()
    {
        
        StartCoroutine(CameraManager.instance.ChangeOfCameraAngle());
        BhasamsuraFollower.transform.localPosition = new Vector3(0, 0, 0);
        this.gameObject.GetComponent<Animator>().SetBool("IsAttack", true);
        yield return new WaitForSeconds(1.8f);
        isAttacking = true;

        yield return new WaitForSeconds(0.2f);
        StartCoroutine(SimpleCameraShakeInCinemachine.Instance.cameraAction());
        isAttacking = false;
        this.gameObject.GetComponent<Animator>().SetBool("IsIdle", true);
        SoulSucker.SetActive(true);
        StartCoroutine(GameManager.instance.GameEndAction());
        

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
       
        yield return new WaitForSeconds(0.2f);
        StartCoroutine(SimpleCameraShakeInCinemachine.Instance.cameraAction());
        isAttacking = false;
        this.gameObject.GetComponent<Animator>().SetBool("IsAttack", false);
        
        //SimpleCameraShakeInCinemachine.Instance.VirtualCamera.GetComponent<CinemachineVirtualCamera>().m_Lens.FieldOfView = 80f;
    }
    

}
