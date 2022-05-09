   using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minotaur : MonoBehaviour
{
    public float cd = 5;
    public float next = 0;
    public Transform attackPoint;
    public float attackRange = 0.5f;
    public float attackDamage = 1;
    public LayerMask enemyLayers;
    Animator animator;
	string currentAnimState;
    public AIPlayerDetector Detected;

    // Start is called before the first frame update


 
    void Start()
    {
        animator = gameObject.GetComponent<Animator>();


    }
    void Update()
    {
        if(Detected.PlayerDetected == true){
        if(Time.time > next){

            Attack();
                FMODUnity.RuntimeManager.PlayOneShot("event:/SFX/Enemies/Minotaur/Minotaur_Attack", GetComponent<Transform>().position);

                next = Time.time + cd;
            
        }
        }
    }

        void Attack()
    {
        animator.SetTrigger("Attack");

        Collider2D[] hitPlayers = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        foreach(Collider2D player in hitPlayers)
        {
            player.GetComponent<PlayerController>().TakeHit(attackDamage);
            

        }
    }

    void OnDrawGizmosSelected() {

        if(attackPoint == null){
            return;
        }
        
            Gizmos.DrawWireSphere(attackPoint.position, attackRange);
        
    }

    // Update is called once per frame

  
    


}
