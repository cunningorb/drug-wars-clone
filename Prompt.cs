class Prompt
{
  /* Here we have methods which display console output
  and return integers, to be used for control flow. 
  
  Prompts interact with Location, Vendor, Loan, and Ship classes.
  */


  // generic method that takes params and outputs them in a list to the console
  public static int origRow { get; set; }
  public static int origCol { get; set; }
  public static int origWidth = Console.WindowWidth;
  public static int origHeight = Console.WindowHeight;

  public static int list(string str, params string[] list)
  {
    int position = 1;
    Console.WriteLine("\n");
    Console.WriteLine(str);
    Console.WriteLine("----------");
    foreach (string item in list)
    {
      Console.WriteLine($"[{position}] {item}");
      position++;
    }
    Console.WriteLine("----------");
    Console.WriteLine("\n");
    // var x = Console.ReadKey().Key;
    
    return position;
    // return x;
    // return Convert.ToInt32(x);
  }

  // Title method that displays the title of the game
  public static void title()
  {
    Border.WriteAt("------------------------------", origWidth / 2, 0);
    Border.WriteAt("-------- TAMA TRADER ---------", origWidth / 2, 1);
    Border.WriteAt("------------------------------", origWidth / 2, 2);
  }

  public static int validEntry(int a) //Use system wide for valid number entry
  {
    string? input;
    int b;
    bool result = false;

    while ( result == false )
        {
        Console.Clear();
        Console.WriteLine ($"Please type an amount between 0 and {a}.");
        input = Console.ReadLine();
        result = int.TryParse (input, out b);
        if ( result == false )
            {
            Console.WriteLine ($"Try again fool.");
            }
        else if (b < 1)
        {
          break;
        }
        else
            {
            a = Math.Min(b, a);
            break;
            }
        }
    return a;
  }
    public static double validDoubleEntry(double a) //Use system wide for valid number entry
  {
    string? input;
    double b;
    bool result = false;

    while ( result == false )
        {
        Console.Clear();
        Console.WriteLine ($"Please type an amount between 0 and {a}.");
        input = Console.ReadLine();
        result = double.TryParse (input, out b);
        if ( result == false )
            {
            Console.WriteLine ($"Try again fool.");
            }
        else if (b < 1)
        {
          break;
        }
        else
            {
            a = Math.Min(b, a);
            break;
            }
        }
    return a;
  }

}

class Border : Prompt
{
  /* 
    Border.WriteAt("------------------------------", 0, 0);
    Border.WriteAt("|  PHASE 1 - Travel  |", 4, 1);
    Border.WriteAt("------------------------------", 0, 2);

    Prompt.list("Travel", "Buy/Sell", "Events", "What is your ship name?", "Why am I so stoopid?");
  */

  public static void WriteAt(string s, int x, int y)
  {
  try
      {
      Console.SetCursorPosition(origCol+x, origRow+y);
      Console.Write(s);
      }
  catch (ArgumentOutOfRangeException e)
      {
      Console.Clear();
      Console.WriteLine(e.Message);
      }
  }
}