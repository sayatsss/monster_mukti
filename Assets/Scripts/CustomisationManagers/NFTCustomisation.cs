using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Itemcategory
{
    None,
    Vayu,
    Chariot,
    Garuda
}

public class NFTCustomisation : MonoBehaviour
{
    [SerializeField] private List<GameObject> NFTOptions = new List<GameObject>();
    [SerializeField] private List<GameObject> NFTAssetsView = new List<GameObject>();

    [SerializeField] private List<NftItem> nftClothList = new List<NftItem>();
    [SerializeField] private List<NftItem> nftGarudaList = new List<NftItem>();
    [SerializeField] private List<NftItem> nftHorseList = new List<NftItem>();


    private List<NftItemData> nftItemDatas;

    private void Start()
    {
        NFTOptionChange(0);
    }
    private void NFTOptionDefault()
    {
        for(int i=0;i<NFTOptions.Count;i++)
        {
            NFTOptions[i].SetActive(false);
        }


    }

    private void NFTAssetOption()
    {
        for (int i = 0; i < NFTAssetsView.Count; i++)
        {
            NFTAssetsView[i].SetActive(false);

        }
    }
    public void NFTOptionChange(int value)
    {
        NFTOptionDefault();
        NFTOptions[value].SetActive(true);

        NFTAssetOption();
        NFTAssetsView[value].SetActive(true);

        Debug.Log(NFTOptions[value].name);
        if(value == 0)
        {
            nftItemDatas = FetchOpenseaAssets.Insatance.GetItemsByType(Itemcategory.Vayu.ToString());
            Debug.Log("11111111 ::: "+nftItemDatas.Count);
            for (int i = 0; i < nftItemDatas.Count; i++)
            {
                nftClothList[i].SetItemData(nftItemDatas[i].itemName, nftItemDatas[i].itemSprite,
                    nftItemDatas[i].address, nftItemDatas[i].itemToken);
            }

        }
        else if(value == 1)
        {
            nftItemDatas = FetchOpenseaAssets.Insatance.GetItemsByType(Itemcategory.Garuda.ToString());
            Debug.Log("222222 ::: " + nftItemDatas.Count);
            for (int i = 0; i < nftItemDatas.Count; i++)
            {
                nftGarudaList[i].SetItemData(nftItemDatas[i].itemName, nftItemDatas[i].itemSprite,
                    nftItemDatas[i].address, nftItemDatas[i].itemToken);
            }
        }
        else if(value == 2)
        {
            nftItemDatas = FetchOpenseaAssets.Insatance.GetItemsByType(Itemcategory.Chariot.ToString());
            Debug.Log("333333 ::: " + nftItemDatas.Count);
            for (int i = 0; i < nftItemDatas.Count; i++)
            {
                nftHorseList[i].SetItemData(nftItemDatas[i].itemName, nftItemDatas[i].itemSprite,
                    nftItemDatas[i].address, nftItemDatas[i].itemToken);
            }
        }

        
    }
}
