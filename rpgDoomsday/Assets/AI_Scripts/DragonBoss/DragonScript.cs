using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonScript : MonoBehaviour
{
    [SerializeField] private GameObject[] players;
    public GameObject closePlayer;
    private Transform[] playersPosition;
    
    private Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
        players = GameObject.FindGameObjectsWithTag("Player");
    }

    private void Update()
    {
        closePlayer = Helpers.GetClosestPlayer(this.transform, players);
        
        transform.LookAt(closePlayer.transform);
        
        float distance =
            Vector3.Distance(closePlayer.transform.position, transform.position);

        if (distance < 7.5f)
        {
            //print("MeleeAttack");
            /*
             * pentru melee
             */
            //anim.SetBool("isAttacking", false); //
            //anim.SetBool("isIdle", true); //
        }
        else
        {
            anim.SetBool("isAttacking", true);
            anim.SetBool("isIdle", false);
        }
    }
}
