using Newtonsoft.Json;

namespace GrasscutterTools.Game.Shop
{
    /// <summary>
    /// 商品刷新类型
    /// </summary>
    public enum ShopRefreshType
    {
        /// <summary>
        /// 不刷新
        /// </summary>
        [JsonProperty("NONE")]
        None,

        /// <summary>
        /// 按天刷新
        /// </summary>
        [JsonProperty("SHOP_REFRESH_DAILY")]
        Daily,

        /// <summary>
        /// 按周刷新
        /// </summary>
        [JsonProperty("SHOP_REFRESH_WEEKLY")]
        Weekly,

        /// <summary>
        /// 按月刷新
        /// </summary>
        [JsonProperty("SHOP_REFRESH_MONTHLY")]
        Monthly,
    }
}
