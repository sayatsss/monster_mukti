using UnityEngine;
using PathCreation;

public class PathFollowe : MonoBehaviour

{

    public PathCreator pathcreator;
    public float travelSpeed=5;
    float distanceTraveled;


    public bool moveChariot=false;
    
    void Update()
    {
        if(moveChariot)
        {
            distanceTraveled += travelSpeed * Time.deltaTime;
            transform.position = pathcreator.path.GetPointAtDistance(distanceTraveled);
            transform.rotation = pathcreator.path.GetRotationAtDistance(distanceTraveled);
        }
    }
}
