class Vendor
{
    public string name;  // Vendor name field

    public int itemIndex = 0;
    public int itemAmount = 0;
    public int itemPrice = 0;
    public int itemTransfer = 0;
    public bool tradeState = false;
    public static string[] productNameBase = new string[6] { "Space Pumpkin", "Interstitial Gnome", "Micracyte Tablet", "Cerillium Fuel Cell", "Stuffed Panda", "Fractured Germ" };
    // public string[] productNames = new string[6] { productNameBase[0], "Interstitial Gnome", "Micracyte Tablet", "Cerillium Fuel Cell", "Stuffed Panda", "Fractured Germ" };
    int[,] productPrices = new int[,] { { 50, 85 }, { 5, 35 }, { 100, 350 }, { 40, 110 }, { 1, 20 }, { 1200, 1500 } };
    bool[] consumables = new bool[6] { true, false, false, true, false, false };

    public List<Item> inventory = new List<Item>();

    // create a constructor that initializes the inventory array
    public Vendor()
    {
      this.name = "default";
    }

    public void refreshInventory()
    {
      this.name = Faker.Company.Name();
      inventory.Clear();
      string[] productNames = new string[6];
      for (int i = 0; i < 6; i++)
      {
        productNames[i] = productNameBase[i]; 
        inventory.Add(new Item(productNames[i], productPrices[i,0], productPrices[i,1], consumables[i]));
      }
    }

    // create a method that lists all items and their prices
    public void listAllItems()
    {
      Interface.oneLine();
      Console.WriteLine("Item List");
      Console.WriteLine("----------");

      // foreach loop through Vendor.inventory array
      // instantiate Vendor class
      foreach (Item item in inventory)
      {
        Console.WriteLine($"{inventory.IndexOf(item) +1} | ${item.price} | {item.name} - {item.description}");
      }
      Interface.oneLine();
    }

    public void interaction()
    {
      //Buy, sell, pay loan or leave
      listAllItems();
      Console.WriteLine($"What can {name} do for ya today?");
      Console.WriteLine("Enter your choice on the keyboard: 1. Buy | 2. Sell | 3. See Loan Shark | 4. Leave");
      
      var x = Console.ReadKey();
      switch (x.Key)
      {
        case ConsoleKey.D1:
            tradeState = false;
            Console.Clear();
            Interface.menuLocationUpdate(31);
            break;
        case ConsoleKey.D2:
            tradeState = true;
            Console.Clear();
            Interface.menuLocationUpdate(32);
            break;
        case ConsoleKey.D3:
            Console.Clear();  
            Interface.menuLocationUpdate(33);
            break; 
        case ConsoleKey.D4:
            Console.Clear();
            Interface.menuLocationUpdate(10);
            break; 
      }
    }

    // Vendor trading method
    public void makeTrade(Ship ship)
    {
      if (tradeState == false)
    {
      selectItem(ship);
      ship.buyItem(this);
    }
    else if (tradeState == true)
    {
      ship.sellItem(this);
    }
      Interface.menuLocationUpdate(30);
    }
    public void selectItem(Ship ship) 
    {
      Console.WriteLine($"You have {ship.credits} credits to spend and {ship.capacity} slots available.");
      Interface.twoLine();
      listAllItems();
      Interface.oneLine();
      Console.WriteLine("Enter your choice on the keyboard: 1 - 6, or escape to cancel trade.");
      var x = Console.ReadKey();
      switch (x.Key)
      {
        case ConsoleKey.D1:
            itemIndex = 0;
            itemAmount = ship.credits / inventory[itemIndex].price;
            itemPrice =  inventory[itemIndex].price * itemAmount;
            break;
        case ConsoleKey.D2:
            itemIndex = 1;
            itemAmount = ship.credits / inventory[itemIndex].price; 
            itemPrice =  inventory[itemIndex].price * itemAmount;
            break;
        case ConsoleKey.D3:
            itemIndex = 2;
            itemAmount = ship.credits / inventory[itemIndex].price; 
            itemPrice =  inventory[itemIndex].price * itemAmount;
            break; 
        case ConsoleKey.D4:
            itemIndex = 3;
            itemAmount = ship.credits / inventory[itemIndex].price; 
            itemPrice =  inventory[itemIndex].price * itemAmount;
            break;
        case ConsoleKey.D5:
            itemIndex = 4;
            itemAmount = ship.credits / inventory[itemIndex].price; 
            itemPrice =  inventory[itemIndex].price * itemAmount;
            break;
        case ConsoleKey.D6:
            itemIndex = 5;
            itemAmount = ship.credits / inventory[itemIndex].price; 
            itemPrice =  inventory[itemIndex].price * itemAmount;
            break;
        case ConsoleKey.Escape:
            Interface.menuLocationUpdate(30);
            break;
      }
      Interface.menuLocationUpdate(30);
      Console.Clear();
    }
}