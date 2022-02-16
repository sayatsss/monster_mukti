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
    public IEnumerator Character_Garuda_Transition(GameObject gameObject)
    {
        Garuda.SetActive(true);
        UIManager.instance.GarudaMeter.SetActive(true);
        GarudaManager.Instance.GarudaTimeSpan = 100;
        Garuda.transform.position = MainCharacter.transform.position;
        Garuda.transform.DOMoveY(90f, 6f, false);
        cam.GetComponent<CinemachineVirtualCamera>().m_Follow = Garuda.transform;
        cam.GetComponent<CinemachineVirtualCamera>().LookAt = Garuda.transform;
      
        yield return new WaitForSeconds(0f);
        MainCharacter.SetActive(false);
        gameObject.SetActive(false);


    }

    public IEnumerator Garuda_Character_Transition()
    {
        Garuda.transform.DOMoveY(LevelGenerator.instance.SPY_Offset, 5f, false);
        yield return new WaitForSeconds(6f);
        MainCharacter.transform.position = Garuda.transform.position;
        MainCharacter.SetActive(true);

        cam.GetComponent<CinemachineVirtualCamera>().m_Follow = MainCharacterBody.transform;
        cam.GetComponent<CinemachineVirtualCamera>().LookAt = MainCharacter.transform;

        Garuda.SetActive(false);
        UIManager.instance.GarudaMeter.SetActive(false);
        GarudaManager.Instance.GarudaTimeSpan = 100;


    }

}
