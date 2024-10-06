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
        /// �ж��Ƿ�̳���
        /// </summary>
        /// <param name="type">��Ҫ�жϵ���</param>
        /// <param name="baseType">��Ҫ�ж��Ƿ�̳еĸ���</param>
        /// <returns></returns>
        public static bool IsSubclassOf(Type type, Type baseType)
        {
            return baseType.IsAssignableFrom(type) && type != baseType;
        }


 
    }
}


