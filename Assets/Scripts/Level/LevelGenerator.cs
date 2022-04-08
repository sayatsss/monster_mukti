using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{

    public static LevelGenerator instance;

    [Header("FlatPlatformL1 prefabs ")]
    [SerializeField] private List<GameObject> platformPrefabL1;

    [Header("FlatPlatformL2 prefabs ")]
    [SerializeField] private List<GameObject> platformPrefabL2;

    [Header("FlatPlatformL3 prefabs ")]
    [SerializeField] private List<GameObject> platformPrefabL3;


    [Header("FlatPlatform prefabs ")]
    [SerializeField] private List<GameObject> platformPrefab;





    [Header("WaterBody values")]
    [SerializeField] private GameObject waterBody;
    [SerializeField] private float waterBodyYValue;
    private float _YValueW;



    [HideInInspector] public float Z_Offset, Y_Offset;


    private void Awake()
    {
        instance = this;
        //StartCoroutine(ActivatePlatform());
        for (int i = 0; i < platformPrefab.Count; i++)
        {
            GameObject Go = Instantiate(platformPrefab[i]);
            SetTileValue(Go);

        }

    }


   


    public void SetTileValue(GameObject gameObject)
    {
        
        gameObject.transform.position = new Vector3(0, Y_Offset, Z_Offset);
        gameObject.transform.rotation = Quaternion.Euler(gameObject.GetComponent<TilesValues>().RotationValue);
        //waterBody.transform.position = new Vector3(0,Y_Offset-5, 0);
        Y_Offset += gameObject.GetComponent<TilesValues>().TileYValue;
        Z_Offset += gameObject.GetComponent<TilesValues>().TileZValue;

    }

    public void ReCyclePlatform(GameObject platform)
    {
        SetTileValue(platform);

        if (platform.GetComponent<CoinGenerator>()!=null)
        {
            platform.GetComponent<CoinGenerator>().ReArrangeCoinManagers();
        }
        if (platform.GetComponent<DestructableManager>() != null)
        {
            platform.GetComponent<DestructableManager>().activeDestruc();
        }


    }

    void Shuffle<T>(List<T> inputList)
    {
        for (int i = 0; i < inputList.Count - 1; i++)
        {
            T temp = inputList[i];
            int rand = Random.Range(i, inputList.Count);
            inputList[i] = inputList[rand];
            inputList[rand] = temp;
        }
    }
}
