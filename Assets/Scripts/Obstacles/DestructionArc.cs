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
   
}
