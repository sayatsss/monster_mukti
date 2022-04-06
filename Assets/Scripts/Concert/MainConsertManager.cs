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



    //TimeLine Action varibales

    public PlayableDirector cameraTransition;
    public PlayableDirector BhasamasuraCameraTransition;
    public PlayableDirector ChaanuCameraTransition;
    public PlayableDirector BhasmasuraCameraTransition;
    public PlayableDirector StageCameraTransition;
    public PlayableDirector HorseCameraTransiton;




    public AudioSource Blast;
    public GameObject FireWorks;

  

    //Public gameobject for refence
    [SerializeField] private GameObject VirtualCamera, IshitaCamera,CaanuCamera,BhasmasuraCamera,stageCamera,horseCamera,chariotCamera,BhasmaCamera,LastCamera;


    [SerializeField] private GameObject islandModel;


    //Position for movement of characters.

    [SerializeField] private Vector3 playerFinalPosition,jumpValue,BhasamasuraScalePosition,chariotEndPoint;


    //refence of player.
    public GameObject Player,chariotPlayer;
    public GameObject Bhasamasura;

    public GameObject ParticleBashma,particleBashmaBig;


    [SerializeField] private GameObject Chariot;
    [SerializeField] private List<GameObject> Horses = new List<GameObject>();
    [SerializeField] private List<GameObject> Conffetti = new List<GameObject>();
    [SerializeField] private GameObject BoomPArticle;


    public GameObject VVLOGO;

    private void Awake()
    {
        Player.SetActive(false);
       

        VirtualCamera.SetActive(true);
        IshitaCamera.SetActive(false);
        CaanuCamera.SetActive(false);
        BhasmasuraCamera.SetActive(false);
        islandModel.SetActive(false);
        stageCamera.SetActive(false);
        Chariot.SetActive(false);
        horseCamera.SetActive(false);
        chariotPlayer.SetActive(false);
        chariotCamera.SetActive(false);
        BhasmaCamera.SetActive(false);
        LastCamera.SetActive(false);
        VVLOGO.SetActive(false);
        ParticleBashma.SetActive(false);
        particleBashmaBig.SetActive(false);
        BoomPArticle.SetActive(false);
        FireWorks.SetActive(false);
        for (int i = 0; i < Conffetti.Count; i++)
        {
            Conffetti[i].SetActive(false);
        }


    }
    private void Start()
    {
        profile.profile.TryGetSettings(out bloom);
        bloomValue = bloom.intensity.value;
        flash = true;
        //cameraTransition = cameraTransition.GetComponent<PlayableDirector>();
        StartCoroutine(PlayerAction());
    }
    private IEnumerator PlayerAction()
    {
        yield return new WaitForSeconds(3f);
        Player.SetActive(true);
        Player.GetComponent<Animator>().SetBool("IsJump",true);
        Player.transform.DOMove(jumpValue, 1.5f);
        yield return new WaitForSeconds(1f);
        //Player.GetComponent<Animator>().SetBool("IsJump", false);
        Player.GetComponent<Animator>().SetBool("IsRun", true);
        Player.transform.DOMove(playerFinalPosition, 1.8f);
        yield return new WaitForSeconds(1.5f);
        Player.GetComponent<Animator>().SetBool("IsIdle", true);
        Player.GetComponent<Animator>().SetBool("IsRun", false);
        yield return new WaitForSeconds(1.5f);
        cameraTransition.Play();
        yield return new WaitForSeconds(20f);
        VirtualCamera.SetActive(false);
        IshitaCamera.SetActive(true);
        yield return new WaitForSeconds(1f);
        BhasamasuraCameraTransition.Play();
        yield return new WaitForSeconds(7f);
        CaanuCamera.SetActive(true);
        IshitaCamera.SetActive(false);
        ChaanuCameraTransition.Play();
        yield return new WaitForSeconds(1.5f);
        StartCoroutine(BhasamasuraDisapearAction());
        

    }


    private IEnumerator ChariotMovement()
    {
        yield return new WaitForSeconds(5f);
        Chariot.SetActive(true);
        for(int i=0;i<Horses.Count;i++)
        {
            Horses[i].GetComponent<Animator>().SetBool("IsRun", true);
        }
        Chariot.transform.DOMove(chariotEndPoint, 2f); ;
        yield return new WaitForSeconds(0.1f);
        for (int i = 0; i < Horses.Count; i++)
        {
            Horses[i].GetComponent<Animator>().SetBool("IsRun", false);
            Horses[i].GetComponent<Animator>().SetBool("IsIdle", true);
        }
        yield return new WaitForSeconds(2f);
        stageCamera.SetActive(false);
        horseCamera.SetActive(true);
        yield return new WaitForSeconds(1f);
        Player.transform.DOScale(0.001f, 0.2f);
        HorseCameraTransiton.Play();
        yield return new WaitForSeconds(3f);
        chariotPlayer.SetActive(true);
        horseCamera.SetActive(false);
        chariotCamera.SetActive(true);

        yield return new WaitForSeconds(0.5f);

        for (int i = 0; i < Horses.Count; i++)
        {
            Horses[i].GetComponent<Animator>().SetBool("IsIdle", false);
            Horses[i].GetComponent<Animator>().SetBool("IsJump", true);
        }
        yield return new WaitForSeconds(0.5f);
        Chariot.GetComponent<PathFollowe>().moveChariot = true;
        yield return new WaitForSeconds(3f);
        chariotCamera.SetActive(false);
        BhasmaCamera.SetActive(true);

        StartCoroutine(LastCutScne());





    }

    private IEnumerator LastCutScne()
    {
        yield return new WaitForSeconds(10f);
        islandModel.SetActive(false);
        LastCamera.SetActive(true);
        BhasmaCamera.SetActive(false);
        Chariot.SetActive(false);
        yield return new WaitForSeconds(12f);
        VVLOGO.SetActive(true);
        yield return new WaitForSeconds(2f);
        for (int i=0;i<Conffetti.Count;i++)
        {
            Conffetti[i].SetActive(true);
        }

        FireWorks.SetActive(true);
        BoomPArticle.SetActive(true);
        Blast.Play();
    }



    private IEnumerator BhasamasuraDisapearAction()
    {
        ParticleBashma.SetActive(true);
        Bhasamasura.transform.DOScale(0.01f, 0.2f);
        yield return new WaitForSeconds(0.6f);
        Bhasamasura.SetActive(false);
        yield return new WaitForSeconds(1.5f);
        Bhasamasura.transform.position = BhasamasuraScalePosition;
        Bhasamasura.SetActive(true);
        yield return new WaitForSeconds(1f);
      //  CameraShake.instance.shakeDuration = 2;
        yield return new WaitForSeconds(0.6f);
        Bhasamasura.GetComponent<Animator>().SetBool("BigDance", true);
        Bhasamasura.transform.DOScale(20f, 0.5f);
        particleBashmaBig.SetActive(true);
        yield return new WaitForSeconds(4f);
        islandModel.SetActive(true);
        BhasmasuraCamera.SetActive(true);
        CaanuCamera.SetActive(false);
        yield return new WaitForSeconds(1f);
        BhasmasuraCameraTransition.Play();
        yield return new WaitForSeconds(8f);
        BhasmasuraCamera.SetActive(false);
        stageCamera.SetActive(true);
        StageCameraTransition.Play();
        StartCoroutine(ChariotMovement());
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
