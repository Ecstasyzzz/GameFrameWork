﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

namespace GameFramework
{
    /// <summary>
    /// 资源组件
    /// </summary>
    public class ResourceComponent : BaseComponent
    {
        /// <summary>
        /// 本地文件路径
        /// </summary>
        public string LocalFilePath = "";

        protected override void OnAwake()
        {
            base.OnAwake();

#if DISABLE_ASSETBUNDLE
            LocalFilePath = Application.dataPath;
#else
            LocalFilePath = Application.persistentDataPath;
#endif
        }

        /// <summary>
        /// 读取本地文件到byte数组
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public byte[] GetFileBuffer(string path)
        {
            byte[] buffer = null;

            using (FileStream fs = new FileStream(path, FileMode.Open))
            {
                buffer = new byte[fs.Length];
                fs.Read(buffer, 0, buffer.Length);
            }
            return buffer;
        }

        public override void ShutDown()
        {
        }
    }
}
 