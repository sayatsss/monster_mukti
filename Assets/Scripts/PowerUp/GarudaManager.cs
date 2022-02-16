using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GarudaManager : MonoBehaviour
{

    public static GarudaManager Instance;
    public float GarudaTimeSpan;
    public Image GarudaMeterProgress;


    private int value;

    private float temp_Garuda_Time_Span;

    private void Awake()
    {
        Instance = this;
    }

    private void Update()
    {
        value++;
        if(value>15)
        {
            GarudaTimeSpan--;
            value = 0;
        }
        temp_Garuda_Time_Span = GarudaTimeSpan / 100;

        if(GarudaTimeSpan==0)
        {
            StartCoroutine(CharacterStateManager.Instance.Garuda_Character_Transition());
            
        }
        
        GarudaMeterProgress.fillAmount = temp_Garuda_Time_Span;
    }


}
