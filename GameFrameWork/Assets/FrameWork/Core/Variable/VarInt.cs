using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameFramework
{
    public class VarInt : Variable<int>
    {
        public static VarInt Alloc()
        {
            VarInt var = GameEntry.PoolComponent.DequeueVarObject<VarInt>();
            var.Value = 0;
            var.Retain();
            return var;
        }

        public static VarInt Alloc(int value)
        {
            VarInt var = Alloc();
            var.Value = value;
            return var;
        }

        public static implicit operator int(VarInt v)
        {
            return v.Value;
        }
    }
}