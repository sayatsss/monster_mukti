using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class AssetAnimation : MonoBehaviour
{

    [SerializeField]private GameObject Doorleft, DoorRight;
    public static AssetAnimation Instance;

    private void Awake()
    {
        Instance = this;
    }

   public void DoorAnimation()
    {
        Doorleft.transform.DOLocalRotate(new Vector3(-90, 0, 90), 0.8f);
        DoorRight.transform.DOLocalRotate(new Vector3(-90, 0, -90), 0.8f);
    }
}
