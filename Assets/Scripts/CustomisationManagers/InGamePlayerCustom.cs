using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGamePlayerCustom : MonoBehaviour
{
    public Renderer playerCloth,ChariotPlayer;
    private int inGamePlayerValue;
    public List<Material> ClothMat = new List<Material>();

    private void Start()
    {
        inGamePlayerValue = PlayerPrefs.GetInt("playervalue");
        playerCloth.material = ClothMat[inGamePlayerValue];
        ChariotPlayer.material= ClothMat[inGamePlayerValue];

    }
   
   
    
    
}
