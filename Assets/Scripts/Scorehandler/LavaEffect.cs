using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaEffect : MonoBehaviour
{
    public float LF_speed = 0.75f;

    private Renderer WF_renderer;

    void Start()
    {
        WF_renderer = GetComponent<Renderer>();
    }

    void Update()
    {

        float TextureOffset = Time.time * LF_speed;
        WF_renderer.material.SetTextureOffset("_MainTex", new Vector2(TextureOffset, 0));
    }
}
