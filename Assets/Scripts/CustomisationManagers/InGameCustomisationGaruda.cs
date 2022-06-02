using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameCustomisationGaruda : MonoBehaviour
{
    public Renderer GarudaWings;
    private int inGameGarudaValue;
    public List<Material> WingMat = new List<Material>();

    private void Start()
    {
        inGameGarudaValue = PlayerPrefs.GetInt("garudavalue");
        GarudaWings.material = WingMat[inGameGarudaValue];
        
    }

}
