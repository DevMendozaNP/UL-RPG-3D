using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : State
{
    //Transicion de Idle a Follow

    public IdleState(EnemyController controller) : base(controller)
    {
        Transition transitionIdleToFollow = new Transition(
            isValid: () => {
                float distance = Vector3.Distance(
                    controller.Player.position,
                    controller.transform.position
                );

                if (distance < controller.DistanceToFollow)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }, 
            getNextState: () => {
                return new FollowState(controller);
            }
        );

        Transitions.Add(transitionIdleToFollow);
    }
    
    public override void OnStart()
    {
        controller.rb.velocity = Vector3.zero;
        controller.animator.SetFloat("Vertical", -1f);
    }

    public override void OnUpdate()
    {

    }
    public override void OnFinish()
    {
        Debug.Log("Estado Idle Finish");
    }
}
