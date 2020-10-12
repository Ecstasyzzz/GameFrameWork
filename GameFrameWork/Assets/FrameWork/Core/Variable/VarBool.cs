using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameFramework
{
    /// <summary>
    /// bool变量
    /// </summary>
    public class VarBool : Variable<bool>
    {
        /// <summary>
        /// 分配一个对象
        /// </summary>
        /// <returns></returns>
        public static VarBool Alloc()
        {
            VarBool var = GameEntry.PoolComponent.DequeueVarObject<VarBool>();
            var.Value = false;
            var.Retain();
            return var;
        }

        /// <summary>
        /// 分配一个对象
        /// </summary>
        /// <param name="value">初始值</param>
        /// <returns></returns>
        public static VarBool Alloc(bool value)
        {
            VarBool var = Alloc();
            var.Value = value;
            return var;
        }

        /// <summary>
        /// VarBool -> bool
        /// </summary>
        /// <param name="value"></param>
        public static implicit operator bool(VarBool value)
        {
            return value.Value;
        }
    }
}
