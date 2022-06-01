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
    [SerializeField] private RawImage itemIcon;
    [SerializeField] private Button _button;

    public string address;
    public string tokenId;


    public void SetItemData(string name, string image_url, string address, string tokenId)
    {
       // itemName.text = name;
        this.address = address;
        this.tokenId = tokenId;
       // StartCoroutine(DownloadImage(image_url));

       
    }

    IEnumerator DownloadImage(string url)
    {
        //Loadder.Instance.StartLoader();
        UnityWebRequest request = UnityWebRequestTexture.GetTexture(url);
        yield return request.SendWebRequest();
        if (request.result == UnityWebRequest.Result.ConnectionError || request.result == UnityWebRequest.Result.ProtocolError)
            Debug.Log(request.error);
        else
        {
            itemIcon.texture = ((DownloadHandlerTexture)request.downloadHandler).texture;
            //Loadder.Instance.StopLoader();
            AddButtonListener();

        }
    }

    private void AddButtonListener()
    {
        _button.onClick.RemoveAllListeners();
        _button.onClick.AddListener(() => {

           // Application.OpenURL("https://testnets.opensea.io/collection/untitled-collection-8782113");
            Application.OpenURL("https://testnets.opensea.io/assets/"+address+"/"+tokenId);
        });
    }


}
