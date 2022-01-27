using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EZCameraShake;

public class PlatfromView : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if(this.gameObject.name.Contains("End"))
            {
                LevelGenerator.instance.ReCyclePlatform(this.gameObject.transform.parent.gameObject);
            }

            if (this.gameObject.name.Contains("Start"))
            {
                //Debug.Log("Destruct start");
                this.gameObject.transform.parent.GetComponent<DestructableManager>().DestructAction();
                StartCoroutine(SimpleCameraShakeInCinemachine.Instance.cameraAction());
                //CameraShaker.Instance.ShakeOnce(4f, 4f, 0.1f, 1f);
            }
            if (this.gameObject.name.Contains("BridgePoint"))
            {
                int value = Random.Range(0, 3);


                if (value == 2)
                {
                    //Debug.Log("Destruct start");
                    this.gameObject.transform.parent.GetComponent<DestructionArc>().ArcDestruction();
                    
                }
            }

        }

    }
    
}
