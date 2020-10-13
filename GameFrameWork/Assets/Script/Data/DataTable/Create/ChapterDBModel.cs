using GameFramework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChapterDBModel : DataTableDBModelBase<ChapterDBModel, ChapterEntity>
{
    protected override string DataTableName => "Chapter";

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

            list.Add(entity);
            dic[entity.Id] = entity;
        }
    }
}
