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
    /// Chapter数据管理
    /// </summary>
    public partial class ChapterDBModel : DataTableDBModelBase<ChapterDBModel, ChapterEntity>
    {
        /// <summary>
        /// 数据表完整路径
        /// </summary>
        public override string DataTableFullPath => ServerConfig.DataTablePath + "/Chapter.bytes";

        /// <summary>
        /// 加载列表
        /// </summary>
        protected override void LoadList(MMO_MemoryStream ms)
        {
            int rows = ms.ReadInt();
            int columns = ms.ReadInt();

            for (int i = 0; i < rows; i++)
            {
                ChapterEntity entity = new ChapterEntity();
                entity.Id = ms.ReadInt();
                entity.ChapterName = ms.ReadUTF8String();
                entity.GameLevelCount = ms.ReadInt();
                entity.BG_Pic = ms.ReadUTF8String();
                entity.Uvx = ms.ReadFloat();
                entity.Uvy = ms.ReadFloat();

                m_List.Add(entity);
                m_Dic[entity.Id] = entity;
            }
        }
    }
}