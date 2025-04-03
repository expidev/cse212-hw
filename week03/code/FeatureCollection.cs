public class FeatureCollection
{
    // TODO Problem 5 - ADD YOUR CODE HERE
    public Features[] Features { get; set; }
}

public class Features
{
    public string Type { get; set; }
    public Properties Properties { get; set; }
}

public class Properties
{
    public string Place { get; set; }
    public decimal Mag { get; set; }
    public long Time { get; set; }
}