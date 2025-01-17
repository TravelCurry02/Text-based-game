using System;

class Player
{
    public string Name { get; set; }
    public int Health { get; set; } = 100;
    public int Score { get; set; } = 0;

    public Player(string name)
    {
        Name = name;
    }
}
