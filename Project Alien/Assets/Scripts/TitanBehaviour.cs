using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;


enum State
{
    
    Moving,
    Following,
    Shooting,
    None
}

public class TitanBehaviour : EnemyAI
{
    public override void AiInterval()
    {
        base.AiInterval();
        switch (currentBehaviourStateIndex)
        {
            case ((int)State.Moving):
                AIMovement();
                OnDetect();
                if (OnDetect())
                {
                    SetBehaviourState((int)State.Following);
                }
                break;
            case ((int)State.Following):
                OnFollow();
                OnDetect();
                if (!OnDetect())
                {
                    SetBehaviourState((int)State.Moving);
                }

                break;
            case ((int)State.Shooting):


                break;
            case ((int)State.None):

                break;
        }
    }



    public override void JustChangedBehaviour()
    {
        base.JustChangedBehaviour();

        switch (currentBehaviourStateIndex)
        {
            
            case ((int)State.Moving):


                break;
            case ((int)State.Shooting):



                break;
            case ((int)State.None):


                break;
        }

    }


    







}
