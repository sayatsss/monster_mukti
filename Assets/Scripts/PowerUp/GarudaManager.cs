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
    private void Start()
    {
        value = 150;
    }
    private void FixedUpdate()
    {
        value--;
        if(value<0)
        {
            GarudaTimeSpan--;
            value = 5;
        }
        temp_Garuda_Time_Span = GarudaTimeSpan / 100;

        if(GarudaTimeSpan==0)
        {
            StartCoroutine(CharacterStateManager.Instance.Garuda_Character_Transition());
            
        }
        
        GarudaMeterProgress.fillAmount = temp_Garuda_Time_Span;
    }


}
