using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomisationNGarudaList : MonoBehaviour
{
    public static CustomisationNGarudaList instance;
    public List<GameObject> GarudaNFTVariation = new List<GameObject>();
    private int GarudaNFTvalue = 6;

    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        foreach (Transform child in transform)
        {
            GarudaNFTVariation.Add(child.gameObject);

        }
    }

    public void GarudaNFTActivate(int value)
    {
        GarudaNFTDefault();
        GarudaNFTVariation[value].SetActive(true);
        GarudaNFTvalue = GarudaNFTvalue+value;
        CustomisationConstant.instance.garudaValue = GarudaNFTvalue;

    }
    private void GarudaNFTDefault()
    {
        for (int i = 0; i < GarudaNFTVariation.Count; i++)
        {
            GarudaNFTVariation[i].SetActive(false);
        }
    }
}
