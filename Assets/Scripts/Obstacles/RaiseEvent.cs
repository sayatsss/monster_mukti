using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaiseEvent : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag=="Player")
        {
            if(this.gameObject.transform.parent.GetComponent<PathEventmanager>().obstacleObject!=null)
            {
                this.gameObject.transform.parent.GetComponent<PathEventmanager>().obstacleObject.SetActive(true);
                StartCoroutine(SimpleCameraShakeInCinemachine.Instance.cameraAction());
            }
            else
            {
                StartCoroutine(SimpleCameraShakeInCinemachine.Instance.cameraAction());
                this.gameObject.transform.parent.GetComponent<PathEventmanager>().PillarArcAction();
            }
             

        }
    }
}
