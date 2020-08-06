using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;

public class AggressiveMob : MonoBehaviour
{
    
    private float damage = 7.5f;
    private NavMeshAgent navMeshAgent;
    private GameObject[] players;
    public GameObject closePlayer;
    private Transform[] playersPosition;
    public static bool ableToAttack;
    
    public bool alreadyAttacked;
    public bool isAttacking;
    private Animator anim;
    
    [SerializeField] private float detectionDistance = 15f;
    [SerializeField] private float attackDistance = 10f;
    
    private void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        players = GameObject.FindGameObjectsWithTag("Player");
        
        if (players == null)
        {
            Debug.LogError("No Players");
        }
    }

    private void Update()
    {
        closePlayer = Helpers.GetClosestPlayer(this.transform, players);
        float distance =
            Vector3.Distance(closePlayer.transform.position, transform.position);
        if (distance < detectionDistance)
        {
            ableToAttack = true;
            if (distance > attackDistance)
            {
                MoveTowardsPlayer(closePlayer.transform);
                navMeshAgent.isStopped = false;
                anim.ResetTrigger("Attacks");
                anim.SetBool("CanAttack", false);
                isAttacking = false;
                // print("MOVE TOWARDS THE CLOSEST PLAYER");
            }
            else
            {
                navMeshAgent.isStopped = true;
                anim.SetBool("CanAttack", true);
                anim.SetTrigger("Attacks");
                transform.LookAt(closePlayer.transform);
                isAttacking = true;
                // print("ATTACK PLAYER");
            }
        }
        else
        {
            ableToAttack = false;
        }
    }
    private void MoveTowardsPlayer(Transform closestPlayer)
    {
        Vector3 targetVector = closestPlayer.position;
        transform.LookAt(closestPlayer);
        navMeshAgent.SetDestination(targetVector);
    }

    public float getDamage()
    {
        return damage;
    }
}
