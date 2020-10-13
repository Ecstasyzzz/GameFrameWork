using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameFramework
{
    /// <summary>
    /// 数据表格管理基类
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="P"></typeparam>
    public abstract class DataTableDBModelBase<T, P>
        where T : class, new()
        where P : DataTableEntityBase
    {
        protected List<P> list;

        protected Dictionary<int, P> dic;

        public DataTableDBModelBase()
        {
            list = new List<P>();
            dic = new Dictionary<int, P>();
        }

        #region 需要子类实现的属性或方法

        /// <summary>
        /// 数据表名
        /// </summary>
        protected abstract string DataTableName { get; }

        /// <summary>
        /// 加载数据列表
        /// </summary>
        protected abstract void LoadList(MMO_MemoryStream ms);

        #endregion

        /// <summary>
        /// 加载数据表数据
        /// </summary>
        public void LoadData()
        {
            //1.拿到这个表格的buff

            byte[] buffer = GameEntry.ResourceComponent.GetFileBuffer(string.Format("{0}/Script/Data/DataTable/{1}.bytes", GameEntry.ResourceComponent.LocalFilePath, DataTableName));

            using(MMO_MemoryStream ms = new MMO_MemoryStream(buffer))
            {
                LoadList(ms);
            }
        }

        /// <summary>
        /// 获取集合
        /// </summary>
        /// <returns></returns>
        public List<P> GetList()
        {
            return list;
        }

        /// <summary>
        /// 根据编号获取实体
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public P Get(int id)
        {
            if (dic.ContainsKey(id))
            {
                return dic[id];
            }
            return null;
        }
    }
}

