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




    //Public gameobject for refence
    [SerializeField] private GameObject VirtualCamera, IshitaCamera,CaanuCamera,BhasmasuraCamera;


    [SerializeField] private GameObject islandModel;


    //Position for movement of characters.

    [SerializeField] private Vector3 playerFinalPosition,jumpValue,BhasamasuraScalePosition;


    //refence of player.
    public GameObject Player;
    public GameObject Bhasamasura;

    private void Awake()
    {
        Player.SetActive(false);
       

        VirtualCamera.SetActive(true);
        IshitaCamera.SetActive(false);
        CaanuCamera.SetActive(false);
        BhasmasuraCamera.SetActive(false);
        islandModel.SetActive(false);


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



    private IEnumerator BhasamasuraDisapearAction()
    {
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
        yield return new WaitForSeconds(4f);
        islandModel.SetActive(true);
        BhasmasuraCamera.SetActive(true);
        CaanuCamera.SetActive(false);
        yield return new WaitForSeconds(1f);
        BhasmasuraCameraTransition.Play();
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
