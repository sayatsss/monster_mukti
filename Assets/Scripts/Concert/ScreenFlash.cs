using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScreenFlash : MonoBehaviour
{
    public Color flashColour = new Color(1f, 0f, 0f, 0.1f);
    //The values above are in the order of R - G - B - Alpha
    public float flashSpeed = 5f;
    //The time the flash will last for
    public Image flashImage;


    public bool Flash;


    public static ScreenFlash Instance;

    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        flashImage.gameObject.SetActive(false);
    }
    void Update()
    {
        if (Flash)
        {
            Debug.Log("hola");
            
        }
        else
        {
            flashImage.color = Color.Lerp(flashImage.color, Color.clear, flashSpeed * Time.deltaTime);
        }
        //Flash = false;

    }
}
