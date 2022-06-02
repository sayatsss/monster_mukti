using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameCustomisaitonChariot : MonoBehaviour
{
    public Renderer ChariotRend;
    private int inGameChariotValue;
    public List<Material> ChariotMat = new List<Material>();

    private void Start()
    {
        inGameChariotValue = PlayerPrefs.GetInt("chariotvalue");
        ChariotRend.material = ChariotMat[inGameChariotValue];

    }
}
