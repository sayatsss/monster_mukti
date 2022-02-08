using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    public AudioSource BG;
    public AudioSource Door;
    public AudioSource CollectiveCollection;
    public AudioSource Playerjump;
    public AudioSource DamageLow;
    public AudioSource Slide;


    public static AudioManager Instance;

    private void Awake()
    {
        Instance = this;
    }






}
