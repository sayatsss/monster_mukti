using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Rendering.PostProcessing;


public class SceneTransition : MonoBehaviour
{
    public PostProcessVolume profile;
    private Bloom bloom;
    private float bloomValue;
    private float valueCal;

    private bool flash=false;
    static float t = 0.0f;
    private void Start()
    {
        profile.profile.TryGetSettings(out bloom);
        bloomValue = bloom.intensity.value;
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            StartCoroutine(ChangeScneTranstion());
            
        }
    }
    private void Update()
    {
        if(flash==true)
        {
            valueCal= Mathf.Lerp(bloomValue, 80f, t);
            t += 0.5f * Time.deltaTime;
//            Debug.Log(valueCal);
            bloom.intensity.value = valueCal;
        }
    }

    private IEnumerator ChangeScneTranstion()
    {
        flash = true;  
        yield return new WaitForSeconds(2.5f);
        SceneManager.LoadSceneAsync(2);
    }
}
