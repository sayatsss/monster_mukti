using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{

    public static LevelGenerator instance;

    [Header("FlatPlatform prefabs and values")]
    [SerializeField] private List<GameObject> platformPrefab;
    //flat platform z Value.
    [SerializeField] private float FPZ_Value;

    [Header("StepPlatformPrefab prefabs and values")]
    [SerializeField] private List<GameObject> stepPlatformPrefab;

    [Header("CornerplatformPrefab prefabs and values")]
    [SerializeField] private List<GameObject> cornerplatformPrefab;

    public float Z_Offset;

    private void Awake()
    {
        instance = this;   
    }
    // Start is called before the first frame update
    void Start()
    {
        for(int i=0;i<platformPrefab.Count;i++)
        {
            Instantiate(platformPrefab[i], new Vector3(0, 0, i * FPZ_Value), Quaternion.identity);
            Z_Offset += FPZ_Value;
        }
    }

     public void ReCyclePlatform(GameObject platform,float z_value)
    {
      
        platform.transform.position = new Vector3(0, 0, Z_Offset);
        Z_Offset += z_value;
    }
}
