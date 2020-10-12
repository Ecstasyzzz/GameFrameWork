using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace GameFramework
{
    /// <summary>
    /// Transform变量
    /// </summary>
    public class VarColor : Variable<Color>
    {
        /// <summary>
        /// 分配一个对象
        /// </summary>
        /// <returns></returns>
        public static VarColor Alloc()
        {
            VarColor var = GameEntry.PoolComponent.DequeueVarObject<VarColor>();
            var.Value = Color.white;
            var.Retain();
            return var;
        }

        /// <summary>
        /// 分配一个对象
        /// </summary>
        /// <param name="value">初始值</param>
        /// <returns></returns>
        public static VarColor Alloc(Color value)
        {
            VarColor var = Alloc();
            var.Value = value;
            return var;
        }

        /// <summary>
        /// VarTransform -> Transform
        /// </summary>
        /// <param name="value"></param>
        public static implicit operator Color(VarColor value)
        {
            return value.Value;
        }
    }
}
