using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomisaitonNChariotList : MonoBehaviour
{
    public static CustomisaitonNChariotList instance;
    public List<GameObject> ChariotVariationNFT = new List<GameObject>();
    public int ChariotNFTvalue = 0;

    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        foreach (Transform child in transform)
        {
            ChariotVariationNFT.Add(child.gameObject);

        }
    }

    public void ChariotNFTActivate(int value)
    {
        ChariotNFTDefault();
        ChariotVariationNFT[value].SetActive(true);
        ChariotNFTvalue = value;

    }
    private void ChariotNFTDefault()
    {
        for (int i = 0; i < ChariotVariationNFT.Count; i++)
        {
            ChariotVariationNFT[i].SetActive(false);
        }
    }
}
