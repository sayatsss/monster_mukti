using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class CinemachineRefence : MonoBehaviour
{
    public static CinemachineRefence instance;
    public List<Transform> playerBodyRefence= new List<Transform>();
    public List<Transform> playerRefence = new List<Transform>();

    private void Awake()
    {
        instance = this;
    }
    
}
