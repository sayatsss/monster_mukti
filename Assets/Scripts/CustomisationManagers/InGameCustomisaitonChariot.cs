using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameCustomisaitonChariot : MonoBehaviour
{
    public Renderer ChariotRend;
    private int inGameChariotValue;
    public GameObject chariot, boat;
    public List<Material> ChariotMat = new List<Material>();

    private void Start()
    {
        inGameChariotValue = PlayerPrefs.GetInt("chariotvalue");
        if(inGameChariotValue>2)
        {
            chariot.SetActive(false);
            boat.SetActive(true);
        }
        else
        {
            boat.SetActive(false);
            chariot.SetActive(true);
            ChariotRend.material = ChariotMat[inGameChariotValue];
        }
       

    }
}
