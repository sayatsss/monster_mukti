using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
using DG.Tweening;
using UnityEngine.Playables;

public class MainConsertManager : MonoBehaviour
{
    public PostProcessVolume profile;
    private Bloom bloom;
    private float bloomValue;
    private float valueCal;
    private bool flash = false;
    static float t = 0.0f;


    public GameObject Music;


   



    public AudioSource Blast;
    public GameObject FireWorks;

  

    //Public gameobject for refence
   


    [SerializeField] private GameObject islandModel;


    [SerializeField] private GameObject MainCamera;
    [SerializeField] private GameObject VibeVadersCamera;
    [SerializeField] private GameObject VibevadersPerspectiveCamera;
    [SerializeField] private GameObject CaanuPerspectiveCamera;
    [SerializeField]private GameObject Temple_BhasmaCamera;


    [SerializeField] private GameObject novaBhasma;




    [SerializeField] private GameObject Chariot;
    [SerializeField] private List<GameObject> Conffetti = new List<GameObject>();
    [SerializeField] private GameObject BoomPArticle;

    [SerializeField]private GameObject bhasmaMainChar;
    [SerializeField] private GameObject bigBhasmaChar;
    


    public GameObject VVLOGO;

    private void Awake()
    {

        islandModel.SetActive(false);
        Chariot.SetActive(false);
        VVLOGO.SetActive(false);
        BoomPArticle.SetActive(false);
        FireWorks.SetActive(false);
        for (int i = 0; i < Conffetti.Count; i++)
        {
            Conffetti[i].SetActive(false);
        }
        Music.SetActive(false);
        VibeVadersCamera.SetActive(false);
        VibevadersPerspectiveCamera.SetActive(false);
        CaanuPerspectiveCamera.SetActive(false);
        novaBhasma.SetActive(false);
        bigBhasmaChar.SetActive(false);
        Temple_BhasmaCamera.SetActive(false);

    }
    private void Start()
    {
        profile.profile.TryGetSettings(out bloom);
        bloomValue = bloom.intensity.value;
        flash = true;
        StartCoroutine(MusicDelayPLay());
    }
    private IEnumerator MusicDelayPLay()
    {
        StartCoroutine(CameraActionTowardsVibeVaders());
        yield return new WaitForSeconds(1.26f);
        Music.SetActive(true);
    }
   private IEnumerator CameraActionTowardsVibeVaders()
    {
        yield return new WaitForSeconds(6f);
        MainCamera.SetActive(false);
        VibeVadersCamera.SetActive(true);
        yield return new WaitForSeconds(22f);
        VibeVadersCamera.SetActive(false);
        VibevadersPerspectiveCamera.SetActive(true);
        yield return new WaitForSeconds(8f);
        VibevadersPerspectiveCamera.SetActive(false);
        CaanuPerspectiveCamera.SetActive(true);
        yield return new WaitForSeconds(8f);
        bhasmaMainChar.transform.DOScale(0.01f, 0.8f);
        novaBhasma.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        bigBhasmaChar.SetActive(true);
        bigBhasmaChar.transform.DOScale(10f, 0.8f);
        yield return new WaitForSeconds(4f);
        islandModel.SetActive(true);
        CaanuPerspectiveCamera.SetActive(false);
        Temple_BhasmaCamera.SetActive(true);

    }
    

    private void Update()
    {
        if (flash == true)
        {          
            valueCal = Mathf.Lerp(90f, 20f, t);
            t += 0.2f * Time.deltaTime;
            bloom.intensity.value = valueCal;
        }
    }
}
