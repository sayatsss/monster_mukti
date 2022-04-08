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
                
                int value = Random.Range(0, 3);
                //Debug.Log(value);
                if(value==2||value==3)
                {
                    StartCoroutine(this.gameObject.transform.parent.GetComponent<PathEventmanager>().BlockAction());
                    StartCoroutine(SimpleCameraShakeInCinemachine.Instance.cameraAction());
                }
               
            }
            else
            {
                StartCoroutine(SimpleCameraShakeInCinemachine.Instance.cameraAction());
                StartCoroutine(this.gameObject.transform.parent.GetComponent<PathEventmanager>().PillarArcAction());
                
            }
             

        }
    }
}
