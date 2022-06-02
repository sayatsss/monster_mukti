using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomisationLChariotList : MonoBehaviour
{
    public static CustomisationLChariotList instance;
    public List<GameObject> ChariotVariation = new List<GameObject>();
    public int Chariotvalue = 0;

    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        foreach (Transform child in transform)
        {
            ChariotVariation.Add(child.gameObject);

        }
    }

    public void ChariotActivate(int value)
    {
        ChariotDefault();
        ChariotVariation[value].SetActive(true);
        Chariotvalue = value;

    }
    private void ChariotDefault()
    {
        for (int i = 0; i < ChariotVariation.Count; i++)
        {
            ChariotVariation[i].SetActive(false);
        }
    }
}
