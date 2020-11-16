using System;

public class Plane
{
    private string _type;
    private int _capacity;
    private int _totalWeight;

    public Plane(string type, int capacity, int totalWeight)
    {
        Type = type;
        Capacity = capacity;
        TotalWeight = totalWeight;
    }

    public string Type { get => _type; set => _type = value; }
    public int Capacity { get => _capacity; set => _capacity = value; }
    public int TotalWeight { get => _totalWeight; set => _totalWeight = value; }
}
