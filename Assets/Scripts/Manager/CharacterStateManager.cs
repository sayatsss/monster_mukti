using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using DG.Tweening;

public class CharacterStateManager : MonoBehaviour
{
    public GameObject MainCharacter;
    public GameObject Garuda;
    public GameObject MainCharacter_Chariot;

    public GameObject cam;

    public static CharacterStateManager Instance;


    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        Garuda.SetActive(false);
    }
    public IEnumerator Character_Garuda_Transition()
    {
        Garuda.SetActive(true);
        Garuda.transform.position = MainCharacter.transform.position;
        Garuda.transform.DOMoveY(100f, 8f, false);
        cam.GetComponent<CinemachineVirtualCamera>().m_Follow = Garuda.transform;
        cam.GetComponent<CinemachineVirtualCamera>().LookAt = Garuda.transform;
        // CinemachineCameraManager.GetComponent<CinemachineVirtualCamera>
        yield return new WaitForSeconds(0f);
        MainCharacter.SetActive(false);
    }

    public IEnumerator Garuda_Character_Transition()
    {
        MainCharacter.SetActive(true);
        MainCharacter.transform.position = Garuda.transform.position;

        cam.GetComponent<CinemachineVirtualCamera>().m_Follow = MainCharacter.transform;
        cam.GetComponent<CinemachineVirtualCamera>().LookAt = MainCharacter.transform;
        // CinemachineCameraManager.GetComponent<CinemachineVirtualCamera>
        yield return new WaitForSeconds(0f);

        Garuda.SetActive(false);
        

    }

}
