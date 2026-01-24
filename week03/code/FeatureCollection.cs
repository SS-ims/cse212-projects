public class FeatureCollection
{
    // Top-level list of earthquake features from the USGS feed.
    public List<Feature> Features { get; set; } = [];
}

public class Feature
{
    // Properties section that contains place and magnitude info.
    public FeatureProperties Properties { get; set; } = new();
}

public class FeatureProperties
{
    // Location description for the quake.
    public string Place { get; set; } = string.Empty;
    // Magnitude for the quake (may be missing in the feed).
    public double? Mag { get; set; }
}