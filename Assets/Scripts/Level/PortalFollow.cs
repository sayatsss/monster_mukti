using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PortalFollow : MonoBehaviour
{
    public static PortalFollow instance;

    public GameObject Portal;
    public bool portalActivate;

    // public float smoothSpeed = 0.125f;
    public Vector3 offset;


    private void Awake()
    {
        instance = this;
        Portal.transform.DOScale(0.01f, 0.1f);
        Portal.SetActive(false);
    }
    void FixedUpdate()
    {
        if (!portalActivate)
        {
            Portal.transform.position = this.gameObject.transform.position + offset;
        }

    }

    public IEnumerator ActivatePortal()
    {
        Portal.transform.DOScale(1f, 4f);
        Portal.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        portalActivate = true;
        
    }
}
