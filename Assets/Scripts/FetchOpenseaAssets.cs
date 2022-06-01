using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using UnityEngine.Networking;

public class FetchOpenseaAssets : MonoBehaviour
{
    public List<NftItem> nftItems = new List<NftItem>();

       // string url = "https://testnets-api.opensea.io/api/v1/assets?order_direction=desc&offset=0&limit=100&collection=untitled-collection-8782113";
        string url = "https://testnets-api.opensea.io/api/v1/assets?order_direction=desc&offset=0&limit=100&collection=monster-mukti-nft-collection";
    Coroutine assetRoutine = null;

    private void OnEnable()
    {
        WalletLoginHandler.OnLoggedIn += DownloadOpenseaAssets;
    }

    public void DownloadOpenseaAssets()
    {
        if (assetRoutine != null)
            StopCoroutine(assetRoutine);

        assetRoutine = StartCoroutine(GetAssetData());
    }

    IEnumerator GetAssetData()
    {
       // Debug.Log("I am in");
        //Loadder.Instance.StartLoader();
        using (UnityWebRequest webRequest = UnityWebRequest.Get(url))
        {
            // Request and wait for the desired page.
            yield return webRequest.SendWebRequest();

            if(webRequest.result == UnityWebRequest.Result.ConnectionError)
            {
                Debug.Log("Connection Error");
            }else if(webRequest.result == UnityWebRequest.Result.Success)
            {
               // Debug.Log(webRequest.downloadHandler.text);

                NftModel response = JsonConvert.DeserializeObject<NftModel>(webRequest.downloadHandler.text);
                //Debug.Log(response.assets[0].token_id);
                
                UpdateItemData(response);
            }
        }

    }


    private void UpdateItemData(NftModel response)
    {
       // Debug.Log(response.assets.Count);
       // Loadder.Instance.StopLoader();
        for (int i=0;i<response.assets.Count;i++)
        {
            nftItems[i].SetItemData(response.assets[i].name, response.assets[i].image_url , response.assets[i].asset_contract.address, response.assets[i].token_id);
        }
    }


    private void OnDisable()
    {
        WalletLoginHandler.OnLoggedIn -= DownloadOpenseaAssets;
    }

}





// Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
public class Asset
{
    public int id { get; set; }
    public int num_sales { get; set; }
    public object background_color { get; set; }
    public string image_url { get; set; }
    public string image_preview_url { get; set; }
    public string image_thumbnail_url { get; set; }
    public object image_original_url { get; set; }
    public object animation_url { get; set; }
    public object animation_original_url { get; set; }
    public string name { get; set; }
    public string description { get; set; }
    public string external_link { get; set; }
    public AssetContract asset_contract { get; set; }
    public string permalink { get; set; }
    public Collection collection { get; set; }
    public object decimals { get; set; }
    public object token_metadata { get; set; }
    public bool is_nsfw { get; set; }
    public Owner owner { get; set; }
    public object sell_orders { get; set; }
    public object seaport_sell_orders { get; set; }
    public Creator creator { get; set; }
    public List<object> traits { get; set; }
    public object last_sale { get; set; }
    public object top_bid { get; set; }
    public object listing_date { get; set; }
    public bool is_presale { get; set; }
    public object transfer_fee_payment_token { get; set; }
    public object transfer_fee { get; set; }
    public string token_id { get; set; }
}

public class AssetContract
{
    public string address { get; set; }
    public string asset_contract_type { get; set; }
    public DateTime created_date { get; set; }
    public string name { get; set; }
    public object nft_version { get; set; }
    public string opensea_version { get; set; }
    public int owner { get; set; }
    public string schema_name { get; set; }
    public string symbol { get; set; }
    public object total_supply { get; set; }
    public object description { get; set; }
    public object external_link { get; set; }
    public object image_url { get; set; }
    public bool default_to_fiat { get; set; }
    public int dev_buyer_fee_basis_points { get; set; }
    public int dev_seller_fee_basis_points { get; set; }
    public bool only_proxied_transfers { get; set; }
    public int opensea_buyer_fee_basis_points { get; set; }
    public int opensea_seller_fee_basis_points { get; set; }
    public int buyer_fee_basis_points { get; set; }
    public int seller_fee_basis_points { get; set; }
    public object payout_address { get; set; }
}

public class Collection
{
    public object banner_image_url { get; set; }
    public object chat_url { get; set; }
    public DateTime created_date { get; set; }
    public bool default_to_fiat { get; set; }
    public string description { get; set; }
    public string dev_buyer_fee_basis_points { get; set; }
    public string dev_seller_fee_basis_points { get; set; }
    public object discord_url { get; set; }
    public DisplayData display_data { get; set; }
    public object external_url { get; set; }
    public bool featured { get; set; }
    public object featured_image_url { get; set; }
    public bool hidden { get; set; }
    public string safelist_request_status { get; set; }
    public string image_url { get; set; }
    public bool is_subject_to_whitelist { get; set; }
    public object large_image_url { get; set; }
    public object medium_username { get; set; }
    public string name { get; set; }
    public bool only_proxied_transfers { get; set; }
    public string opensea_buyer_fee_basis_points { get; set; }
    public string opensea_seller_fee_basis_points { get; set; }
    public object payout_address { get; set; }
    public bool require_email { get; set; }
    public object short_description { get; set; }
    public string slug { get; set; }
    public object telegram_url { get; set; }
    public object twitter_username { get; set; }
    public object instagram_username { get; set; }
    public object wiki_url { get; set; }
    public bool is_nsfw { get; set; }
}

public class Creator
{
    public User user { get; set; }
    public string profile_img_url { get; set; }
    public string address { get; set; }
    public string config { get; set; }
}

public class DisplayData
{
    public string card_display_style { get; set; }
}

public class Owner
{
    public User user { get; set; }
    public string profile_img_url { get; set; }
    public string address { get; set; }
    public string config { get; set; }
}

public class NftModel
{
    public List<Asset> assets { get; set; }
}

public class User
{
    public string username { get; set; }
}


