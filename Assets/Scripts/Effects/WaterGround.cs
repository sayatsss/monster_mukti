using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterGround : MonoBehaviour
{
    public float WFX_speed = 0.75f;
    public float WFY_speed = 0.75f;

    private Renderer WF_renderer;

    void Start()
    {
        WF_renderer = GetComponent<Renderer>();
    }

    void Update()
    {

        float TextureOffsetX = Time.time * WFX_speed;
        float TextureOffsetY = Time.time * WFY_speed;
        WF_renderer.material.SetTextureOffset("_MainTex", new Vector2(TextureOffsetX, TextureOffsetY));
    }
}
