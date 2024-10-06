using UnityEngine;
using System;
using Player;

namespace Utilities
{
    public class GlobalInfo
    {

    }
    public static class MyColor
    {
        private static Color gree = new(0f, 0.5f, 0.7f, 1f);



        public static Color Gree { get => gree; }
    }
   

    /// <summary>
    /// 玩家数据运行类型
    /// </summary>
    [Serializable]
    public enum PlayerInfoType
    {
        /// <summary>
        /// 正常模式
        /// </summary>
        Normal,
        /// <summary>
        /// 调试模式
        /// </summary>
        Debug,
    }



}
