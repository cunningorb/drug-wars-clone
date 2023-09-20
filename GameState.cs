using Terminal.Gui;

class GameState
{
  // use Terminal.Gui.Application.Run to start the game
  // public static void Start()
  // {
  //   Application.Init ();

  //   var label = new Label ("T A M A  T R A D E R") {
  //       X = Pos.Center (),
  //       Y = Pos.Center (),
  //       Height = 1,
  //   };
    
  //   // create a MessageBox.Query with options to play, quit
  //   var messageBox =  MessageBox.Query ("Question", "Keep playing?", "Play", "Quit");
  //   System.Console.WriteLine(messageBox);

  //   Application.Top.Add (win);
  //   Application.Run ();
  //   Application.Shutdown ();

  // }

  // create a method that updates the game state

  // create a method that accepts a string "state" and calls the corresponding method
  // public static void Change(string state)
  // {
  //   switch (state)
  //   {
  //     case "start":
  //       Start();
  //       break;
  //     case "menu":
  //       Menu menu = new Menu();
  //       menu.menu();
  //       break;
  //     case "end":
  //       Quit();
  //       break;
  //     default:
  //       break;
  //   }
  // }

  // create a virtual Menu method that will be overridden by the Menu class
  public virtual void menu()
  {
    // do nothing
  }
  public virtual void Game()
  {
    // do nothing
  }
  public virtual void Quit()
  {
    // do nothing
  }

}

// create a Menu class that overrides the Menu method in the GameState class
class Menu : GameState
{
  public override void menu()
  {
    // create a new window
    var top = Application.Top;
    // add a new label to the window
    top.Add(new Label("Hello World!") { X = 0, Y = 0 });
    // add a new button to the window
    top.Add(new Button("Start") { X = 0, Y = 1 });
    // add a new button to the window
    top.Add(new Button("Quit") { X = 0, Y = 2 });
    // call the Application.Run method to start the game
    Application.Run();
  }
}
