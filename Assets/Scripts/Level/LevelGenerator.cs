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
    [SerializeField] private float SPZ_Value;
    [SerializeField] private float FPZO_Value;
    [SerializeField] private float SPY_Value;

    //private float SPZ_Temp;

    [Header("StepPlatformPrefab prefabs and values")]
    [SerializeField] private List<GameObject> stepPlatformPrefab;

    [Header("CornerplatformPrefab prefabs and values")]
    [SerializeField] private List<GameObject> cornerplatformPrefab;

    [HideInInspector]public float X_Offset,Z_Offset,Y_Offset, SPZ_Offset,SPY_Offset;

    //float value to decide the type of platform.
    private float platformR_Value = 0f;

    private void Awake()
    {
        instance = this;   
    }
    // Start is called before the first frame update
    void Start()
    {
        for(int i=0;i< platformPrefab.Count; i++)
        {
            GameObject Go = Instantiate(platformPrefab[i]);

            if(Go.name.Contains("Step"))
            {
                SPZ_Offset += SPZ_Value;
                Go.transform.position = new Vector3(0, SPY_Offset, i * FPZ_Value - SPZ_Offset);
                Go.transform.rotation =Quaternion.Euler(0,180,0);
                SPY_Offset += SPY_Value;
                SPZ_Offset -= FPZO_Value;
                Z_Offset += FPZ_Value - SPZ_Offset;
            }
            if(Go.name.Contains("Plain")|| Go.name.Contains("Broken"))
            {
                Go.transform.position = new Vector3(0, SPY_Offset, i * FPZ_Value - SPZ_Offset);
                Go.transform.rotation = Quaternion.identity;
                Go.transform.rotation = Quaternion.Euler(0, 0, 0);
                Z_Offset += FPZ_Value;
            }
            if (Go.name.Contains("Damage"))
            {
                Go.transform.position = new Vector3(0, SPY_Offset, i * FPZ_Value - SPZ_Offset);
                Go.transform.rotation = Quaternion.identity;
                Go.transform.rotation = Quaternion.Euler(-90, 0, 0);
                Z_Offset += FPZ_Value;
            }
            if (Go.name.Contains("Cross"))
            {
                Go.transform.position = new Vector3(0, SPY_Offset, i * FPZ_Value - SPZ_Offset);
                Go.transform.rotation = Quaternion.Euler(0, 180, 0);
                Go.transform.rotation = Quaternion.Euler(0, 0, 0);
                Z_Offset += FPZ_Value;
            }
          
        }
    }

     public void ReCyclePlatform(GameObject platform)
    {
        if(platform.name.Contains("Step"))
        {

        }
       
        if (platform.name.Contains("Plain") || platform.name.Contains("Broken"))
        {
            platform.transform.position = new Vector3(0, SPY_Offset, Z_Offset);
            platform.transform.rotation = Quaternion.identity;
            platform.transform.rotation = Quaternion.Euler(0, 0, 0);
            Z_Offset += FPZ_Value;
            platform.GetComponent<CoinGenerator>().ReArrangeCoinManagers();
        }
        if (platform.name.Contains("Damage"))
        {
            platform.transform.position = new Vector3(0, SPY_Offset, Z_Offset);
            platform.transform.rotation = Quaternion.identity;
            platform.transform.rotation = Quaternion.Euler(-90, 0, 0);
            Z_Offset += FPZ_Value;
            platform.GetComponent<CoinGenerator>().ReArrangeCoinManagers();
        }
        if (platform.name.Contains("Cross"))
        {
            platform.transform.position = new Vector3(0, SPY_Offset, Z_Offset);
            platform.transform.rotation = Quaternion.Euler(0, 180, 0);
            platform.transform.rotation = Quaternion.Euler(0, 0, 0);
            Z_Offset += FPZ_Value;
        }

    }
}
