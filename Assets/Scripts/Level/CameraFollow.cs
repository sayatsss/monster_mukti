using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    public bool Char;
    public GameObject Camera;
   

   // public float smoothSpeed = 0.125f;
    public Vector3 offset;

    void FixedUpdate()
    {
        
            Camera.transform.position =  this.gameObject.transform.position + offset;
      
        
    }

}