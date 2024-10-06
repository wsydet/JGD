using UnityEngine;


namespace Player
{
    public class State_Player : ScriptableObject, IState
    {
        protected readonly string prefix = "State_Player_";
        [HideInInspector] public string StateName => GetType().Name[prefix.Length..];


        protected PlayerController playerController;
        protected PlayerInput playerInput;
        protected Animator animator;
        protected StateMachine_Player stateMachine;
        protected Collider2D box;
 

        /// <summary>
        /// 状态开始时间
        /// </summary>
        protected float stateStartTime;
        /// <summary>
        /// 时间长度颗粒（0.02s为单位）
        /// </summary>
        protected int stateDurationTimeGrain;
        /// <summary>
        /// 动画是否播放完毕
        /// </summary>
        protected bool StateIsFinished => StateDurationTime >= playerController.animator.GetCurrentAnimatorStateInfo(0).length;
        /// <summary>
        /// 动画持续时间
        /// </summary>
        protected float StateDurationTime => Time.time - stateStartTime;
        /// <summary>
        /// 动画持续时间 百分比
        /// </summary>
        protected float StateDurationTimePercentage
        {
            get
            {
                if (animator.GetCurrentAnimatorStateInfo(0).length <= 0f) return 0f;
                return Mathf.Clamp01(StateDurationTime / animator.GetCurrentAnimatorStateInfo(0).length);
            }
        }
        /// <summary>
        /// 动画播放过半
        /// </summary>
        protected bool StateIsHalfed => StateDurationTimePercentage >= 0.5f;

        protected float GetAnimationClipLength()
        {
            // 获取Animator的RuntimeAnimatorController
            RuntimeAnimatorController animatorController = animator.runtimeAnimatorController;

            // 遍历所有动画片段
            foreach (AnimationClip clip in animatorController.animationClips)
            {
                if (clip.name == StateName)
                {
                    // 返回动画片段的总时长
                    return clip.length;
                }
            }

            // 如果没有找到指定名称的动画片段，返回0
            Debug.LogWarning($"未找到名为 '{StateName}' 的动画片段");
            return 0f;
        }

        public void Initialize(PlayerController _playerController)
        {
            playerController = _playerController;
            stateMachine = _playerController.stateMachine as StateMachine_Player;
            animator = _playerController.animator;
            playerInput = _playerController.playerInput;
            box = _playerController.box;
        }



        private Utilities.PlayerInfoType infoType;


        private bool inited = false;
        /// <summary>
        /// 状态参数初始化
        /// 只会初始化一次
        /// 但是需要调用base
        /// </summary>
        public virtual void Init()
        {
            inited = true;
            infoType = playerController.infoType;
        }
  
        /// <summary>
        /// 先于状态进入，可以取消当前的进入状态
        /// !!!不能调用base，否则会直接返回false!!!
        /// 转换状态成功后需要返回true，未成功返回false
        /// </summary>
        /// <returns></returns>
        public virtual bool EnterSwitch()
        {
            return false;
        }

        public virtual bool Enter()
        {
            //Debug.Log($"进入状态{StateName}");

            if(EnterSwitch())
            {
                return true;
            }

            if (!inited)
            {
                Init();
            }

            {
                //SO调试模式
                if (infoType == Utilities.PlayerInfoType.Debug)
                {
                    Init();
                }
            }
       
            {
                stateStartTime = Time.time;
                stateDurationTimeGrain = 0;

                animator.Play(Animator.StringToHash(StateName));

                 
            }
 

            StateEnterBroadcast();
            return false;
        }

        /// <summary>
        /// 有特殊物理转状态时返回true强制切断后面代码
        /// 没有转状态时返回false
        /// </summary>
        /// <returns></returns>
        public virtual bool PhysicUptate()
        {
            TimeGrainAdd();
 
            return false;
        }


        /// <summary>
        /// 转状态时返回true切断后面的执行代码
        /// 否则返回false
        /// </summary>
        /// <returns></returns>
        public virtual bool LogicUpdate()
        {
            return false; 
        }
        public virtual void Exit()
        {
            StateExitBroadcast();
        }

 

        /// <summary>
        /// 状态进入播报
        /// </summary>
        private void StateEnterBroadcast()
        {
            Observer.PlayerStateEnter.OnNext(this.GetType());
        }

        /// <summary>
        /// 状态离开播报
        /// </summary>
        private void StateExitBroadcast()
        {
            Observer.PlayerStateExit.OnNext(this.GetType());
        }

        /// <summary>
        /// 增加时间计数器
        /// </summary>
        private void TimeGrainAdd()
        {
            stateDurationTimeGrain++;
        }
         
    }

}