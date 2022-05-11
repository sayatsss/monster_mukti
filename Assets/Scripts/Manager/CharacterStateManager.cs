using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using DG.Tweening;

public class CharacterStateManager : MonoBehaviour
{
    public GameObject MainCharacter;
    public GameObject MainCharacterBody;
    public GameObject Garuda;
    public GameObject GarudaBody;
    public GameObject MainCharacter_Chariot;


    public GameObject MainCameraGameplay;
    public GameObject ChariotCamera;


    public GameObject Chariot_PlayerMesh;

    public GameObject Chariot_Refence;
    

    public GameObject cam;

    public static CharacterStateManager Instance;

    [HideInInspector]public bool IsPlayerActive = false;


    private void Awake()
    {
        Instance = this;
        MainCharacter_Chariot.transform.DOScale(0.01f, 0.1f);
        Chariot_PlayerMesh.transform.DOScale(0.01f, 0.1f);
        ChariotCamera.SetActive(false);
    }

    private void Start()
    {
        Garuda.SetActive(false);
        MainCharacter_Chariot.SetActive(false);
        Chariot_PlayerMesh.SetActive(false);
    }
    public IEnumerator Character_Garuda_Transition(GameObject gameObject)
    {
        IsPlayerActive = false;
        Garuda.SetActive(true);
        OverTheCloudManager.instance.activateOverTheCloud();
        UIManager.instance.GarudaMeter.SetActive(true);
        GarudaManager.Instance.GarudaTimeSpan = 100;
        Garuda.transform.position = MainCharacter.transform.position;
        Garuda.transform.DOMoveY(90f, 6f, false);
        cam.GetComponent<CinemachineVirtualCamera>().m_Follow = Garuda.transform;
        cam.GetComponent<CinemachineVirtualCamera>().LookAt = Garuda.transform;
        OverTheCloudManager.instance.activateOverTheCloud();
        yield return new WaitForSeconds(0f);
        MainCharacter.SetActive(false);
        gameObject.SetActive(false);


    }

    public IEnumerator Garuda_Character_Transition()
    {
        OverTheCloudManager.instance.DeactivateOverTheCloud();
        IsPlayerActive = true;
        Garuda.transform.DOMoveY(24f, 5f, false);
        yield return new WaitForSeconds(6f);
        MainCharacter.transform.position = Garuda.transform.position;
        MainCharacter.SetActive(true);

        cam.GetComponent<CinemachineVirtualCamera>().m_Follow = MainCharacterBody.transform;
        cam.GetComponent<CinemachineVirtualCamera>().LookAt = MainCharacter.transform;

        Garuda.SetActive(false);
        UIManager.instance.GarudaMeter.SetActive(false);
        GarudaManager.Instance.GarudaTimeSpan = 100;

        if (TicketManager.instance.ticketCount == TicketManager.instance.Tickets.Count && CharacterStateManager.Instance.IsPlayerActive)
        {
            StartCoroutine(PortalFollow.instance.ActivatePortal());
        }

    }
    public IEnumerator Player_Chariot_Transition(GameObject gameObject)
    {
        IsPlayerActive = false;
        gameObject.transform.DOScale(0.01f, 0.1f);
        MainCharacter_Chariot.transform.position = new Vector3(0, MainCharacter.transform.position.y, MainCharacter.transform.position.z);
        MainCharacter_Chariot.SetActive(true);
        MainCharacter_Chariot.transform.DOScale(0.01f, 0.05f);
        yield return new WaitForSeconds(0.1f);
        MainCharacter_Chariot.transform.DOScale(1f, 0.5f);
        yield return new WaitForSeconds(0.3f);
        ChariotCamera.SetActive(true);
        MainCharacter.SetActive(false);
        MainCameraGameplay.SetActive(false);
        Chariot_PlayerMesh.SetActive(true);
        Chariot_PlayerMesh.transform.DOScale(1.2f, 0.2f);
        MainCharacter_Chariot.GetComponent<ChariotControl>().HorseRunAnimation();
        UIManager.instance.ChariotMeter.SetActive(true);
        //MainCameraGameplay.SetActive(false);
        MainCharacter.SetActive(false);
        yield return new WaitForSeconds(2f);
        MainCharacter_Chariot.GetComponent<ChariotControl>().ChariotActivated = true;
        yield return new WaitForSeconds(0.5f);
        MainCharacter_Chariot.GetComponent<ChariotControl>().controller.stepOffset = 0.8f;
        
    }


    public IEnumerator Chariot_Player_Transition()
    {
        MainCameraGameplay.SetActive(true);
        ChariotCamera.SetActive(false);
        IsPlayerActive = true;
        MainCharacter.transform.position = MainCharacter_Chariot.transform.localPosition;
        MainCharacter.SetActive(true);
        MainCharacter_Chariot.SetActive(false);
        
        UIManager.instance.ChariotMeter.SetActive(false);
        ChariotAction.Instance.ChariotTimeSpan = 50;

        yield return new WaitForSeconds(0f);

    }
}
