class Cargo
{
  // build inventory of items and quantities
  public int howMany = 0;
  public bool consumedItem;
  public string consumedItemName = "nada";
  public string[] dummy = new string[6];

  // create a List of Items called list
  public List<Item> manifest = new List<Item>();

  // create a method that lists all items and their Quantity
  public void listManifest()
  {
    Interface.oneLine();
    Console.WriteLine("Item List");
    Console.WriteLine("----------");
    foreach (Item item in manifest)
    {
      if(item.Quantity!=0)
      {
        Console.WriteLine($"{manifest.IndexOf(item) +1} | {item.Quantity}x {item.name} @ {item.price}");
      }
    }
    Interface.oneLine();
  }

  public void increase(Item item, int number)
  {
    manifest.Add(item);
    for (int i = 0; i < number; i++)
    {
      item.Quantity++;
      if(item.name == Vendor.productNameBase[0] || item.name == Vendor.productNameBase[3])
      { item.consumable = true; }
    }
  }

  public void decrease(Item item, int number)
  {
    manifest.Remove(item);
    for (int i = 0; i < number; i++)
    {
      item.Quantity--;
    }
  }

  public void cleanCargo()
  {
    
    foreach (Item empty in manifest.Where(x => x.Quantity == 0).ToArray())
    {
      manifest.Remove(empty);
    }
  }
    public bool consumableItemDisplay()
  {
    var consumables = manifest.Where(x => x.consumable == true).ToList();
    foreach (Item item in consumables)
    {
      Console.WriteLine($"{consumables.IndexOf(item) +1} | {item.Quantity}x {item.name} @ {item.price}");
    }
    Console.ReadKey();
    int x = consumables.Count();
    // Interface.menuLocationUpdate(20);
    if (x > 0) {return true;} else {return false;}
  }
  
  public void consumableTransfer() // Return number of items consumed?
  {
    // Accept valid input from user
    // var consumables = cargo.manifest.Where(x => x.consumable == true).Select(y => y.Quantity).ToArray();
    // var z = Prompt.validEntry(consumables[0]);
    // Remove cargo
    // z = Math.Min(i,z);
    // Call fuel or mood effect
  }

  public void consumableOptionMenu() // If consumables exist, they show in this menu and can be selected for transfer
  {
    bool consumableCheck = consumableItemDisplay(); // Menu to guide player through consumable choices
    var consumableName = manifest.Where(x => x.consumable == true).Select(y => y.name).ToArray();
    
    Console.WriteLine("Consume fuel cells to add fuel for your journey.");
    Console.WriteLine("Consume pumpkins to affect your mood.");
    cleanCargo();
    if (consumableCheck)
    {
    Prompt.list("Would you like to consume an item?", "Yes", "No"); 
    var z = Console.ReadKey();
        switch (z.Key)
    {
      case ConsoleKey.D1:
      Console.Clear();
      Prompt.list("Which Item?", consumableName);
      // char input=Console.ReadKey().KeyChar;
      var x = Console.ReadKey();
        switch (x.Key)
        {
          case ConsoleKey.D1:
            Console.Clear();
            var item1 = manifest.Where(a => a.name == consumableName[0]).Select(b => b.Quantity).ToArray();//
            // int c = Convert.ToInt32(item1);
            int d = Prompt.validEntry(item1[0]);
            this.howMany = d;
            consumedItem = true;
            consumedItemName = consumableName[0];
            foreach (var consumed in manifest.Where(p => p.name == consumableName[0]))
              {
                  consumed.Quantity = consumed.Quantity - d;
              }
            // decrease(item1, d);
            Interface.menuLocationUpdate(20);
            break;
          case ConsoleKey.D2:
            Console.Clear();
            Console.WriteLine("You picked item 2");
            var item2 = manifest.Where(a => a.name == consumableName[1]).Select(b => b.Quantity).ToArray();//
            // int c = Convert.ToInt32(item1);
            int e = Prompt.validEntry(item2[0]);
            this.howMany = e;
            consumedItem = true;
            consumedItemName = consumableName[1];
            foreach (var consumed in manifest.Where(p => p.name == consumableName[1]))
              {
                  consumed.Quantity = consumed.Quantity - e;
                  increase(consumed,e);
              }
            Interface.menuLocationUpdate(20);
            break; 
          // case 51:
          
          // break;
        }
        break;
        case ConsoleKey.D2:
          Interface.menuLocationUpdate(20);
          break;
    }
    }
    else
    {
      Interface.threeLine("You don't have any consumables. Purchase them from vendor.");
      consumedItem = false;
      Interface.menuLocationUpdate(20);
    }
  }
}
