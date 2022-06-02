using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomisationLGarudaList : MonoBehaviour
{
    public static CustomisationLGarudaList instance;
    public List<GameObject> GarudaVariation = new List<GameObject>();
    private int Garudavalue = 0;

    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        foreach (Transform child in transform)
        {
            GarudaVariation.Add(child.gameObject);

        }
    }

    public void GarudaActivate(int value)
    {
        GarudaDefault();
        GarudaVariation[value].SetActive(true);
        Garudavalue = value;
        CustomisationConstant.instance.garudaValue = Garudavalue;

    }
    private void GarudaDefault()
    {
        for (int i = 0; i < GarudaVariation.Count; i++)
        {
            GarudaVariation[i].SetActive(false);
        }
    }
}
