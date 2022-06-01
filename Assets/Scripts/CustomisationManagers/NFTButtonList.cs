using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NFTButtonList : MonoBehaviour
{

    public List<Image> vayuOutfit = new List<Image>();
    public List<Image> GarudaOutfit = new List<Image>();
    public List<Image> Chariots = new List<Image>();

    public static NFTButtonList instance;

    private void Awake()
    {
        instance = this;
    }
}
