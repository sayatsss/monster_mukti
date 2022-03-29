using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class concertPortal : MonoBehaviour
{
    public float Cloud_speed = 0.75f;

    private Renderer WF_renderer;

    void Start()
    {
        WF_renderer = GetComponent<Renderer>();
    }

    void Update()
    {

        float TextureOffset = Time.time * Cloud_speed;
        WF_renderer.material.SetTextureOffset("_MainTex", new Vector2(TextureOffset,0 ));
    }
}
