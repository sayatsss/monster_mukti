using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{

    public static LevelGenerator instance;

    [Header("FlatPlatform prefabs ")]
    [SerializeField] private List<GameObject> platformPrefab;

    [Header("Tweakable values")]
    //flat platform z Value.
    [SerializeField] private float FPZ_Value;
    [SerializeField] private float SPZ_Value;
    [SerializeField] private float FPZO_Value;
    [SerializeField] private float SPY_Value;


    [Header("WaterBody values")]
    [SerializeField] private GameObject waterBody;
    [SerializeField] private float waterBodyYValue;
    private float _YValueW;

    //private float SPZ_Temp;

   

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
                Go.transform.position = new Vector3(0, SPY_Offset, i * FPZ_Value);
                Go.transform.rotation =Quaternion.Euler(0,0,0);
                SPY_Offset += SPY_Value;
                Z_Offset += FPZ_Value;
            }
            if(Go.name.Contains("Plain")|| Go.name.Contains("Broken"))
            {
                Go.transform.position = new Vector3(0, SPY_Offset, i * FPZ_Value);
                Go.transform.rotation = Quaternion.identity;
                Go.transform.rotation = Quaternion.Euler(0, 0, 0);
                Z_Offset += FPZ_Value;
            }
           
            if (Go.name.Contains("Damage"))
            {
                Go.transform.position = new Vector3(0, SPY_Offset, i * FPZ_Value);
               // Go.transform.rotation = Quaternion.identity;
                Go.transform.rotation = Quaternion.Euler(-90, 0, 0);
                Z_Offset += FPZ_Value;
            }
            if (Go.name.Contains("Cross"))
            {
                Go.transform.position = new Vector3(0, SPY_Offset, i * FPZ_Value);
                Go.transform.rotation = Quaternion.Euler(0, 180, 0);
                Go.transform.rotation = Quaternion.Euler(0, 0, 0);
                Z_Offset += FPZ_Value;
            }
            if (Go.name.Contains("Dual"))
            {
                Go.transform.position = new Vector3(0, SPY_Offset, i * FPZ_Value);
                Go.transform.rotation = Quaternion.identity;
                Go.transform.rotation = Quaternion.Euler(-90f, 0, 0);
                Z_Offset += FPZ_Value;
            }
            if (Go.name.Contains("Under") )
            {
                Go.transform.position = new Vector3(0, SPY_Offset, i * FPZ_Value);
                Go.transform.rotation = Quaternion.identity;
                Go.transform.rotation = Quaternion.Euler(0, 0, 0);
                Z_Offset += FPZ_Value;
            }

        }
    }

     public void ReCyclePlatform(GameObject platform)
    {
        if(platform.name.Contains("Step"))
        {
            platform.transform.position = new Vector3(0, SPY_Offset, Z_Offset);
            platform.transform.rotation = Quaternion.Euler(-0, 0, 0);
            SPY_Offset += SPY_Value;
            Z_Offset += FPZ_Value;
            _YValueW += waterBodyYValue;
            waterBody.transform.position = new Vector3(0, _YValueW, 0);
        }
       
        if (platform.name.Contains("Plain") || platform.name.Contains("Broken"))
        {
            platform.transform.position = new Vector3(0, SPY_Offset, Z_Offset);
            platform.transform.rotation = Quaternion.identity;
            platform.transform.rotation = Quaternion.Euler(0, 0, 0);
            Z_Offset += FPZ_Value;
            platform.GetComponent<CoinGenerator>().ReArrangeCoinManagers();
            platform.GetComponent<DestructableManager>().activeDestruc();
        }
       
        if (platform.name.Contains("Damage"))
        {
            platform.transform.position = new Vector3(0, SPY_Offset, Z_Offset);
            platform.transform.rotation = Quaternion.identity;
            platform.transform.rotation = Quaternion.Euler(-90, 0, 0);
            Z_Offset += FPZ_Value;
            //platform.GetComponent<CoinGenerator>().ReArrangeCoinManagers();
            platform.GetComponent<DestructableManager>().activeDestruc();

        }
        if (platform.name.Contains("Cross"))
        {
            platform.transform.position = new Vector3(0, SPY_Offset, Z_Offset);
            platform.transform.rotation = Quaternion.Euler(0, 180, 0);
            platform.transform.rotation = Quaternion.Euler(0, 0, 0);
            Z_Offset += FPZ_Value;
            platform.GetComponent<CoinGenerator>().ReArrangeCoinManagers();
            platform.GetComponent<DestructableManager>().activeDestruc();
        }
        if (platform.name.Contains("Dual"))
        {
            platform.transform.position = new Vector3(0, SPY_Offset, Z_Offset);
            platform.transform.rotation = Quaternion.identity;
            platform.transform.rotation = Quaternion.Euler(-90f, 0, 0);
            Z_Offset += FPZ_Value;
            platform.GetComponent<CoinGenerator>().ReArrangeCoinManagers();
           // platform.GetComponent<DestructableManager>().activeDestruc();
        }
        if (platform.name.Contains("Under"))
        {
            platform.transform.position = new Vector3(0, SPY_Offset, Z_Offset);
            platform.transform.rotation = Quaternion.identity;
            platform.transform.rotation = Quaternion.Euler(0, 0, 0);
            Z_Offset += FPZ_Value;
        }


    }
}
