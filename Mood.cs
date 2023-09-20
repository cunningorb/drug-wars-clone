public class Mood
{
  /* 
  Ideas for the mood system:

  - The player starts with a mood of "NEUTRAL"
  - Change mood by buying/selling certain items
  - Play interaction menu choice with risk of going too far and lowering mood
  - Events/Locations can affect the ship's mood
  - Mood can affect the ship's fuel consumption
  - Mood can affect the ship's capacity
  - Mood can buff/debuff the ship's trading ability
  - Mood has a velocity that can be affected by events
  - Mood decrements over time

  - Mood score base 60`
  - three tiers: "HAPPY", "NEUTRAL", "SAD"
  */

  // fields that form the structure of the mood object
  public int minBase = 0;
  int maxBase = 60;
  int min = 25; // update these values to change the mood range
  int max = 35;
  int valuePassDTO;
  string stringPassDTO = "cmon";
  int moodScore { get; set; }
  string[] moodArray = new string[3] { "sad", "neutral", "happy"};

  public Mood()
  {
    this.moodScore = getMoodScore();
  }
  // method to decrease the ship capacity based on SAD mood
  public int cargoReduction()
  {
    
    if (moodScore / 20 <= 1)
    {
      return valuePassDTO -=20;
    }
    return moodScore;
  }
  public int getMoodScore()
  {
      int val = Interface.random.Next(min, max); // base 60
      moodScore = Math.Min(val,maxBase);
      return moodScore;
  }
  public string getMoodName()
  {
    if (moodScore<21)
    { 
      return stringPassDTO = moodArray[0];
    }
    else if (moodScore>40)
    {
      return stringPassDTO = moodArray[2];
    }
    else
    {
      return stringPassDTO = moodArray[1];
    }
  }
}
