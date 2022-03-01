using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.Events;

public class SimpleCameraShakeInCinemachine : MonoBehaviour
{


    public static SimpleCameraShakeInCinemachine Instance;
    public float ShakeDuration = 0.3f;          // Time the Camera Shake effect will last
    public float ShakeAmplitude = 1.2f;         // Cinemachine Noise Profile Parameter
    public float ShakeFrequency = 2.0f;         // Cinemachine Noise Profile Parameter

    private float ShakeElapsedTime = 0f;

    // Cinemachine Shake
    public CinemachineVirtualCamera VirtualCamera,VirtualCameraMenu;
    private CinemachineBasicMultiChannelPerlin virtualCameraNoise;
    private CinemachineBasicMultiChannelPerlin virtualCameraNoiseMenu;


    private void Awake()
    {
        Instance = this;
    }
    // Use this for initialization
    void Start()
    {
        // Get Virtual Camera Noise Profile
        if (VirtualCamera != null)
            virtualCameraNoise = VirtualCamera.GetCinemachineComponent<Cinemachine.CinemachineBasicMultiChannelPerlin>();
        if (VirtualCameraMenu != null)
            virtualCameraNoiseMenu = VirtualCameraMenu.GetCinemachineComponent<Cinemachine.CinemachineBasicMultiChannelPerlin>();
    }

   public IEnumerator cameraAction()
    {
        ShakeElapsedTime = ShakeDuration;
        yield return new WaitForSeconds(ShakeDuration);
        ShakeElapsedTime = 0;

    }

  
    private void Update()
    {
        CameraAction();
        CameraActionMenu();
    }
    // Update is called once per frame
    public  void CameraAction()
    {
        
       
        // If the Cinemachine componet is not set, avoid update
        if (VirtualCamera != null && virtualCameraNoise != null)
        {
            // If Camera Shake effect is still playing
            if (ShakeElapsedTime > 0)
            {
                // Set Cinemachine Camera Noise parameters
                virtualCameraNoise.m_AmplitudeGain = ShakeAmplitude;
                virtualCameraNoise.m_FrequencyGain = ShakeFrequency;

                // Update Shake Timer
                //ShakeElapsedTime -= Time.deltaTime;
                //Debug.Log(ShakeElapsedTime);
            }
            else
            {
                // If Camera Shake effect is over, reset variables
                virtualCameraNoise.m_AmplitudeGain = 0f;
                ShakeElapsedTime = 0f;
            }
        }
    }

    public void CameraActionMenu()
    {


        // If the Cinemachine componet is not set, avoid update
        if (VirtualCameraMenu != null && virtualCameraNoiseMenu != null)
        {
            // If Camera Shake effect is still playing
            if (ShakeElapsedTime > 0)
            {
                // Set Cinemachine Camera Noise parameters
                virtualCameraNoiseMenu.m_AmplitudeGain = ShakeAmplitude;
                virtualCameraNoiseMenu.m_FrequencyGain = ShakeFrequency;

                // Update Shake Timer
                //ShakeElapsedTime -= Time.deltaTime;
                //Debug.Log(ShakeElapsedTime);
            }
            else
            {
                // If Camera Shake effect is over, reset variables
                virtualCameraNoiseMenu.m_AmplitudeGain = 0f;
                ShakeElapsedTime = 0f;
            }
        }
    }
    public void FocusPuller()
    {
        
       
    }
}