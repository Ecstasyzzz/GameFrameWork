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
    /// GameLevelMonster数据管理
    /// </summary>
    public partial class GameLevelMonsterDBModel : DataTableDBModelBase<GameLevelMonsterDBModel, GameLevelMonsterEntity>
    {
        /// <summary>
        /// 数据表完整路径
        /// </summary>
        public override string DataTableFullPath => ServerConfig.DataTablePath + "/GameLevelMonster.bytes";

        /// <summary>
        /// 加载列表
        /// </summary>
        protected override void LoadList(MMO_MemoryStream ms)
        {
            int rows = ms.ReadInt();
            int columns = ms.ReadInt();

            for (int i = 0; i < rows; i++)
            {
                GameLevelMonsterEntity entity = new GameLevelMonsterEntity();
                entity.Id = ms.ReadInt();
                entity.GameLevelId = ms.ReadInt();
                entity.Grade = ms.ReadInt();
                entity.RegionId = ms.ReadInt();
                entity.SpriteId = ms.ReadInt();
                entity.SpriteCount = ms.ReadInt();
                entity.Exp = ms.ReadInt();
                entity.Gold = ms.ReadInt();
                entity.DropEquip = ms.ReadUTF8String();
                entity.DropItem = ms.ReadUTF8String();
                entity.DropMaterial = ms.ReadUTF8String();

                m_List.Add(entity);
                m_Dic[entity.Id] = entity;
            }
        }
    }
}