using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerHit : MonoBehaviour
{


public healthBar hpBar;
 void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.name == "PlayerCapsule"){
            Debug.Log('1');
            hpBar.SetHealth(hpBar.startHealth - 20f);
        }
        if(collision.collider.gameObject.layer == 6){
            Destroy(this.gameObject);
        }
        
    }
}
