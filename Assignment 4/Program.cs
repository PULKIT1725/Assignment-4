using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Assignment_4.Program;

namespace Assignment_4
{
    internal class Program
    {
        public class Bankaccount
        {
            public string Accountholder { get; private set; }
            private decimal amount;

            public Bankaccount(string accountholder, decimal intialbalance = 0)
            {
                Accountholder = accountholder;
                amount = intialbalance;
            }

            public void Deposit(decimal amount)
            {
                if (amount <= 0)
                {
                    throw new ArgumentException("Deposit amount must be positive");
                }
                amount += amount;
                Console.WriteLine($"Deposited: {amount:C}. New balance: {amount:C}");
            }

            public void Withdraw(decimal amount)
            {
                if (amount <= 0)
                {
                    throw new ArgumentException("withdrawl amount must be positive");
                }


                amount -= amount;
                Console.WriteLine($"Withdrawed: {amount:C}. New Balance: {amount:C}");
            }


            public decimal GetBalance()
            {
                return amount;
            }
            static void Main(string[] args)
            {
                Bankaccount account = new Bankaccount("John Doe", 1000);

                account.Deposit(500);
                try
                {
                    account.Withdraw(2000); // This will throw an exception
                }
                catch (InvalidOperationException ex)
                {
                    Console.WriteLine(ex.Message);
                }

                Console.WriteLine($"Final balance: {account.GetBalance():C}");
            }
        }
    }
}

