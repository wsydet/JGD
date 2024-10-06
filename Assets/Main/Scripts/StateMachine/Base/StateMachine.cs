using System;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    /// <summary>
    /// 当前状态
    /// </summary>
    public IState CurrentState { get; private set; }
    /// <summary>
    /// 状态字典
    /// </summary>
    protected Dictionary<System.Type, IState> StateTable;

    public IState LastState { get; private set; }
    public IState NextState { get; private set; }

    /// <summary>
    /// 判断当前状态
    /// </summary>
    /// <param name="stateType">传入判断的状态</param>
    /// <returns>当前状态与传入状态一致时返回true</returns>
    public bool NowStateIs(Type stateType)
    {
        if (CurrentState.GetType() == stateType)
            return true;
        else
            return false;
    }
    public bool NowStateIsNot(Type stateType)
    {
        if (CurrentState.GetType() != stateType)
            return true;
        else
            return false;
    }

    /// <summary>
    /// 判断上一个状态
    /// </summary>
    /// <param name="stateType">传入判断的状态</param>
    /// <returns>上一个状态与传入状态一致时返回true</returns>
    public bool LastStateIs(Type stateType)
    {
        if (LastState.GetType() == stateType)
            return true;
        else
            return false;
    }
    public bool LastStateIsNot(Type stateType)
    {
        if (LastState.GetType() != stateType)
            return true;
        else
            return false;
    }

    /// <summary>
    /// 判断下一个状态
    /// </summary>
    /// <param name="stateType"></param>
    /// <returns></returns>
    public bool NextStateIs(Type stateType)
    {
        if (NextState == null) return false;

        if (NextState.GetType() == stateType)
            return true;
        else
            return false;
    }
    public bool NextStateIsNot(Type stateType)
    {
        if (NextState == null) return false;

        if (NextState.GetType() != stateType)
            return true;
        else
            return false;
    }

    public bool NowStateIsLayer(Type stateType)
    {
        if (CurrentState == null) return false;

        if (Utilities.Utility.IsSubclassOf(CurrentState.GetType(), stateType))
            return true;
        else
            return false;
    }
    public bool LastStateIsLayer(Type stateType)
    {
        if (LastState == null) return false;

        if (Utilities.Utility.IsSubclassOf(LastState.GetType(), stateType))
            return true;
        else
            return false;
    }
    private void Update()
    {
        CurrentState.LogicUpdate();
    }

    private void FixedUpdate()
    {
        CurrentState.PhysicUptate();
       
    }


    protected void Switch_On(IState newState)
    {
        LastState = CurrentState;
        NextState = null;

        CurrentState = newState;
        CurrentState.Enter();

    }

    public void Switch_State(IState newState)
    {
        //if (CurrentState == newState)
        //{
        //    return;
        //}

        NextState = newState;

        CurrentState.Exit();

        Switch_On(newState);
    }


    public bool Switch_State(System.Type newStateType)
    {
        if (StateTable.TryGetValue(newStateType, out var value) && value != null)
        {
            Switch_State(value);
            return true;
        }
        else
        {
            Debug.LogError($"状态{newStateType.Name}的SO文件不存在");
            return false;
        }

    }

}
