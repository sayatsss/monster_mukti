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




    [Header("WaterBody values")]
    [SerializeField] private GameObject waterBody;
    [SerializeField] private float waterBodyYValue;
    private float _YValueW;



    [HideInInspector] public float Z_Offset, Y_Offset;


    private void Awake()
    {
        instance = this;
        for (int i = 0; i < platformPrefabL1.Count; i++)
        {
            platformPrefabL1[i].SetActive(false);
           
        }
        for (int i = 0; i < platformPrefabL2.Count; i++)
        {
            platformPrefabL2[i].SetActive(false);
            
        }
        for (int i = 0; i < platformPrefabL3.Count; i++)
        {
            platformPrefabL3[i].SetActive(false);
            
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        
        //Shuffle(platformPrefabL1);
        //Shuffle(platformPrefabL2);
        //Shuffle(platformPrefabL3);
        for (int i=0;i< platformPrefabL1.Count; i++)
        {
            GameObject Go = platformPrefabL1[i];
            SetTileValue(Go);
        }
        for (int i = 0; i < platformPrefabL2.Count; i++)
        {
            GameObject Go = platformPrefabL2[i];
            SetTileValue(Go);
        }
        for (int i = 0; i < platformPrefabL3.Count; i++)
        {
            GameObject Go = platformPrefabL3[i];
            SetTileValue(Go);
        }
    }

    public void SetTileValue(GameObject gameObject)
    {
        gameObject.SetActive(true);
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
