using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BossRun : StateMachineBehaviour
{
    private const float Speed = 3.0f;
    private Vector2 currentTarget;
    private Rigidbody2D rigidbody;
    private Dictionary<Vector2, Vector2> targetsPositions;
    private BossInfinity boss;
    
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        rigidbody = animator.GetComponent<Rigidbody2D>();
        boss = animator.GetComponent<BossInfinity>();
        targetsPositions = boss.GetFirstStagePath;
        currentTarget = boss.GetClosestTarget();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }

    // OnStateMove is called right after Animator.OnAnimatorMove()
    public override void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (Vector2.Distance(rigidbody.position, currentTarget) < 0.1)
            currentTarget = targetsPositions[currentTarget];
        var newPosition = Vector2.MoveTowards(rigidbody.position, currentTarget,
            Speed * Time.fixedDeltaTime);
        rigidbody.MovePosition(newPosition);
    }

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
