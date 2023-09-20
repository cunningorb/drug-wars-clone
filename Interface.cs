class Interface
{
  // Public variables
  public static int menuLocation = 10;
  
  //Instantiations
  Vendor vendor = new Vendor();
  Location location = new Location();
  Ship ship = new Ship(Faker.Internet.UserName());
  
  // create a constant for the Thai Baht character
  const string THAI_BHT = "฿";

  // generate random seed for the random number generator
  public static Random random = new Random();

  public void gameStart()
  {
    // header
    Prompt.title();
    Prompt.list("Choose your ship type.","Bonus to fuel", "Happy as a lark");
    var x = Console.ReadKey();
    switch (x.Key)
    {
      case ConsoleKey.D1:
      ship.shipType = 1;
      break;
      case ConsoleKey.D2:
      ship.shipType = 2;
      break;
    }
    Console.Clear();
    /* 
    I want to display the PHASE so we can give the player some context during each TURN.
    One possibility is to createa a method and pass in the phase as an integer. Then a
    switch statement to output the appropriate header/footer screen output.

    PHASE 1 - Travel
    PHASE 2 - Buy/Sell
    PHASE 3 - Events


    */
    ship.shipSetup();
    vendor.refreshInventory();
  }
  
  public void gamePhase2()
  {
    while(ship.shipLoss == false)
      {
        // Phase 1: Turn start operations
        menuLocationUpdate(10);
        menu();

        // Ship information

        // Phase 2: Turn in progress actions 
        ship.travel();
        vendor.refreshInventory();

         // TODO: call random event
         // TODO: eventCallCheckMethod();

      }
      continueOrQuit();
  }

    // create a method that prints out '*' 80 times
  public static void printStars()
  {
    for (int i = 0; i < 60; i++)
    {
      Console.Write("*");
    }
    Console.Write("\n");
  }

  //Methods to draw new lines
  public static void oneLine()
  {
    Console.Write("\n");
  }

    public static void twoLine()
  {
    Console.Write("\n");
    Console.Write("\n");
  }
      public static void threeLine(string str)
  {
    Console.Write("\n");
    Console.Write("\n");
    Console.WriteLine(str);
  }

  public static int menuLocationUpdate(int num)
  {
    menuLocation = num;
    return menuLocation;
  }
  public void menu()
  {
    while (menuLocation >=1)
    {
      if (menuLocation == 10) // Top menu (Location.cs)
      {
        ship.loseConditions();
        gameLose();
        location.interaction();
      }
      else if (menuLocation == 11) // Travel choices (Location.cs)
      {
        location.UserTravelInput();
      }
      else if (menuLocation == 20) // Ship Menu
      {
        ship.interaction();
      }
      else if (menuLocation == 21) // Ship status
      {
        ship.whoAmI();
      }
      else if (menuLocation == 22) // Consume Items
      {
        ship.consumeItemMenu();
      }
      else if (menuLocation == 23) // Check Cargo
      {
        ship.cargoCheck();
      }
      else if (menuLocation == 30) // Vendor trading and loan payment
      {
        vendor.interaction();
      }
      else if (menuLocation == 31) // Buying
      {
        vendor.makeTrade(ship);
      }
      else if (menuLocation == 32) // Selling
      {
        vendor.makeTrade(ship);
      }
      else if (menuLocation == 33) // Loan Payment
      {
        ship.payLoan(0);
      }
      else if (menuLocation == 34) // Loan Payment
      {
        ship.payLoan(0);
      }
       else if (menuLocation == 35) // Loan Payment
      {
        ship.payLoan(0);
      }
    }
  }
  
  public static void continueOrQuit()
  {
    Console.WriteLine("Press spacebar to continue or escape to quit.");
    while (true)
    {
      if (Console.ReadKey().Key == ConsoleKey.Spacebar)
      {
        Console.Clear();
        menuLocationUpdate(10);
        break;
      }
      else if (Console.ReadKey().Key == ConsoleKey.Escape)
      {
        Environment.Exit(0);
      }
    }
  }
  public void gameLose()
  {
    while (ship.shipLoss)

    {Prompt.list("You lost. Do you want to start a new game?", "Yes", "No");
    var x = Console.ReadKey();
    switch (x.Key)
    {
      case ConsoleKey.D1:
      Environment.Exit(0);
      break;
      case ConsoleKey.D2:
      Environment.Exit(0);
      break;
    }}
    
  }
}
