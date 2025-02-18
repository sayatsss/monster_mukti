using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class GarudaControl : MonoBehaviour
{
    public float speed;
    private Vector3 velocity;

    private void Awake()
    {
        velocity = new Vector3(0, 0, 1);
    }

    private void Update()
    {
        Mathf.Clamp(this.gameObject.transform.position.x, -0.4f, 0.4f);
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -1.4f, 1.4f), transform.position.y, transform.position.z);

        // Mathf.Clamp(this.gameObject.transform.rotation.z, -10f, 10f);
        // transform.position = new Vector3(Mathf.Clamp(transform.position.x, -1.4f, 1.4f), transform.position.y, transform.position.z);
    }

    private void FixedUpdate()
    {
        velocity = new Vector3(0, 0, 1) * speed;//curSpeed += acceleration * Time.deltaTime;
        velocity.x = Input.acceleration.x * speed;
        velocity.x = Input.GetAxis("Horizontal") * speed;
        transform.Translate(velocity  * Time.deltaTime);
        
        
    }
}
