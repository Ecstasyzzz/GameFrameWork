//===================================================
//作    者：边涯  http://www.u3dol.com
//创建时间：2020-10-13 21:47:21
//备    注：此代码为工具生成 请勿手工修改
//===================================================
using YouYouServer.Core.DataTableBase;

namespace YouYouServer.Model.DataTable
{
    /// <summary>
    /// GameLevelRegion实体
    /// </summary>
    public partial class GameLevelRegionEntity : DataTableEntityBase
    {
        /// <summary>
        /// 游戏关卡Id
        /// </summary>
        public int GameLevelId;

        /// <summary>
        /// 区域Id
        /// </summary>
        public int RegionId;

        /// <summary>
        /// 初始化精灵
        /// </summary>
        public string InitSprite;

    }
}