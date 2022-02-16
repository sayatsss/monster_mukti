using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AboveCloiudCoinAction : MonoBehaviour
{

    public static AboveCloiudCoinAction Instance;
    public GameObject aboveCloudCoins;
    public int generateValue;

    


    public int FPZ_Value;

    private int Z_offset;


    private void Awake()
    {
        Instance = this;
       
        for (int i = 0; i < generateValue; i++)
        {
            GameObject Go = Instantiate(aboveCloudCoins);


            Go.transform.position = new Vector3(0, 98f, i * FPZ_Value);
            Z_offset += FPZ_Value;

        }
    }
    
    public void RecycleCoinsAboveCloud(GameObject coinChunks)
    {
        coinChunks.transform.position = new Vector3(0, 98f, Z_offset);
        Z_offset += FPZ_Value;
        
    }
    
}
