using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soundShotgun : MonoBehaviour
{

    public AudioClip shotgunFireSound;
    public AudioClip shotgunReloadSound;
    public AudioClip shotgunShellSound;
    public AudioClip shotgunPumpSound;
    public AudioSource audioSource;
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void insertShell(){
        audioSource.PlayOneShot(shotgunShellSound);
    }

    public void shotgunRack(){
        audioSource.PlayOneShot(shotgunPumpSound);
    }

    public void shotgunFire(){
        audioSource.PlayOneShot(shotgunFireSound);
    }
}
