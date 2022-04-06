using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DestructionArc : MonoBehaviour
{
    public List<GameObject> DestructableElement = new List<GameObject>();

    private void OnEnable()
    {
        foreach (Transform child in transform)
        {
            if (child.name.Contains("Arch"))
            {
                DestructableElement.Add(child.transform.gameObject);
            }

        }
    }
    public void activeDestruc()
    {
        for (int i = 0; i < DestructableElement.Count; i++)
        {
            DestructableElement[i].SetActive(true);
        }
    }

    public void ArcDestruction()
    {
        StartCoroutine(SimpleCameraShakeInCinemachine.Instance.cameraAction());
        //StartCoroutine(UIManager.instance.BloodScreenSplash());
       
        //DestructableElement[0].GetComponent<Destructable>().Destruct();
        
    }
   
}
