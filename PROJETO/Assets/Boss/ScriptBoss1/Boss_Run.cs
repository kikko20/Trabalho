using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;

public class Boss_Run : StateMachineBehaviour
{
    private Transform player;
    private Rigidbody2D rig;
    public float speed = 2.5f;
    public float attackRange = 3F;
    private Boss boss;

    [SerializeField] private AudioSource walkSound;
    
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rig = animator.GetComponent<Rigidbody2D>();
        boss = animator.GetComponent<Boss>();
        walkSound = boss.walkSound;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        boss.LookAtPlayer();
        
        Vector2 target = new Vector2(player.position.x, rig.position.y);
        Vector2 newpos = Vector2.MoveTowards(rig.position, target, speed * Time.fixedDeltaTime);
        rig.MovePosition(newpos);
        if (!walkSound.isPlaying)
        {
            walkSound.Play(); 
        }
        

        if (Vector2.Distance(player.position, rig.position) <= attackRange)
        {
            animator.SetTrigger("Attack");
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("Attack");
        walkSound.Stop();
        
    }
}
