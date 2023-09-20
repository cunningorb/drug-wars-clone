/* using Terminal.Gui;

class View
{
  public static void Menu () {
    Application.Init ();

    
    var win = new Window ("T A M A  T R A D E R") {
      X = 0,
      Y = 1,
      Width = Dim.Fill (),
      Height = Dim.Fill () - 1
    };

    // define global key handling logic for your entire application that is invoked regardless of what Window/View has focus. This can be achieved by using the Application.RootKeyEvent event
    Application.Top.KeyEvent += (o, e) => {
      if (e.Key == Key.Esc) {
        Application.RequestStop ();
      }
    };

    Application.Top.Add (win);
    Application.Run ();
    Application.Shutdown ();
  }
} */