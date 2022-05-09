using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChariotAction : MonoBehaviour
{
    public static ChariotAction Instance;
    public float ChariotTimeSpan;
    public Image ChariotMeterProgress;


    private int value;

    private float temp_chariot_Time_Span;

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
        if (value < 0)
        {
            ChariotTimeSpan--;
            value = 5;
        }
        temp_chariot_Time_Span = ChariotTimeSpan / 100;

        if (ChariotTimeSpan == 0)
        {
            StartCoroutine(CharacterStateManager.Instance.Chariot_Player_Transition());

        }

        ChariotMeterProgress.fillAmount = temp_chariot_Time_Span;
    }


}
