public interface IState
{
    public bool Enter();
    public void Exit();

    /// <summary>
    /// 切换状态的逻辑
    /// </summary>
    public bool LogicUpdate();
    /// <summary>
    /// 状态中的操作
    /// </summary>
    public bool PhysicUptate();
}