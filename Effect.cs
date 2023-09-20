
class Effect
{
    public int effectAmount;
    public int FuelBuff(Ship ship, int amount)
    {
        ship.fuel = ship.fuel + amount;
        Interface.threeLine($"You added {amount} to your reserves.");
        effectAmount = amount;
        return ship.fuel;
    }
        public int MoodBuff(Ship ship, int amount)
    {
        int x = 0;
        for (int i = 0; i < amount; i++)
        {
            x = x + Interface.random.Next(0,2);
        }
        Interface.threeLine($"You increased your mood by {x}");
        effectAmount = x;
        return ship.moodScore = ship.moodScore + x;
    }
}

