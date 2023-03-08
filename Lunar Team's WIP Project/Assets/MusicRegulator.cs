using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicRegulator : MonoBehaviour

{
    public AudioSource audioSource;

    private void Start(){
        StartFade(audioSource, 2f, 1);
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
