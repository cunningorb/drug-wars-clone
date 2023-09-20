class Ship
{
  // field definitions, the shape of the object
  public String registration;
  public int fuel;
  public int capacity;
  public int credits;
  public int moodScore;
  public string moodName;
  public int burnRate;
  public static string currentLocation = "HOME BASE";
  public int shipType;
  public bool shipLoss;

  // Every ship needs its cargo + a starting loan
  Cargo cargo = new Cargo();
  Loan loan = new Loan();
  Effect effect = new Effect();
  Mood mood = new Mood();
  
  // constructor
  public Ship(String registration)
  {
    this.registration = registration;
    this.fuel = 6;
    this.capacity = 100;
    this.credits = loan.currentCredits;
    this.burnRate = 2;
    this.moodName = mood.getMoodName();
    this.moodScore = mood.getMoodScore();
  }

  public void interaction()
  {
    //Buy, sell, pay loan or leave
    Prompt.list("Choose an action", "View Ship", "Consume Items","Check Cargo", "Leave");
    Interface.oneLine();
    var y = Console.ReadKey();
    switch (y.Key)
    {
      case ConsoleKey.D1:
          Console.Clear();
          Interface.menuLocationUpdate(21);
          break;
      case ConsoleKey.D2:
          Console.Clear();
          Interface.menuLocationUpdate(22);
          break;
      case ConsoleKey.D3:
          Console.Clear();
          Interface.menuLocationUpdate(23);
          break;
      case ConsoleKey.D4:
          Console.Clear();
          Interface.menuLocationUpdate(10);
          break;
    }
  }
  public void shipSetup() // On game start only
  {
    loan.getLoan();
    updateCredits();
  }
  public void whoAmI()
  {
    Console.WriteLine($"Your ship is named {registration}");
    Console.WriteLine($"Current location is {currentLocation}");
    Console.WriteLine($"Your ship currently has {fuel} fuel");
    shipTypeDisplay();
    Console.WriteLine($"Your ship has a capacity of {capacity} cargo space" );
    Console.WriteLine($"You have ${credits} credits");
    displayLoanStatus();
    Console.WriteLine($"Your ship is level {moodScore} mood.");
    System.Console.WriteLine("Press key to continue");
    Console.ReadKey();
    Interface.menuLocationUpdate(10);
  }

  public void shipTypeDisplay()
  {
    if (shipType == 1)
    {
      Console.WriteLine($"Your special ability adds {effect.effectAmount} per travel event.");
    }
    if (shipType == 2)
    {
      Console.WriteLine($"Your special ability has a chance to increase your mood by {effect.effectAmount} per travel event.");
    }
  }
  public void shipTypeActions()
  {
    if (shipType == 1)
    {
      effect.FuelBuff(this, 1);
    }
    if (shipType == 2)
    {
      effect.MoodBuff(this, 1);
    }
  }
  public void displayLoanStatus()
  {
    loan.checkLoanPaid();
    if(loan.loanPaid == false)
    {
      Console.WriteLine($"It costs ${loan.LoanAmount} credits to pay the loan");
      Console.WriteLine($"Loan increases every time you travel by interest rate: {loan.InterestRate}%");
      Console.WriteLine($"You have {loan.loanRepaymentDays} days to pay the loan before you lose.");
    }
  }

  public static void updateCurrentLocation(Location location) {
    currentLocation = location.name;
  }

  public void travel() {
    if (fuel>=burnRate)
    {
      fuel -= burnRate;
      MentalHealthCheck();
      shipTypeActions();
      loan.checkLoanPaid();
      loseConditions();
      if(loan.loanPaid == false)
      {
        loan.applyInterest();
        loan.repaymentDate();
      }
    }
    else
    {
      shipLoss = true;
    }
    Interface.menuLocationUpdate(0);
  }

  public void creditCheck()
  {
    Interface.threeLine($"You have {credits} credits available.");
  }
  public void travelStatus()
  {
    Console.WriteLine($"{registration} burned {burnRate} fuel and has {fuel} fuel remaining");
    Console.WriteLine($"Available cargo capacity: {capacity}");

  }
  public void loseConditions()
  {
    if (loan.loanRepaymentDays <1)
    {
      shipLoss = true;
    }
    // else if (mood.)
  }

  public void payLoan(int payment) {
    // loan.currentCredits = this.credits;
    loan.interaction();
    updateCredits();
  }
  public void updateCredits()
  {
    credits = credits + loan.currentCredits;
    loan.currentCredits = 0;
  }

      public void buyItem(Vendor vendor)
    {
      vendor.tradeState = false;
      int purchaseAmount = Math.Min(vendor.itemAmount, capacity);
      Console.WriteLine($"You can buy {vendor.itemAmount} {vendor.inventory[vendor.itemIndex].name}.");
      vendor.itemAmount = Prompt.validEntry(purchaseAmount);
      vendor.itemPrice = vendor.inventory[vendor.itemIndex].price * vendor.itemAmount;
      Console.WriteLine($"You will transfer {vendor.itemAmount} {vendor.inventory[vendor.itemIndex].name} from {vendor.name} to {registration}. Type 'Y' to confirm, 'N' to cancel.");
      var x = Console.ReadKey();
      switch (x.Key)
      {
        case ConsoleKey.Y:
          Console.Clear();
          if (capacity>0)
          {
            transferItem(vendor);
          }
          break;
        case ConsoleKey.N:
          Console.Clear();
          break;
      }
    }

    public void sellItem(Vendor vendor)
    {
      vendor.tradeState = true; 
      var tradableItemsName = cargo.manifest.Where(x => x.Quantity != 0).Select(y => y.name).ToArray();
      var tradableItemsQuantity = cargo.manifest.Select(y => y.Quantity).ToArray();

      cargo.cleanCargo();
      cargo.listManifest();
      
      Prompt.list("What are you selling today?", tradableItemsName);
      var x = Console.ReadKey();
        switch (x.Key)
        {
          case ConsoleKey.D1:
          var item1 = cargo.manifest.Where(a => a.name == tradableItemsName[0]).Select(b => b.Quantity).ToArray();
          var sell1 = vendor.inventory.Where(a => a.name == tradableItemsName[0]).Select(b => b.price).ToArray();
            int c = Prompt.validEntry(item1[0]);
            cargo.howMany = c;
            string soldItemName = tradableItemsName[0];
            foreach (var traded in cargo.manifest.Where(p => p.name == tradableItemsName[0]))
              {
                  traded.Quantity = traded.Quantity - c;
                  credits = credits + (sell1[0]*c);
                  capacity = capacity + c;
              }
          break;
          case ConsoleKey.D2:
          var item2 = cargo.manifest.Where(a => a.name == tradableItemsName[1]).Select(b => b.Quantity).ToArray();
          var sell2 = vendor.inventory.Where(a => a.name == tradableItemsName[0]).Select(b => b.price).ToArray();
            int d = Prompt.validEntry(item2[0]);
            cargo.howMany = d;
            soldItemName = tradableItemsName[1];
            foreach (var traded in cargo.manifest.Where(p => p.name == tradableItemsName[1]))
              {
                  traded.Quantity = traded.Quantity - d;
                  credits = credits + (sell2[0]*d);
                  capacity = capacity + d;
              }
          break;
          case ConsoleKey.D3:
          var item3 = cargo.manifest.Where(a => a.name == tradableItemsName[2]).Select(b => b.Quantity).ToArray();
          var sell3 = vendor.inventory.Where(a => a.name == tradableItemsName[0]).Select(b => b.price).ToArray();
            int e = Prompt.validEntry(item3[0]);
            cargo.howMany = e;
            soldItemName = tradableItemsName[2];
            foreach (var traded in cargo.manifest.Where(p => p.name == tradableItemsName[2]))
              {
                  traded.Quantity = traded.Quantity - e;
                  credits = credits + (sell3[0]*e);
                  capacity = capacity + e;
              }
          break;
          case ConsoleKey.D4:
          var item4 = cargo.manifest.Where(a => a.name == tradableItemsName[3]).Select(b => b.Quantity).ToArray();
          var sell4 = vendor.inventory.Where(a => a.name == tradableItemsName[0]).Select(b => b.price).ToArray();
            int f = Prompt.validEntry(item4[0]);
            cargo.howMany = f;
            soldItemName = tradableItemsName[3];
            foreach (var traded in cargo.manifest.Where(p => p.name == tradableItemsName[3]))
              {
                  traded.Quantity = traded.Quantity - f;
                  credits = credits + (sell4[0]*f);
                  capacity = capacity + f;
              }
          break;
          case ConsoleKey.D5:
          var item5 = cargo.manifest.Where(a => a.name == tradableItemsName[4]).Select(b => b.Quantity).ToArray();
          var sell5 = vendor.inventory.Where(a => a.name == tradableItemsName[0]).Select(b => b.price).ToArray();
            int g = Prompt.validEntry(item5[0]);
            cargo.howMany = g;
            soldItemName = tradableItemsName[4];
            foreach (var traded in cargo.manifest.Where(p => p.name == tradableItemsName[4]))
              {
                  traded.Quantity = traded.Quantity - g;
                  credits = credits + (sell5[0]*g);
                  capacity = capacity + g;
              }
          break;
          case ConsoleKey.D6:
          var item6 = cargo.manifest.Where(a => a.name == tradableItemsName[5]).Select(b => b.Quantity).ToArray();
            int h = Prompt.validEntry(item6[0]);
            cargo.howMany = h;
            soldItemName = tradableItemsName[5];
            foreach (var traded in cargo.manifest.Where(p => p.name == tradableItemsName[5]))
              {
                  traded.Quantity = traded.Quantity - h;
                  credits = credits + (traded.price*h);
                  capacity = capacity + h;
              }
          break;
        }
        Interface.menuLocationUpdate(30);
      Math.Max(0,1);
    }

  public void transferItem(Vendor vendor) //TODO: Fix this so that we don't add a new object to the manifest if the same name already exists
  {
    if (vendor.tradeState == false)
    {
      this.capacity = this.capacity - vendor.itemAmount;
      this.credits = this.credits - vendor.itemPrice;
      cargo.howMany = cargo.howMany + this.capacity;
      cargo.increase(vendor.inventory[vendor.itemIndex], vendor.itemAmount);
      cargoCheck();
      creditCheck();
    }
  }

  public void cargoCheck()
  {
    cargo.listManifest();
    Console.ReadKey();
    Interface.menuLocationUpdate(20);
  }

  public string locationCheck(Location location)
  {
    currentLocation = location.name;
    return currentLocation;
  }

  // implement burnFuel method and update fuel level
  public void burnFuel(int rate)
  {
    this.fuel -= rate;
  }
  
  public void MentalHealthCheck()
  {
      if (moodScore <= mood.minBase)
      {
        shipLoss = true;
      }
      if(moodScore <= 2)
      {
          fuel -= 1;
      }
  }
  public void consumeItemMenu()
  {
    cargo.consumableOptionMenu();
    while (cargo.consumedItem)
    if (cargo.consumedItemName.Equals(Vendor.productNameBase[0]))
    {
      effect.MoodBuff(this, cargo.howMany);
      break;
    }
    else if (cargo.consumedItemName.Equals(Vendor.productNameBase[3]))
    {
      effect.FuelBuff(this, cargo.howMany);
      capacity += cargo.howMany;
      break;
    }
  }
  
}

