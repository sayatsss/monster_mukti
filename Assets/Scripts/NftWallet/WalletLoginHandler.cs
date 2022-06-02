using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class WalletLoginHandler : MonoBehaviour
{
    public bool isLoggedIn;

    public static Action OnLoggedIn;

    public void OnLogin()
    {
        if (PlayerPrefs.HasKey("Account"))
        {
            if (!string.IsNullOrEmpty(PlayerPrefs.GetString("Account")))
            {
                isLoggedIn = true;
                OnLoggedIn?.Invoke();
                return;
            }
        }
        OnWalletLogin();
    }

    async public void OnWalletLogin()
    {
        // get current timestamp
        int timestamp = (int)(System.DateTime.UtcNow.Subtract(new System.DateTime(1970, 1, 1))).TotalSeconds;
        // set expiration time
        int expirationTime = timestamp + 60;
        // set message
        string message = expirationTime.ToString();
        // sign message
        string signature = await Web3Wallet.Sign(message);
        // verify account
        string account = await EVM.Verify(message, signature);
        int now = (int)(System.DateTime.UtcNow.Subtract(new System.DateTime(1970, 1, 1))).TotalSeconds;
        // validate
        if (account.Length == 42 && expirationTime >= now)
        {
            // save account
            PlayerPrefs.SetString("Account", account);
            isLoggedIn = true;
            Debug.Log(account);
            OnLoggedIn?.Invoke();
        }
    }
}
