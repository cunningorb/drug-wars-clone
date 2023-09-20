class Item
{
  // initialize item with name, price, and min and max values
  public string name;
  public string description; // rename to price hint
  public int min;
  public int max;
  public int price { get; set; }
  int quantity;
  public bool consumable { get; set ;}


  // constructor
  public Item(string name, int min, int max, bool consumable = false, string description = "")
  {
    this.name = name;
    this.min = min;
    this.max = max;
    this.price = getPrice(min, max);
    this.description = determineDollarSign(price, max);
  }
  
  // getter and setter for quantity
  public int Quantity
  {
    get { return quantity; }
    set { quantity = value; }
  }

  // getter and setter for price
  public int getPrice(int min, int max)
  {
    int price = Interface.random.Next(min, max);
    return price;
  }

  private string determineDollarSign(int price, int max)
  {
    decimal number = Math.Floor((((decimal)price / (decimal)max)) * 100);

    if (number > 33 && number < 66)
    {
      return "$$$";
    }
    else if (number > 65)
    {
      return "$$$$$$$";
    }
    else
    {
      return "$";
    }
  }

  // getter and setter for name
  public string getName()
  {
    return name;
  }

  // getter and setter for description
  public string getDescription()
  {
    return description;
  }
  
  // getter and setter for min
  public int getMin()
  {
    return min;
  }

  // getter and setter for max
  public int getMax()
  {
    return max;
  }

}
