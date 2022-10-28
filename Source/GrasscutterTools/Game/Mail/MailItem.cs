namespace GrasscutterTools.Game.Mail
{
    /// <summary>
    /// 附件
    /// </summary>
    public struct MailItem
    {
        /// <summary>
        /// 物品ID
        /// </summary>
        public int ItemId { get; set; }

        /// <summary>
        /// 物品数量
        /// </summary>
        public int ItemCount { get; set; }

        /// <summary>
        /// 物品等级
        /// </summary>
        public int ItemLevel { get; set; }

        public override string ToString()
        {
            var name = GameData.Items[ItemId];
            if (name == ItemMap.EmptyName)
                name = GameData.Weapons[ItemId];
            if (name == ItemMap.EmptyName)
                name = GameData.Artifacts[ItemId];
            if (ItemLevel > 1)
                return $"{ItemId}:{name} x{ItemCount} lv{ItemLevel}";
            else if (ItemCount > 1)
                return $"{ItemId}:{name} x{ItemCount}";
            else
                return $"{ItemId}:{name}";
        }
    }
}
