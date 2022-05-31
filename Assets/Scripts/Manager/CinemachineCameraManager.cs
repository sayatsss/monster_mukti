using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CinemachineCameraManager : MonoBehaviour
{
    public static CinemachineCameraManager instance;
    public GameObject MenuCamera;
    public GameObject GamePlayCamera;
    public GameObject CameraTransition;
    public GameObject AttackCamera;


    private void Awake()
    {
        instance = this;
        GamePlayCamera.SetActive(false);
        CameraTransition.SetActive(false);
    }


    public void AssignCameraValue(int value)
    {

        GamePlayCamera.GetComponent<CinemachineVirtualCamera>().m_Follow = CinemachineRefence.instance.playerBodyRefence[value];
        GamePlayCamera.GetComponent<CinemachineVirtualCamera>().LookAt = CinemachineRefence.instance.playerRefence[value];
        CameraTransition.GetComponent<CinemachineVirtualCamera>().LookAt = CinemachineRefence.instance.playerRefence[value];
        AttackCamera.GetComponent<CinemachineVirtualCamera>().m_Follow = CinemachineRefence.instance.playerBodyRefence[value];
        AttackCamera.GetComponent<CinemachineVirtualCamera>().LookAt = CinemachineRefence.instance.playerRefence[value];
    }
    
}
