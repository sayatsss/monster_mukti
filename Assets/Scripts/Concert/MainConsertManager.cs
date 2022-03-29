using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
using DG.Tweening;

public class MainConsertManager : MonoBehaviour
{
    public PostProcessVolume profile;
    private Bloom bloom;
    private float bloomValue;
    private float valueCal;
    private bool flash = false;
    static float t = 0.0f;


    [SerializeField] private Vector3 playerFinalPosition,jumpValue;


    public GameObject Player;

    private void Awake()
    {
        Player.SetActive(false);
        

    }
    private void Start()
    {
        profile.profile.TryGetSettings(out bloom);
        bloomValue = bloom.intensity.value;
        flash = true;
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
