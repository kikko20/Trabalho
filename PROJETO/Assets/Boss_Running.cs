using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Running : StateMachineBehaviour
{
    public float speed = 2.5f;
    public float attackRange = 3f;



    Transform player;
    Rigidbody2D rig;
    BossYas boss;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rig = animator.GetComponent<Rigidbody2D>();
        boss = animator.GetComponent<BossYas>();

    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

        boss.LookAtPlayer();

        Vector2 target = new Vector2(player.position.x, rig.position.x);
        Vector2 newPos = Vector2.MoveTowards(rig.position, target, speed * Time.fixedDeltaTime);
        rig.MovePosition(newPos);

      if (Vector2.Distance(player.position, rig.position) <= attackRange)
        {
            animator.SetTrigger("Attack");
        }
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("Attack");
    }
}