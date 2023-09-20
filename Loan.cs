class Loan
{
  public const int INITIAL_LOAN_AMOUNT = 2_000;
  public const double INTEREST_RATE = 0.12;
  public const int DAYS_REMAINING = 30; 
  public const double MAX_INTEREST = 0.99;

  public int LoanAmount { get; set; } = INITIAL_LOAN_AMOUNT;
  public double InterestRate { get; set; } = INTEREST_RATE;
  public int loanRepaymentDays { get; set; } = DAYS_REMAINING;
  public int loanPaymentAmount { get; set; } 
  public string loanSharkName { get; set; } = "Murph";
  public int currentCredits;
  public bool loanPaid;
  public int loansTaken;
  // public bool loanLoss;

  
  public bool checkLoanPaid() 
  {
    if(LoanAmount == 0)
    {
      loanPaid = true;
      // loansTaken -=1;
    }
    else
    {
      loanPaid = false;
    }
    return loanPaid;
  }

  public void makePayment(int payment)
  {
    LoanAmount -= payment;
  }

  public int updateLoan()
  {
    return LoanAmount;
  }

  public void repaymentDate()
  {
    // if (loanRepaymentDays <1)
    // {
    //   loanLoss = true;
    //   Console.WriteLine($"{loanSharkName} sent a bookey to take you to debtor's prison. You lose.");
    // }
    loanRepaymentDays -= 1;
  }
  public void applyInterest()
  {
    LoanAmount += (int)(LoanAmount * InterestRate);
  }

  public double getInterestRate()
  {
    double x = 0;
    for (int i = 0; i < loansTaken; i++)
    {
      x = InterestRate + InterestRate;
    }
    InterestRate = x;
    return x;
  }

  public void setInterestRate()
  {
    double x = Prompt.validDoubleEntry(MAX_INTEREST);
    InterestRate = x;
  }

  public int currentAmount()
  {
    return (int)Math.Round(LoanAmount * InterestRate / DAYS_REMAINING);
  }
  
  public int getLoan()
  {
    
    if(loansTaken <1)
    {
      loansTaken +=1;
      Console.WriteLine($"You took your first loan at interest rate {InterestRate}%, good luck.");
      currentCredits = INITIAL_LOAN_AMOUNT;
      Console.ReadLine();
      return INITIAL_LOAN_AMOUNT;
    }
    else
    {
      loansTaken +=1;
      LoanAmount += loanPaymentAmount;
      currentCredits += loanPaymentAmount;
      getInterestRate();
      Console.WriteLine($"Your interest rate increased with this loan to {InterestRate}%.");
      return loanPaymentAmount;
    }
    
  }

  public void interaction()
    {
        Console.Clear();
        if (Interface.menuLocation == 33)
        {
        Prompt.list($"{loanSharkName} here, what'll it be today?", "Loan Payment", "New Loan", "Go Back");
        var x = Console.ReadKey();
        switch (x.Key)
        {
            case ConsoleKey.D1:
                Console.Clear();
                Interface.menuLocationUpdate(34);
                break;
            case ConsoleKey.D2:
                Console.Clear();
                Interface.menuLocationUpdate(35);
                break;
            case ConsoleKey.D3:
                Interface.menuLocationUpdate(30);
                break;
        }
        }
        
        else if (Interface.menuLocation == 34)
        {
          Console.WriteLine($"You can make a payment between 0 - ${LoanAmount}.");
          loanPaymentAmount = Prompt.validEntry(LoanAmount);
          Console.WriteLine($"You are about to pay {loanPaymentAmount}. Type Y to confirm, N to cancel.");
          var x = Console.ReadKey();
        switch (x.Key)
        {
            case ConsoleKey.Y:
                Console.Clear();
                makePayment(loanPaymentAmount);
                Console.WriteLine($"Thanks for your payment. You owe: ${LoanAmount}. Press a key to continue.");
                Console.ReadKey();
                Interface.menuLocationUpdate(30);
                break;
            case ConsoleKey.N:
                Console.Clear();
                Interface.menuLocationUpdate(30);
                break;
        }
        }
        else if (Interface.menuLocation == 35)
        {
          Console.WriteLine($"You can take a new loan between 0 - ${INITIAL_LOAN_AMOUNT}.");
          Console.ReadKey();
          loanPaymentAmount = Prompt.validEntry(INITIAL_LOAN_AMOUNT);
          double z = InterestRate + InterestRate;
          Console.WriteLine($"This loan of {loanPaymentAmount} will increase your interest rate to {z}. Type Y to confirm, N to cancel.");
          var x = Console.ReadKey();
        switch (x.Key)
        {
            case ConsoleKey.Y:
                Console.Clear();
                getLoan();
                // updateLoan();
                Console.WriteLine($"You owe: ${LoanAmount}. Press a key to continue.");
                Console.ReadKey();
                Interface.menuLocationUpdate(30);
                break;
            case ConsoleKey.N:
                Console.Clear();
                Interface.menuLocationUpdate(30);
                break;
        }
        }
  }
}