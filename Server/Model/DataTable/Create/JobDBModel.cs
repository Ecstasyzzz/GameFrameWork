//===================================================
//作    者：边涯  http://www.u3dol.com
//创建时间：2020-10-13 21:47:21
//备    注：此代码为工具生成 请勿手工修改
//===================================================
using YouYouServer.Core.DataTableBase;
using YouYouServer.Core.Common;

namespace YouYouServer.Model.DataTable
{
    /// <summary>
    /// Job数据管理
    /// </summary>
    public partial class JobDBModel : DataTableDBModelBase<JobDBModel, JobEntity>
    {
        /// <summary>
        /// 数据表完整路径
        /// </summary>
        public override string DataTableFullPath => ServerConfig.DataTablePath + "/Job.bytes";

        /// <summary>
        /// 加载列表
        /// </summary>
        protected override void LoadList(MMO_MemoryStream ms)
        {
            int rows = ms.ReadInt();
            int columns = ms.ReadInt();

            for (int i = 0; i < rows; i++)
            {
                JobEntity entity = new JobEntity();
                entity.Id = ms.ReadInt();
                entity.Name = ms.ReadUTF8String();
                entity.HeadPic = ms.ReadUTF8String();
                entity.JobPic = ms.ReadUTF8String();
                entity.PrefabName = ms.ReadUTF8String();
                entity.Desc = ms.ReadUTF8String();
                entity.Attack = ms.ReadInt();
                entity.Defense = ms.ReadInt();
                entity.Hit = ms.ReadInt();
                entity.Dodge = ms.ReadInt();
                entity.Cri = ms.ReadInt();
                entity.Res = ms.ReadInt();
                entity.UsedPhyAttackIds = ms.ReadUTF8String();
                entity.UsedSkillIds = ms.ReadUTF8String();

                m_List.Add(entity);
                m_Dic[entity.Id] = entity;
            }
        }
    }
}