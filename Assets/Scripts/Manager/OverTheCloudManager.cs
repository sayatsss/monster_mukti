using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OverTheCloudManager : MonoBehaviour
{

    public static OverTheCloudManager instance;
    public List<GameObject> overTheCloudObject = new List<GameObject>();

    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        overTheCloudObject.AddRange(GameObject.FindGameObjectsWithTag("Cloud"));
        DeactivateOverTheCloud();
    }


    public void activateOverTheCloud()
    {
        for(int i=0;i<overTheCloudObject.Count;i++)
        {
            overTheCloudObject[i].SetActive(true);
        }
    }
    public void DeactivateOverTheCloud()
    {
        for (int i = 0; i < overTheCloudObject.Count; i++)
        {
            overTheCloudObject[i].SetActive(false);
        }
    }

}
