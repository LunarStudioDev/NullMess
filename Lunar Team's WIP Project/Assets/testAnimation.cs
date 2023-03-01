using System.Security.AccessControl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testAnimation : MonoBehaviour
{
    public GameObject armsGun;
    public Animator gunAnim;
    public ParticleSystem ImpactParticleSystem;
    public ParticleSystem ShootingSystem;
    public Transform BulletSpawnPoint;
    public TrailRenderer BulletTrail;
    public float fireRate = 0.1f;
    public float damage = 25f;
    private float LastShootTime;
    public LayerMask Mask;
    public GameObject player;
    public Camera wepCamera;
    public AudioClip glockFireSound;
    public AudioClip glockReloadSound;
    public float maxAmmo = 15;
public float currentAmmo;
public float reloadTime;
public bool isReloading;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R)){
            gunAnim.SetTrigger("reload");
            StartCoroutine(waiter());
            
        }
        if (Input.GetKeyDown(KeyCode.Mouse0)){
         Shoot();
        }
    }

IEnumerator waiter(){
     isReloading = true;
     AudioSource sourceaudio = GetComponent<AudioSource>();
     sourceaudio.PlayOneShot(glockReloadSound);
     yield return new WaitForSeconds(reloadTime);
     currentAmmo = maxAmmo;
     isReloading = false;
     }

    public void Shoot(){
        if(LastShootTime + fireRate < Time.time && currentAmmo > 0){
            currentAmmo = currentAmmo - 1;
            AudioSource sourceaudio = GetComponent<AudioSource>();
          sourceaudio.PlayOneShot(glockFireSound);

          gunAnim.SetTrigger("fire");
          ShootingSystem.Play();
          Vector3 direction = GetDirection();
          Ray ray = wepCamera.ScreenPointToRay(Input.mousePosition);
          //BulletSpawnPoint.position, direction, out RaycastHit hit, float.MaxValue, Mask
          RaycastHit hit;
          if (Physics.Raycast(ray, out hit)){
            Transform objectHit = hit.transform;
            Debug.Log(objectHit);

            Debug.Log("postRaycast");
            TrailRenderer trail = Instantiate(BulletTrail, BulletSpawnPoint.position, Quaternion.identity);
            StartCoroutine(SpawnTrail(trail, hit));
            enemyHP hpScript = objectHit.parent.GetComponent<enemyHP>();
                hpScript.TakeDamage(damage);
          }
          LastShootTime = Time.time;
    }

      }
        private Vector3 GetDirection(){
            Vector3 direction = wepCamera.transform.forward;
            return direction;
        }

    private IEnumerator SpawnTrail(TrailRenderer Trail, RaycastHit Hit){
        float time = 0;
        Vector3 startPosition = Trail.transform.position;

        while (time < 1){
            Trail.transform.position = Vector3.Lerp(startPosition, Hit.point, time);
            time += Time.deltaTime / Trail.time;
            yield return null;
        }
    Trail.transform.position = Hit.point;
    ParticleSystem spawned = Instantiate(ImpactParticleSystem, Hit.point, Quaternion.LookRotation(Hit.normal));
    spawned.transform.SetParent(Hit.transform);
    spawned.Play();

    Destroy(Trail.gameObject, Trail.time);
    }
}
