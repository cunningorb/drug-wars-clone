class Location
{
    //Location name and category can be declared at class level
    public string name;
    //category should be deprecated once the location class is fully refactored
    public string category;

    //Location effect
    public object effect;

    //Level defines index location of array for location names
    public static int level = 0;
    
    //Remove a planet that has been visited (not currently in use due to List.Remove option)
    public bool visited;

    //All locations are stored in a list as objects
    public List<Location> locations = new List<Location>();

    //Locations generated per node are stored in a seperate list
    public List<Location> travelOptions = new List<Location>();
    
    public string[] locationNames = new string[5];
    
    public int[] travelIndex = new int[3];

    public Location()
    {
        //logic that every location will use can run here
        this.name = "name";
        this.category = "category";
        Effect e1 = new Effect();
        this.effect = e1;
        this.visited = false;
    }

        //This will randomly choose between 1-4 locations of random types to offer to the player
    public void NodeGenerate() {
        //int x = Interface.random.Next(2,3);
        for (int i = 0; i < 3; i++)
        {
            int index = Interface.random.Next(locations.Count());
            Console.WriteLine($"{i+1} The {locations[index].category} {locations[index].name}");
            travelIndex[i] = index;
        }
    }

    // populate location list
    public void UserTravelInput() 
    {
        LocationSelect();
        Console.WriteLine("Where do you want to go?");
        NodeGenerate();
        var x = Console.ReadKey();
        switch (x.Key)
    {
        case ConsoleKey.D1:
            Console.Clear();
            Console.WriteLine($"Always wanted to go to {locations[travelIndex[0]].category} {locations[travelIndex[0]].name}");
            this.name = locations[travelIndex[0]].name;
            break;
        case ConsoleKey.D2:
            Console.Clear();
            Console.WriteLine($"Good choice. Let's roll out to {locations[travelIndex[1]].category} {locations[travelIndex[1]].name}");
            this.name = locations[travelIndex[1]].name;
            break;
        case ConsoleKey.D3:
            Console.Clear();
            Console.WriteLine($"My mom is from {locations[travelIndex[2]].category} {locations[travelIndex[2]].name}");
            this.name = locations[travelIndex[2]].name;
            break;
        // case ConsoleKey.D4:
        //     Console.Clear();
        //     Console.WriteLine($"My mom is from {locations[travelIndex[3]].category} {locations[travelIndex[3]].name}");
        //     break;
    }
    Ship.updateCurrentLocation(this);
    Interface.menuLocationUpdate(0);
    }

    public void interaction()
    {
        Console.Clear();
        Console.WriteLine($"You are on {Ship.currentLocation}.");
        Console.WriteLine($"What would you like to do? Type 1-3 on your keyboard to choose.");
        Console.WriteLine($"1. Travel | 2. Check Ship | 3. Visit Vendor");
        var x = Console.ReadKey();
        switch (x.Key)
        {
            case ConsoleKey.D1:
                Console.Clear();
                Console.WriteLine("Travel");
                Interface.menuLocationUpdate(11);
                break;
            case ConsoleKey.D2:
                // Console.Clear();
                Console.WriteLine("Ship Status");
                Interface.menuLocationUpdate(20);
                break;
            case ConsoleKey.D3:
                Console.Clear();
                Console.WriteLine("Vendor");
                Interface.menuLocationUpdate(30);
                break; 
        }
    }

    public virtual void LocationSelect()
    {
        //Planets, Nebulas and Black Holes inherit this function 
        for (int i = 0; i < 5; i++)
        {
            locations.Add(new Planet());
            locations.Add(new Nebula());
            locations.Add(new BlackHole());
            level++;
        }        
        //print the result of all items in the locations list
        //listAllLocations();
        Console.WriteLine("Make your play.");
        level =0;
    }

    // create a method to output each location in locations to the console
    public void listAllLocations() {
        foreach (Location location in this.locations)
        {
            Console.WriteLine($"{location.category} {location.name}");
        }
    }



    public void MapSelect(Ship ship)
    {
        if(ship.moodScore < 20)
        {
            int y = Interface.random.Next(locations.Count);
            Console.WriteLine($"You at {locations[y].category} {locations[y].name} yo.");
            Console.ReadKey();
        }
        else
        {
            int y = Interface.random.Next(locations.Count);
            Console.WriteLine($"You at {locations[y].category} {locations[y].name} man.");
            Console.ReadKey();
        }
    }
    public class Planet : Location
    {
        public Planet()
        {
            string[] locationNames = new string[5] { "OG Urth", "Como Ghen", "Lollipop Spaceport", "Milky Whey", "Battle Creek" };
            this.name = locationNames[level];
            this.category = typeof(Planet).Name;
        }

        public override void LocationSelect()
        {
        }
        
    }

    public class Nebula : Location
    {
        public Nebula()
        {
            string[] locationNames = new string[5] { "M53", "Route 66", "Haunted Cow", "West Brey", "Enterfries" };
            this.name = locationNames[level];
            this.category = typeof(Nebula).Name;
        }

        public override void LocationSelect()
        {
        }
    }

    public class BlackHole : Location
    {
        public BlackHole()
        {
            string[] locationNames = new string[5] { "Terry", "Prince", "Winehouse", "Rickman", "Jackson" };
            this.name = locationNames[level];
            this.category = typeof(BlackHole).Name;
        }

        public override void LocationSelect()
        {
        }
    }


}
