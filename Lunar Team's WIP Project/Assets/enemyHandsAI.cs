using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class enemyHandsAI : MonoBehaviour
{

public Animator handsAnim;
 public GameObject destroyedversion;

   public float health = 100f;

   public void TakeDamage(float amount){
       health -= amount;
       if (health <= 0f){
           Die();
       }
   }
 void Die (){
     GameObject Destroyedd = Instantiate(destroyedversion, transform.position, transform.rotation);
     Destroyedd.SetActive(true);
     Destroy(gameObject);
     Destroy(Destroyedd, 10);
 }
public NavMeshAgent agent;

public Transform player;

public LayerMask whatIsGround, whatIsPlayer;

public Vector3 walkPoint;
bool walkPointSet;
public float walkPointRange;

public float timeBetweenAttacks;
bool alreadyAttacked;
public GameObject projectile;

public float sightRange, attackRange, runAttackRange;
public bool playerInSightRange, playerInAttackRange, playerMaxRunAttackRange;
public float projectileSpeed = 32f;

private void Awake() {
    player = GameObject.Find("PlayerCapsule").transform;
    agent = GetComponent<NavMeshAgent>();
    alreadyAttacked = true;
    Invoke(nameof(ResetAttack), timeBetweenAttacks);
}

    private void Update()
    {
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);
        playerMaxRunAttackRange = Physics.CheckSphere(transform.position, runAttackRange, whatIsPlayer);

        if (!playerInSightRange && !playerInAttackRange) Patrolling();
        if (playerInSightRange && !playerInAttackRange) ChasePlayer();
        if (playerInSightRange && !playerMaxRunAttackRange) ChasePlayer();
        if (playerInAttackRange && playerInSightRange) AttackPlayer();
    }

    private void Patrolling(){
if (!walkPointSet) SearchWalkPoint();

if (walkPointSet)
agent.SetDestination(walkPoint);

Vector3 distanceToWalkPoint = transform.position - walkPoint;

if (distanceToWalkPoint.magnitude < 1f)
walkPointSet = false;
}

private void SearchWalkPoint(){
    handsAnim.SetBool("isWalking", false);
    float randomZ = Random.Range(-walkPointRange, walkPointRange);
    float randomX = Random.Range(-walkPointRange, walkPointRange);

    walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

    if (Physics.Raycast(walkPoint, -transform.up, 2f, whatIsGround));
    walkPointSet = true;
}

private void ChasePlayer(){
handsAnim.SetBool("isWalking", true);
agent.SetDestination(player.position);
}

private void AttackPlayer(){
    if(playerInAttackRange && playerInSightRange && playerMaxRunAttackRange){
        agent.SetDestination(transform.position);
        handsAnim.SetBool("isWalking", true);
    }
transform.LookAt(player);

if (!alreadyAttacked)
{
Rigidbody rb = Instantiate(projectile, transform.position, Quaternion.identity).GetComponent<Rigidbody>();
rb.AddForce(transform.forward * projectileSpeed, ForceMode.Impulse);
rb.AddForce(transform.up * 8f, ForceMode.Impulse);

Destroy(rb.transform.gameObject, 2);

    alreadyAttacked = true;
    Invoke(nameof(ResetAttack), timeBetweenAttacks);
}

}
private void ResetAttack(){
    alreadyAttacked = false;
}


 private void OnDrawGizmosSelected()
 {
     Gizmos.color = Color.red;
     Gizmos.DrawWireSphere(transform.position, attackRange);
Gizmos.color = Color.yellow;
Gizmos.DrawWireSphere(transform.position, sightRange);
 }
}
