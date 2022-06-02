using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Threading.Tasks;
using UnityEngine.Networking;

public class NftItem : MonoBehaviour
{
    [SerializeField] private TMP_Text itemName;
    [SerializeField] private Image itemIcon;
    [SerializeField] private Button _button;

    private string address;
    private string tokenId;


    public void SetItemData(string name, Sprite sprite, string address, string tokenId)
    {
       // itemName.text = name;
        this.address = address;
        this.tokenId = tokenId;
        itemIcon.sprite = sprite;
        AddButtonListener();

    }


    private void AddButtonListener()
    {
        _button.onClick.RemoveAllListeners();
        _button.onClick.AddListener(() => {

            Application.OpenURL("https://testnets.opensea.io/assets/"+address+"/"+tokenId);
        });
    }


}
