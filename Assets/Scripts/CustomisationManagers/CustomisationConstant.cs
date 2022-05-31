using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomisationConstant : MonoBehaviour
{
    public static CustomisationConstant instance;

    [HideInInspector] public int playerValue;
    [HideInInspector] public int chariotValue;
    [HideInInspector] public int garudaValue;

    private void Awake()
    {
        instance = this;
       
    }
}
