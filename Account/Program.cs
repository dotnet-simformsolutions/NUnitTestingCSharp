using Account; // Import the Account namespace

BankAccount account; // Declare a BankAccount object

// Read user input for account name, opening balance, and overdraft limit
Console.WriteLine("Enter Account Name");
string name = Console.ReadLine();
Console.WriteLine("Enter Opening Balance");
decimal balance = Convert.ToDecimal(Console.ReadLine());
Console.WriteLine("Enter Overdraft Limit");

// Initialize the BankAccount object with the provided values
account = new BankAccount(name, balance);

// Call the DisplayChoices function to start the interaction
DisplayChoices();

// Display the menu options and handle user input
void DisplayChoices()
{
    Console.WriteLine("1. Deposit Amount");
    Console.WriteLine("2. Withdraw Amount");
    Console.WriteLine("3. Display Balance");
    Console.WriteLine("4. Exit");
    Console.WriteLine("Enter Your choice");

    int choice = Convert.ToInt32(Console.ReadLine());

    // Based on the user's choice, perform the respective action
    if (choice == 1)
    {
        DepositAmount();
    }
    else if (choice == 2)
    {
        WithdrawAmount();
        Console.WriteLine("Amount Withdrawn Successfully");
    }
    else if (choice == 3)
    {
        Console.WriteLine($"Your Balance is {account.GetBalance()}");
    }
    else if (choice == 4)
    {
        Environment.Exit(0);
    }
    else
    {
        Console.WriteLine("Invalid choice. Please select a valid option.");
    }

    // Repeat the process by calling DisplayChoices again
    DisplayChoices();
}

// Deposit money into the account
void DepositAmount()
{
    Console.WriteLine("Please Enter Amount");
    decimal amount = Convert.ToDecimal(Console.ReadLine());
    account.Deposit(amount);
    Console.WriteLine($"Amount Deposited Successfully. New Balance is {account.GetBalance()}");
}

// Withdraw money from the account
void WithdrawAmount()
{
    Console.WriteLine("Please Enter Amount");
    decimal amount = Convert.ToDecimal(Console.ReadLine());
    var result = account.Withdraw(amount);

    if (result)
    {
        Console.WriteLine($"Amount withdrawn successfully. New balance is {account.GetBalance()}");
    }
    else
    {
        Console.WriteLine("Requested Amount is greater than overdraft limit");
    }
}
