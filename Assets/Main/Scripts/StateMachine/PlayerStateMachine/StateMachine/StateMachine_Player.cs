using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class StateMachine_Player : StateMachine
    {
        private readonly string prefix = "State_Player_";
        public List<State_Player> stateList = new List<State_Player>();
        public string stateSOPath = "PlayerStateSOs";

        private PlayerController playerController;


        private void Start()
        {
            //在playerController的awake之后执行保证playerController已经初始化完毕
            {
                //获取player控制器
                playerController = GetComponent<PlayerController>();
            }
            {
                //初始化状态列表
                State_Player[] tempStateList = Resources.LoadAll<State_Player>(stateSOPath);

                stateList.Clear();
                for (int i = 0; i < tempStateList.Length; i++)
                {
                    stateList.Add(Instantiate(tempStateList[i]));
                }
            }
            {
                //初始化字典
                StateTable = new Dictionary<System.Type, IState>(stateList.Count);

                foreach (var state in stateList)
                {
                    state.Initialize(playerController);
                    StateTable.Add(state.GetType(), state);
                }
            }
            {
                //切入idle状态中
                Switch_On(StateTable[typeof(State_Player_Idle)]);
            }

        }

        public string ReturnStateName => CurrentState.GetType().Name.Substring(prefix.Length);
    }
 

}