using UnityEngine;
namespace Player
{
    [CreateAssetMenu(menuName = "SOData/StateMachine/playerStates/Idle", fileName = "State_Player_Idle")]
    public class State_Player_Idle : State_Player
    {

 
        public override bool Enter()
        {
            if (base.Enter())
            {
                return true;
            }
            

            return false;
        }
        public override bool PhysicUptate()
        {
 
            if(base.PhysicUptate())
            {
                return true;
            }
           
            return false;
        }

        public override bool LogicUpdate()
        {
           
            if (base.LogicUpdate())
            {
                return true;
            }
 


            return false;
        }

        public override void Exit()
        {
            base.Exit();

        }
    }

}
