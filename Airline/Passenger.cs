using System;

public class Passenger
{
    private string _name;

    private int 
        _noOfBags;

    public Passenger(string name, int noOfBags)
    {
        Name = name;
        NoOfBags = noOfBags;
    }

    public int NoOfBags { get => _noOfBags; set => _noOfBags = value; }
    public string Name { get => _name; set => _name = value; }

    public void AddBags(int number)
    {
        NoOfBags = number;
    }

    public void ChangeName(string newName )
    {
        Name = newName;
    }
}
