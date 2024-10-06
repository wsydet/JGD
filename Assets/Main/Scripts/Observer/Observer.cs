using System;
using UniRx;
using Utilities;
public static class Observer 
{
    public static Subject<string> TestEvnet { get; } = new();

    /// <summary>
    /// 玩家初始化成功
    /// </summary>
    //public static Subject<string> PlayerInited { get; } = new();


    /// <summary>
    /// 玩家进入状态
    /// </summary>
    public static Subject<Type> PlayerStateEnter { get; } = new();
    /// <summary>
    /// 玩家离开状态
    /// </summary>
    public static Subject<Type> PlayerStateExit { get; } = new();




    public static void Emit(string eventName, string[] parameters)
    {
        ((Subject<string>)typeof(Observer).GetProperty(eventName).GetValue(null)).OnNext(parameters[0]);
    }

    
}
/*
按钮点击事件
using UniRx;
using UnityEngine;
using UnityEngine.UI;

public class ButtonClickExample : MonoBehaviour
{
    private void Start()
    {
        var button = GetComponent<Button>();

        // 使用 UniRx 订阅按钮点击事件
        button.OnClickAsObservable()
            .Subscribe(_ => Debug.Log("Button clicked!"))
            .AddTo(this); // 确保在对象销毁时取消订阅
    }
}
 响应式属性
 public class ReactivePropertyExample : MonoBehaviour
{
    // 声明一个响应式属性
    private ReactiveProperty<int> score = new ReactiveProperty<int>(0);

    [SerializeField] private Text scoreText;

    private void Start()
    {
        // 订阅响应式属性的变化，并更新 UI 文本
        score.Subscribe(value => scoreText.text = $"Score: {value}")
             .AddTo(this); // 确保在对象销毁时取消订阅

        // 模拟分数增加
        InvokeRepeating(nameof(IncreaseScore), 1f, 1f);
    }

    private void IncreaseScore()
    {
        score.Value += 10; // 增加分数
    }
}
定时任务
using UniRx;
using UnityEngine;

public class TimerExample : MonoBehaviour
{
    private void Start()
    {
        // 创建一个每隔一秒执行一次的定时任务
        Observable.Timer(System.TimeSpan.FromSeconds(1))
            .Subscribe(_ => Debug.Log("One second passed."))
            .AddTo(this); // 确保在对象销毁时取消订阅
    }
}
 */