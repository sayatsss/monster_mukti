using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CustomisationManager : MonoBehaviour
{
   
    [SerializeField] private List<GameObject> WalletPanels = new List<GameObject>();
    //[SerializeField] private List<GameObject> walletButtons = new List<GameObject>();
    [SerializeField] private List<GameObject> AssetType = new List<GameObject>();
    [SerializeField] private List<GameObject> LocalOptions = new List<GameObject>();
    [SerializeField] private List<GameObject> LocalAssetsView = new List<GameObject>();



    

    public void WalletChange(int value)
    {
        WalletDefault();
        WalletPanels[value].SetActive(true);
        AssetDefault();
        AssetType[value].SetActive(true);
        //ButtonWalletDefault();
       // walletButtons[value].SetActive(true);

    }

    //private void ButtonWalletDefault()
    //{
    //    for (int i = 0; i < walletButtons.Count; i++)
    //    {
    //        walletButtons[i].SetActive(false);
    //    }
    //}

    private void Start()
    {
        PlayerPrefs.DeleteAll();
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
    private void AssetDefault()
    {
        for (int i = 0; i < AssetType.Count; i++)
        {
            AssetType[i].SetActive(false);
        }
    }

    private void LocalAssetOption()
    {
        for (int i = 0; i < LocalAssetsView.Count; i++)
        {
            LocalAssetsView[i].SetActive(false);

        }
    }
   
    private void LocalOptionsDefault()
    {
        for (int i = 0; i < LocalOptions.Count; i++)
        {
            LocalOptions[i].SetActive(false);
          
        }
    }
    public void OptionChange(int value)
    {
        LocalOptionsDefault();
        LocalAssetOption();
        LocalOptions[value].SetActive(true);
        LocalAssetsView[value].SetActive(true);

    }
    public void CustomisationCloseButton()
    {
        StartCoroutine(PlayerCustomisation.instance.loadSceneTrans(1));
       
    }
    public void CustomisationDoneButton()
    {
        //CustomisationConstant.instance.playerValue = CustomisationLPlayerList.instance.Playervalue;
        // CustomisationConstant.instance.chariotValue = CustomisationLChariotList.instance.Chariotvalue;
       // CustomisationConstant.instance.garudaValue = CustomisationLGarudaList.instance.Garudavalue;
        PlayerPrefs.SetInt("playervalue", CustomisationConstant.instance.playerValue);
        PlayerPrefs.SetInt("chariotvalue", CustomisationConstant.instance.chariotValue);
        PlayerPrefs.SetInt("garudavalue", CustomisationConstant.instance.garudaValue);
        StartCoroutine(PlayerCustomisation.instance.loadSceneTrans(1));
    }
    
}
