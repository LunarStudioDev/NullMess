using System.Security.AccessControl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testAnimation : MonoBehaviour
{
    public float powerMeter = 0f;
    public GameObject armsGun;
    public Animator gunAnim;
    public ParticleSystem ImpactParticleSystem;
    public ParticleSystem ShootingSystem;
    public Transform BulletSpawnPoint;
    public TrailRenderer BulletTrail;
    public float fireRate = 0.15f;
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

    void Start(){
         gunAnim.updateMode = AnimatorUpdateMode.Normal;
         gunAnim.Play("IdleAnimation", -1, 0f);
         StartCoroutine(powerRecharge());
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R)){
            if (!isReloading){
            gunAnim.SetTrigger("reload");
            StartCoroutine(waiter());
            }
            
        }
        if (Input.GetKeyDown(KeyCode.Mouse0)){
         Shoot();
        }
        if(LastShootTime + fireRate < Time.time && currentAmmo > 0 && !isReloading){
            if (powerMeter > 33f && Input.GetKeyDown(KeyCode.Mouse1)){
                fireRate = -1f;
            damage = 50f;
            currentAmmo++;
            Shoot();
            if (powerMeter > 66f){
                currentAmmo++;
                Shoot();
                if(powerMeter == 100f){
                    currentAmmo++;
                    Shoot();
                }
            }
            powerMeter = 0f;
            damage = 25f;
            fireRate = 0.15f;
        }
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

IEnumerator powerRecharge(){
    while(true){
        yield return new WaitForSeconds(0.5f);
        powerMeter = powerMeter + 1f;
    }
}

    public void Shoot(){
        if(LastShootTime + fireRate < Time.time && currentAmmo > 0 && !isReloading){
            print("shotOnce");
            currentAmmo = currentAmmo - 1;
            AudioSource sourceaudio = GetComponent<AudioSource>();
          sourceaudio.PlayOneShot(glockFireSound);

          gunAnim.SetTrigger("fire");
          ShootingSystem.Play();
          Vector3 direction = GetDirection();
          Ray ray = wepCamera.ScreenPointToRay(Input.mousePosition);
          //BulletSpawnPoint.position, direction, out RaycastHit hit, float.MaxValue, Mask
          RaycastHit hit;
          LastShootTime = Time.time;
          if (Physics.Raycast(ray, out hit)){
            Transform objectHit = hit.transform;
            Debug.Log(objectHit);

            Debug.Log("postRaycast");
            TrailRenderer trail = Instantiate(BulletTrail, BulletSpawnPoint.position, Quaternion.identity);
            StartCoroutine(SpawnTrail(trail, hit));
            if(objectHit.parent.GetComponent<enemyHP>()){
                enemyHP hpScript = objectHit.parent.GetComponent<enemyHP>();
                hpScript.TakeDamage(damage);
                powerMeter = powerMeter + 5f;
            }
             if(objectHit.parent.GetComponent<enemyHandsAI>()){
                enemyHandsAI hpScript2 = objectHit.parent.GetComponent<enemyHandsAI>();
                hpScript2.TakeDamage(damage);
                powerMeter = powerMeter + 5f;
            }
          }
          
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
