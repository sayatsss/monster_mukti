using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{

    public static CameraManager instance;
    [SerializeField]private GameObject mainCamera, asuraCamera;

    private void Awake()
    {
        instance = this;
        asuraCamera.SetActive(false);
    }

    public IEnumerator ChangeOfCameraAngle()
    {
        yield return new WaitForSeconds(0.5f);
        asuraCamera.SetActive(true);
        mainCamera.SetActive(false);
        yield return new WaitForSeconds(1.5f);
        asuraCamera.SetActive(false);
        mainCamera.SetActive(true);

    }
}
