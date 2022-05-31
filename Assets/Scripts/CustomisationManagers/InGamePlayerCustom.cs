using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGamePlayerCustom : MonoBehaviour
{

    public List<GameObject> inGamePlayervariation = new List<GameObject>();

    private int inGamePlayerValue;
    private void Awake()
    {
        foreach (Transform child in transform)
        {
            inGamePlayervariation.Add(child.gameObject);

        }
    }
    private void Start()
    {
        GamePlayerDefault();
        inGamePlayerValue = PlayerPrefs.GetInt("playervalue");
        inGamePlayervariation[inGamePlayerValue].SetActive(true);
        CinemachineCameraManager.instance.AssignCameraValue(inGamePlayerValue);


    }


    private void GamePlayerDefault()
    {
        for(int i=0;i<inGamePlayervariation.Count;i++)
        {
            inGamePlayervariation[i].SetActive(false);
        }
    }
}
