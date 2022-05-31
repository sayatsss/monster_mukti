using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CustomisationManager : MonoBehaviour
{
   
    [SerializeField] private List<GameObject> WalletPanels = new List<GameObject>();
    [SerializeField] private List<GameObject> LocalOptions = new List<GameObject>();

    public void WalletChange(int value)
    {
        WalletDefault();
        WalletPanels[value].SetActive(true);
    }

    private void Start()
    {
        WalletChange(0);
        OptionChange(0);
    }
    private void WalletDefault()
    {
        for(int i=0;i<WalletPanels.Count;i++)
        {
            WalletPanels[i].SetActive(false);
        }
    }
    private void LocalOptionsDefault()
    {
        for (int i = 0; i < WalletPanels.Count; i++)
        {
            LocalOptions[i].SetActive(false);
           // LocalOptions[i].GetComponent<Image>().color = SelectedColour;
        }
    }
    public void OptionChange(int value)
    {
        LocalOptionsDefault();
        LocalOptions[value].SetActive(true);
        //LocalOptions[value].GetComponent<Image>().color = SelectedColour;
    }
    public void CustomisationCloseButton()
    {
        StartCoroutine(PlayerCustomisation.instance.loadSceneTrans(1));
       
    }
    public void CustomisationDoneButton()
    {
        StartCoroutine(PlayerCustomisation.instance.loadSceneTrans(1));
        CustomisationConstant.instance.playerValue = CustomisationPlayer.instance.Playervalue;
        PlayerPrefs.SetInt("playervalue", CustomisationConstant.instance.playerValue);
    }
}
