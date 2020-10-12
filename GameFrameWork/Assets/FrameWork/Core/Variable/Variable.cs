using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameFramework
{
    public class Variable<T> : VariableBase
    {
        public override Type Type => typeof(T);

        /// <summary>
        /// 当前存储的真实值
        /// </summary>
        public T Value { get; set; }
    }
}

