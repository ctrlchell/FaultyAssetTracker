namespace FaultyAssetTracker.Models
{
    public class CreateInventoryAssetDto
    {
        public string Category { get; set; } = string.Empty;
        public string AssetName { get; set; } = string.Empty;
        public string SerialNo { get; set; } = string.Empty;
        public string AssetTag { get; set; } = string.Empty;
        public string Branch { get; set; } = string.Empty;
        public string Vendor { get; set; } = string.Empty;
    }
}