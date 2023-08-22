using Newtonsoft.Json;

namespace GrasscutterTools.Game.Data.Excels
{
    [ResourceType("QuestExcelConfigData.json")]
    internal class QuestData : GameResource
    {
        [JsonProperty("subId")]
        public override int Id { get; set; }

        [JsonProperty("mainId")]
        public int MainId { get; set; }

        [JsonProperty("order")]
        public int Order { get; set; }
    }
}
