using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PointLightEffect : MonoBehaviour
{
    private  Light spotLight;

    public float rotateSpeed = 0.1F;
    public float rotateAmount = 90.0F;
    public Quaternion startRotation;




    // Start is called before the first frame update
    void Start()
    {
        spotLight = this.gameObject.GetComponent<Light>();

        startRotation = transform.rotation;
        InvokeRepeating("ChangeColour", 2f, 4f);
    }

    private void ChangeColour()
    {
        spotLight.color = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
        
    }

    void FixedUpdate()
    {
        
        transform.rotation = Quaternion.Euler(Mathf.PingPong(Time.time * rotateSpeed, rotateAmount) + (rotateAmount / 2) + (startRotation.x), Mathf.PingPong(Time.time * rotateSpeed, rotateAmount) + (rotateAmount / 2) + (startRotation.y), Mathf.PingPong(Time.time * rotateSpeed, rotateAmount) + (rotateAmount / 2) + (startRotation.z));
    }
}
