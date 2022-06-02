using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomisationLPlayerList : MonoBehaviour
{
    public static CustomisationLPlayerList instance;
    public List<GameObject> PlayerVariation = new List<GameObject>();
    public int Playervalue = 0;

    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        foreach (Transform child in transform)
        {
            PlayerVariation.Add(child.gameObject);

        }
    }

    public void PlayerActivate(int value)
    {
        PlayerDefault();
        PlayerVariation[value].SetActive(true);
        Playervalue = value;

    }
    private void PlayerDefault()
    {
        for(int i=0;i<PlayerVariation.Count;i++)
        {
            PlayerVariation[i].SetActive(false);
        }
    }
}
