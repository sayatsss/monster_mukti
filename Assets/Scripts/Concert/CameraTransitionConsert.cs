using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTransitionConsert : MonoBehaviour
{
    [SerializeField]private GameObject BackFaceCamera, SideFacecamera;

    private void Awake()
    {
        //SideFacecamera.SetActive(false);
        //BackFaceCamera.SetActive(true);
    }
    private void Start()
    {
        StartCoroutine(CameraChange());
    }

    private IEnumerator CameraChange()
    {

        yield return new  WaitForSeconds(0.5f);
        //BackFaceCamera.SetActive(false);
        //SideFacecamera.SetActive(true);
    }
}
