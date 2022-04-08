using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class JetFollow : MonoBehaviour
{
    public static JetFollow instance;

    public GameObject Jet;
   
    // public float smoothSpeed = 0.125f;
    public Vector3 offset;


    private void Awake()
    {
        instance = this;
        //Jet.SetActive(false);
    }
    void FixedUpdate()
    {

        if(GameStart.instance.Game_Start)
        {
            Jet.transform.position = this.gameObject.transform.position + offset;
        }
        

    }

    
}
