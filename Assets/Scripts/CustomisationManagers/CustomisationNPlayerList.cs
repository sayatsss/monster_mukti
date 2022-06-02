using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomisationNPlayerList : MonoBehaviour
{
    public static CustomisationNPlayerList instance;
    public List<GameObject> PlayerNFTVariation = new List<GameObject>();
    private int PlayerNFTvalue = 5;

    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        foreach (Transform child in transform)
        {
            PlayerNFTVariation.Add(child.gameObject);

        }
    }

    public void PlayerNFTActivate(int value)
    {
        PlayerNFTDefault();
        PlayerNFTVariation[value].SetActive(true);
        PlayerNFTvalue = PlayerNFTvalue+value;
        Debug.Log(PlayerNFTvalue);
        CustomisationConstant.instance.playerValue = PlayerNFTvalue;

    }
    private void PlayerNFTDefault()
    {
        for (int i = 0; i < PlayerNFTVariation.Count; i++)
        {
            PlayerNFTVariation[i].SetActive(false);
        }
    }
}
