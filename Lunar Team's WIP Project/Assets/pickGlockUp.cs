using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickGlockUp : MonoBehaviour
{

    public GameObject armsOn;
    public AudioSource cameraSource;
    public AudioClip below;
    public GameObject text1;
    public GameObject text2;
    public GameObject text3;
    public GameObject text4;
 void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.name == "PlayerCapsule"){
            armsOn.SetActive(true);
            this.transform.position = new Vector3(0, -1000, 0);
            StartCoroutine(StartFade(cameraSource, 10, 0.6f));
            cameraSource.PlayOneShot(below);
            text1.SetActive(false);
            text2.SetActive(true);
            StartCoroutine(StartText());
        }
    }

    public IEnumerator StartText(){
        yield return new WaitForSeconds(5f);
        text2.SetActive(false);
        text3.SetActive(true);
        yield return new WaitForSeconds(8f);
        text3.SetActive(false);
        text4.SetActive(true);
    }

    public static IEnumerator StartFade(AudioSource audioSource, float duration, float targetVolume)
    {
        float currentTime = 0;
        float start = audioSource.volume;
        while (currentTime < duration)
        {
            currentTime += Time.deltaTime;
            audioSource.volume = Mathf.Lerp(start, targetVolume, currentTime / duration);
            yield return null;
        }
        yield break;
    }
}


