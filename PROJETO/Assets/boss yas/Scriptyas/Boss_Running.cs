using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Running : StateMachineBehaviour
{
    public float speed = 3f;
    public float attackRange = 3f;
    public static bool isAtk;
    
    [SerializeField] private AudioSource walkSound;
    [SerializeField] private AudioSource ataqSom;

    Transform player;
    Rigidbody2D rig;
    BossYas boss;
    
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rig = animator.GetComponent<Rigidbody2D>();
        boss = animator.GetComponent<BossYas>();
        walkSound = boss.walkSound;
        ataqSom = boss.ataqSom;


    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

        boss.LookAtPlayer();

        Vector2 target = new Vector2(player.position.x, rig.position.y);
        Vector2 newPos = Vector2.MoveTowards(rig.position, target, speed * Time.fixedDeltaTime);
        rig.MovePosition(newPos);
        if (!walkSound.isPlaying)
        {
            walkSound.Play(); 
        }

        

      if (Vector2.Distance(player.position, rig.position) <= attackRange)
        {
            animator.SetTrigger("Attack");
            isAtk = true;

        }
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("Attack");
        walkSound.Stop();
        ataqSom.Play();
    }
}
