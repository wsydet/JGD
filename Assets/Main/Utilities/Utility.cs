using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace Utilities
{
    public static class Utility 
    {
        public static int ReturnGainByTime(float time)
        {
            return (int)(time / 0.02f);
        }

        /// <summary>
        /// 判断是否继承于
        /// </summary>
        /// <param name="type">需要判断的类</param>
        /// <param name="baseType">需要判断是否继承的父类</param>
        /// <returns></returns>
        public static bool IsSubclassOf(Type type, Type baseType)
        {
            return baseType.IsAssignableFrom(type) && type != baseType;
        }


 
    }
}


