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
    /// GameLevel数据管理
    /// </summary>
    public partial class GameLevelDBModel : DataTableDBModelBase<GameLevelDBModel, GameLevelEntity>
    {
        /// <summary>
        /// 数据表完整路径
        /// </summary>
        public override string DataTableFullPath => ServerConfig.DataTablePath + "/GameLevel.bytes";

        /// <summary>
        /// 加载列表
        /// </summary>
        protected override void LoadList(MMO_MemoryStream ms)
        {
            int rows = ms.ReadInt();
            int columns = ms.ReadInt();

            for (int i = 0; i < rows; i++)
            {
                GameLevelEntity entity = new GameLevelEntity();
                entity.Id = ms.ReadInt();
                entity.ChapterID = ms.ReadInt();
                entity.Name = ms.ReadUTF8String();
                entity.SceneName = ms.ReadUTF8String();
                entity.SmallMapImg = ms.ReadUTF8String();
                entity.isBoss = ms.ReadInt();
                entity.Ico = ms.ReadUTF8String();
                entity.PosInMap = ms.ReadUTF8String();
                entity.DlgPic = ms.ReadUTF8String();
                entity.CameraRotation = ms.ReadUTF8String();
                entity.Audio_BG = ms.ReadUTF8String();

                m_List.Add(entity);
                m_Dic[entity.Id] = entity;
            }
        }
    }
}