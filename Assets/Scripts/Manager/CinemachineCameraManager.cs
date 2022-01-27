using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CinemachineCameraManager : MonoBehaviour
{
    public static CinemachineCameraManager instance;
    public GameObject MenuCamera;
    public GameObject GamePlayCamera;
    public GameObject CameraTransition;


    private void Awake()
    {
        instance = this;
        GamePlayCamera.SetActive(false);
        CameraTransition.SetActive(false);
    }

    
}