//question 2
class StudentGradeCalculator
    {
        static void Main()
        {
            const int numberOfSubjects = 5;
            int[] marks = new int[numberOfSubjects];
            int totalMarks = 0;
            double average;

            Console.WriteLine("Enter marks for five subjects (0-100):");

            for (int i = 0; i < numberOfSubjects; i++)
            {
                while (true)
                {
                    try
                    {
                        Console.Write($"Subject {i + 1}: ");
                        marks[i] = int.Parse(Console.ReadLine());

                        if (marks[i] < 0 || marks[i] > 100)
                        {
                            throw new ArgumentOutOfRangeException("Marks should be between 0 and 100.");
                        }

                        totalMarks += marks[i];
                        break;
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Invalid input. Please enter a valid integer.");
                    }
                    catch (ArgumentOutOfRangeException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }

            average = totalMarks / (double)numberOfSubjects;
            Console.WriteLine($"\nAverage Marks: {average:F2}");

            // Determine grade based on the average
            string grade;
            if (average >= 90)
                grade = "A";
            else if (average >= 80)
                grade = "B";
            else if (average >= 70)
                grade = "C";
            else if (average >= 60)
                grade = "D";
            else if (average >= 50)
                grade = "E";
            else
                grade = "F";

            Console.WriteLine($"Grade: {grade}");
        }
}

//question 3

class TemperatureConverter
{
    private double celsius;
    private double fahrenheit;

    public double Celsius
    {
        get { return celsius; }
        set
        {
            celsius = value;
            fahrenheit = (celsius * 9 / 5) + 32;  // Automatically update Fahrenheit
        }
    }

    public double Fahrenheit
    {
        get { return fahrenheit; }
        set
        {
            fahrenheit = value;
            celsius = (fahrenheit - 32) * 5 / 9;  // Automatically update Celsius
        }
    }

    public void ConvertTemperature()
    {
        Console.WriteLine("\nSelect conversion type:");
        Console.WriteLine("1. Celsius to Fahrenheit");
        Console.WriteLine("2. Fahrenheit to Celsius");
        Console.Write("Enter choice (1 or 2): ");

        int choice;
        while (!int.TryParse(Console.ReadLine(), out choice) || (choice != 1 && choice != 2))
        {
            Console.WriteLine("Invalid choice. Please enter 1 or 2.");
            Console.Write("Enter choice (1 or 2): ");
        }

        switch (choice)
        {
            case 1:
                Console.Write("Enter temperature in Celsius: ");
                while (!double.TryParse(Console.ReadLine(), out celsius))
                {
                    Console.WriteLine("Invalid input. Please enter a valid number.");
                    Console.Write("Enter temperature in Celsius: ");
                }
                Celsius = celsius;
                Console.WriteLine($"Temperature in Fahrenheit: {Fahrenheit:F2} °F");
                break;

            case 2:
                Console.Write("Enter temperature in Fahrenheit: ");
                while (!double.TryParse(Console.ReadLine(), out fahrenheit))
                {
                    Console.WriteLine("Invalid input. Please enter a valid number.");
                    Console.Write("Enter temperature in Fahrenheit: ");
                }
                Fahrenheit = fahrenheit;
                Console.WriteLine($"Temperature in Celsius: {Celsius:F2} °C");
                break;
        }
    }
}

class Program
{
    static void Main()
    {
        TemperatureConverter converter = new TemperatureConverter();

        Console.WriteLine("Temperature Conversion Program");

        while (true)
        {
            converter.ConvertTemperature();

            Console.Write("\nDo you want to perform another conversion? (y/n): ");
            string choice = Console.ReadLine().ToLower();
            if (choice != "y")
            {
                Console.WriteLine("Exiting program. Goodbye!");
                break;
            }
        }
    }
}


//question 4



class Employee
{
    // Properties
    public string Name { get; set; }
    private int age;
    private decimal salary;
    public string Department { get; set; }

    // Property for Age with validation
    public int Age
    {
        get { return age; }
        set
        {
            if (value <= 0)
                throw new ArgumentException("Age must be a positive value.");
            age = value;
        }
    }

    // Private property for Salary
    private decimal Salary
    {
        get { return salary; }
        set
        {
            if (value < 0)
                throw new ArgumentException("Salary cannot be negative.");
            salary = value;
        }
    }

    // Constructor to initialize employee details
    public Employee(string name, int age, decimal salary, string department)
    {
        Name = name;
        Age = age;
        Salary = salary;
        Department = department;
    }

    // Method to display employee information
    public void DisplayEmployeeInfo()
    {
        Console.WriteLine("Employee Information:");
        Console.WriteLine($"Name: {Name}");
        Console.WriteLine($"Age: {Age}");
        Console.WriteLine($"Department: {Department}");
        Console.WriteLine($"Salary: {GetSalary()}");  // Access salary via a method for controlled access
    }

    // Method to retrieve the salary in a controlled manner
    public decimal GetSalary()
    {
        return Salary;
    }
}

class program
{
    static void Main()
    {
        try
        {
            Console.WriteLine("Enter Employee Details:");

            Console.Write("Name: ");
            string name = Console.ReadLine();

            Console.Write("Age: ");
            int age = int.Parse(Console.ReadLine());

            Console.Write("Salary: ");
            decimal salary = decimal.Parse(Console.ReadLine());

            Console.Write("Department: ");
            string department = Console.ReadLine();

            // Creating Employee object
            Employee employee = new Employee(name, age, salary, department);

            // Displaying Employee Information
            employee.DisplayEmployeeInfo();
        }
        catch (FormatException)
        {
            Console.WriteLine("Invalid input format. Please enter the correct data type for each field.");
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}

//question 5



class SimpleCalculator
{
    static void Main()
    {
        Console.WriteLine("Simple Calculator");

        try
        {
            // Prompt the user for two numbers
            Console.Write("Enter the first number: ");
            double number1 = double.Parse(Console.ReadLine());

            Console.Write("Enter the second number: ");
            double number2 = double.Parse(Console.ReadLine());

            // Prompt the user for the desired operation
            Console.WriteLine("Select an operation (+, -, *, /): ");
            char operation = Console.ReadLine()[0];

            double result = 0;

            // Perform the operation using switch case
            switch (operation)
            {
                case '+':
                    result = number1 + number2;
                    break;

                case '-':
                    result = number1 - number2;
                    break;

                case '*':
                    result = number1 * number2;
                    break;

                case '/':
                    if (number2 == 0)
                    {
                        throw new DivideByZeroException("Division by zero is not allowed.");
                    }
                    result = number1 / number2;
                    break;

                default:
                    Console.WriteLine("Invalid operation. Please select +, -, *, or /.");
                    return;
            }

            Console.WriteLine($"Result: {number1} {operation} {number2} = {result}");
        }
        catch (FormatException)
        {
            Console.WriteLine("Invalid input. Please enter valid numbers.");
        }
        catch (DivideByZeroException ex)
        {
            Console.WriteLine(ex.Message);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An unexpected error occurred: {ex.Message}");
        }
    }
}


//question 6

class Book
{
    // Properties for the book details
    public string Title { get; set; }
    public string Author { get; set; }
    public string ISBN { get; set; }
    private int copiesAvailable;

    public int CopiesAvailable
    {
        get { return copiesAvailable; }
        private set
        {
            if (value < 0)
                throw new InvalidOperationException("Copies available cannot be negative.");
            copiesAvailable = value;
        }
    }

    // Constructor to initialize book details
    public Book(string title, string author, string isbn, int copiesAvailable)
    {
        Title = title;
        Author = author;
        ISBN = isbn;
        CopiesAvailable = copiesAvailable;
    }

    // Method to issue a book
    public void IssueBook()
    {
        if (CopiesAvailable > 0)
        {
            CopiesAvailable--;
            Console.WriteLine($"Book '{Title}' issued successfully. Copies left: {CopiesAvailable}");
        }
        else
        {
            throw new InvalidOperationException("No copies available to issue.");
        }
    }

    // Method to return a book
    public void ReturnBook()
    {
        CopiesAvailable++;
        Console.WriteLine($"Book '{Title}' returned successfully. Copies available: {CopiesAvailable}");
    }

    // Display book information
    public void DisplayBookInfo()
    {
        Console.WriteLine($"Title: {Title}, Author: {Author}, ISBN: {ISBN}, Copies Available: {CopiesAvailable}");
    }
}

class program1
{
    static void Main()
    {
        // Sample book for the library system
        Book book = new Book("The Great Gatsby", "F. Scott Fitzgerald", "978-0743273565", 3);

        Console.WriteLine("Welcome to the Library Management System\n");
        book.DisplayBookInfo();

        while (true)
        {
            Console.WriteLine("\nSelect an action:");
            Console.WriteLine("1. Issue Book");
            Console.WriteLine("2. Return Book");
            Console.WriteLine("3. Exit");
            Console.Write("Enter your choice (1-3): ");

            string choice = Console.ReadLine();

            try
            {
                switch (choice)
                {
                    case "1":
                        book.IssueBook();
                        break;

                    case "2":
                        book.ReturnBook();
                        break;

                    case "3":
                        Console.WriteLine("Exiting the Library Management System. Goodbye!");
                        return;

                    default:
                        Console.WriteLine("Invalid choice. Please select a valid option.");
                        break;
                }
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

            book.DisplayBookInfo();  // Display updated book information after each transaction
        }
    }
}


//question 7

class PrimeNumberChecker
{
    static void Main()
    {
        int number;

        // Accept user input with validation for positive integers
        while (true)
        {
            Console.Write("Enter a positive integer to check if it is prime: ");
            if (int.TryParse(Console.ReadLine(), out number) && number > 0)
            {
                break;
            }
            Console.WriteLine("Invalid input. Please enter a positive integer.");
        }

        // Check if the number is prime
        if (IsPrime(number))
        {
            Console.WriteLine($"{number} is a prime number.");
        }
        else
        {
            Console.WriteLine($"{number} is not a prime number.");
        }
    }

    // Method to check if a number is prime
    static bool IsPrime(int num)
    {
        // Handle special cases for numbers less than 2
        if (num < 2) return false;

        // Check for factors from 2 to sqrt(num)
        for (int i = 2; i <= Math.Sqrt(num); i++)
        {
            if (num % i == 0)
            {
                return false;  // If a factor is found, it's not prime
            }
        }

        return true;  // No factors found, it is prime
    }
}

//question 8

class Car
{
    // Properties
    public string Model { get; set; }
    public decimal DailyRate { get; set; }
    public bool IsAvailable { get; private set; }

    // Constructor to initialize car details
    public Car(string model, decimal dailyRate)
    {
        Model = model;
        DailyRate = dailyRate;
        IsAvailable = true; // Set car as available initially
    }

    // Method to rent the car
    public void RentCar(int days)
    {
        if (!IsAvailable)
        {
            throw new InvalidOperationException("Car is currently unavailable for rent.");
        }
        if (days <= 0)
        {
            throw new ArgumentException("Number of rental days must be positive.");
        }

        // Calculate total cost
        decimal totalCost = CalculateTotalCost(days);
        IsAvailable = false;  // Mark car as unavailable after rental
        Console.WriteLine($"Car '{Model}' rented for {days} days. Total cost: ${totalCost:F2}");
    }

    // Method to calculate the total cost of rental
    public decimal CalculateTotalCost(int days)
    {
        return days * DailyRate;
    }

    // Method to return the car
    public void ReturnCar()
    {
        IsAvailable = true; // Mark car as available after return
        Console.WriteLine($"Car '{Model}' has been returned and is now available for rent.");
    }

    // Method to display car information
    public void DisplayCarInfo()
    {
        Console.WriteLine($"Model: {Model}, Daily Rate: ${DailyRate:F2}, Available: {IsAvailable}");
    }
}

class program2
{
    static void Main()
    {
        // Create a sample car
        Car car = new Car("Toyota Corolla", 50.00m);

        Console.WriteLine("Welcome to the Car Rental System\n");
        car.DisplayCarInfo();

        while (true)
        {
            Console.WriteLine("\nSelect an action:");
            Console.WriteLine("1. Rent Car");
            Console.WriteLine("2. Return Car");
            Console.WriteLine("3. Exit");
            Console.Write("Enter your choice (1-3): ");

            string choice = Console.ReadLine();

            try
            {
                switch (choice)
                {
                    case "1":
                        if (!car.IsAvailable)
                        {
                            Console.WriteLine("Car is already rented out.");
                            break;
                        }

                        Console.Write("Enter number of rental days: ");
                        int days = int.Parse(Console.ReadLine());

                        car.RentCar(days);
                        break;

                    case "2":
                        if (car.IsAvailable)
                        {
                            Console.WriteLine("Car is already available. No need to return.");
                        }
                        else
                        {
                            car.ReturnCar();
                        }
                        break;

                    case "3":
                        Console.WriteLine("Exiting the Car Rental System. Goodbye!");
                        return;

                    default:
                        Console.WriteLine("Invalid choice. Please select a valid option.");
                        break;
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid input. Please enter a numeric value for days.");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine(ex.Message);
            }

            car.DisplayCarInfo();  // Display updated car information after each transaction
        }
    }
}


//question 9


class Order
{
    // Properties
    public int OrderID { get; private set; }
    public string CustomerName { get; set; }
    public decimal Amount { get; private set; }
    private string orderStatus;

    public string OrderStatus
    {
        get { return orderStatus; }
        private set
        {
            if (value == "Placed" || value == "Shipped" || value == "Delivered" || value == "Canceled")
            {
                orderStatus = value;
            }
            else
            {
                throw new ArgumentException("Invalid order status.");
            }
        }
    }

    // Constructor to initialize order details
    public Order(int orderId, string customerName, decimal amount)
    {
        OrderID = orderId;
        CustomerName = customerName;
        Amount = amount;
        OrderStatus = "Placed";  // Default status when an order is created
    }

    // Method to update order status
    public void UpdateOrderStatus(string newStatus)
    {
        switch (newStatus)
        {
            case "Placed":
            case "Shipped":
            case "Delivered":
            case "Canceled":
                OrderStatus = newStatus;
                Console.WriteLine($"Order status updated to '{newStatus}'.");
                break;

            default:
                Console.WriteLine("Invalid status. Valid statuses are: Placed, Shipped, Delivered, Canceled.");
                break;
        }
    }

    // Method to display order details
    public void DisplayOrderDetails()
    {
        Console.WriteLine($"\nOrder Details:\nOrder ID: {OrderID}\nCustomer Name: {CustomerName}\nAmount: ${Amount:F2}\nStatus: {OrderStatus}");
    }
}

class program3
{
    static void Main()
    {
        // Create a sample order
        Order order = new Order(1001, "John Doe", 150.75m);

        Console.WriteLine("E-commerce Order Management System\n");

        while (true)
        {
            order.DisplayOrderDetails();

            Console.WriteLine("\nSelect an action:");
            Console.WriteLine("1. Update Order Status");
            Console.WriteLine("2. Exit");
            Console.Write("Enter your choice (1-2): ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.Write("Enter new order status (Placed, Shipped, Delivered, Canceled): ");
                    string newStatus = Console.ReadLine();
                    order.UpdateOrderStatus(newStatus);
                    break;

                case "2":
                    Console.WriteLine("Exiting the Order Management System. Goodbye!");
                    return;

                default:
                    Console.WriteLine("Invalid choice. Please select a valid option.");
                    break;
            }
        }
    }
}


//question 10



class MovieTicket
{
    // Properties
    public string MovieName { get; private set; }
    public DateTime ShowTime { get; private set; }
    public int SeatNumber { get; private set; }
    public decimal TicketPrice { get; private set; }
    public bool IsBooked { get; private set; }

    // Constructor to initialize ticket details
    public MovieTicket(string movieName, DateTime showTime, int seatNumber, decimal ticketPrice)
    {
        MovieName = movieName;
        ShowTime = showTime;
        SeatNumber = seatNumber;
        TicketPrice = ticketPrice;
        IsBooked = false; // Initial status is unbooked
    }

    // Method to book a ticket
    public void BookTicket()
    {
        if (IsBooked)
        {
            throw new InvalidOperationException("This seat is already booked.");
        }

        IsBooked = true;
        decimal finalPrice = ApplyDiscount(TicketPrice);
        Console.WriteLine($"Ticket booked successfully for '{MovieName}' at {ShowTime}.\nSeat: {SeatNumber}, Price after discount: ${finalPrice:F2}");
    }

    // Method to apply a discount
    private decimal ApplyDiscount(decimal price)
    {
        if (price > 100)
        {
            Console.WriteLine("Applying a 10% discount for tickets over $100.");
            return price * 0.90m; // 10% discount
        }
        else
        {
            return price;
        }
    }

    // Method to display ticket details
    public void DisplayTicketDetails()
    {
        Console.WriteLine($"\nTicket Details:\nMovie: {MovieName}\nShow Time: {ShowTime}\nSeat Number: {SeatNumber}\nPrice: ${TicketPrice:F2}\nStatus: {(IsBooked ? "Booked" : "Available")}");
    }
}

class program4
{
    static void Main()
    {
        // Create a sample movie ticket
        MovieTicket ticket = new MovieTicket("Inception", DateTime.Parse("2024-11-12 19:00"), 10, 120.00m);

        Console.WriteLine("Welcome to the Movie Ticket Booking System\n");

        while (true)
        {
            ticket.DisplayTicketDetails();

            Console.WriteLine("\nSelect an action:");
            Console.WriteLine("1. Book Ticket");
            Console.WriteLine("2. Exit");
            Console.Write("Enter your choice (1-2): ");

            string choice = Console.ReadLine();

            try
            {
                switch (choice)
                {
                    case "1":
                        ticket.BookTicket();
                        break;

                    case "2":
                        Console.WriteLine("Exiting the Ticket Booking System. Goodbye!");
                        return;

                    default:
                        Console.WriteLine("Invalid choice. Please select a valid option.");
                        break;
                }
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine(ex.Message);
            }

            ticket.DisplayTicketDetails(); // Show updated ticket details
        }
    }
}
