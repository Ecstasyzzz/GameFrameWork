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
    public class VarTransform : Variable<Transform>
    {
        /// <summary>
        /// 分配一个对象
        /// </summary>
        /// <returns></returns>
        public static VarTransform Alloc()
        {
            VarTransform var = GameEntry.PoolComponent.DequeueVarObject<VarTransform>();
            var.Value = null;
            var.Retain();
            return var;
        }

        /// <summary>
        /// 分配一个对象
        /// </summary>
        /// <param name="value">初始值</param>
        /// <returns></returns>
        public static VarTransform Alloc(Transform value)
        {
            VarTransform var = Alloc();
            var.Value = value;
            return var;
        }

        /// <summary>
        /// VarTransform -> Transform
        /// </summary>
        /// <param name="value"></param>
        public static implicit operator Transform(VarTransform value)
        {
            return value.Value;
        }
    }
}
