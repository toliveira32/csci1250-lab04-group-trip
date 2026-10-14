/*
* Name: Tiago Miguel Lourenço Vedes de Oliveira
* Course: CSCI 1250, Section 001
* Assignment: Lab 4, The Group Trip
* Date: October 7, 2026
* Description: Rebuilds the trip calculator with methods and arrays so it
* reports on a whole group instead of one person.
*/

//Part 1: Ask the user for his information about his trip. How many miles he did on his trip, the price per gallon of his veichile and how much he paid
// Requests the user as well for numbers of pizza bought and their cost to make the calculation of the total price of the trip

//Constants (Im still confused if this is what you Professor meant that we should change TAX_RATE constant name to taxRate to match the professor example, i hope im doing it right)
const int numberOfSlicesPerPizza = 8;
const double taxRate = 0.18;

Console.WriteLine("\n=== Part 1: The Trip ===");
//Requesting the user for the trip information
Console.Write("How many miles is your Trip? ");
double miles = Convert.ToDouble(Console.ReadLine());

Console.Write("How much Miles per Gallon does your car use? ");
double milesPerGallon = Convert.ToDouble(Console.ReadLine());

Console.Write("Whats the price per Gallon you paid? ");
double pricePerGallon = Convert.ToDouble(Console.ReadLine());

Console.Write("How many Pizzas were bought for the Party? ");
int numberOfPizzasBought = Convert.ToInt32(Console.ReadLine());

Console.Write("How much is the cost of each Pizza? ");
double pricePerPizza = Convert.ToDouble(Console.ReadLine());

//variables for trip calculations
double fuelCost = FuelCost(miles, milesPerGallon, pricePerGallon);
double pizzaCost = numberOfPizzasBought * pricePerPizza;
double tripTotal = fuelCost + pizzaCost;

//displaying it to the user
Console.WriteLine("Fuel cost: " + fuelCost.ToString("C"));
Console.WriteLine("Pizza cost: " + pizzaCost.ToString("C"));
Console.WriteLine("Trip total: " + tripTotal.ToString("C"));

//Part 2: Putting the group in an array and doing more calculations for the trip: like how many people are going, the cost for each person individually and how many slices each person is having
Console.WriteLine("\n=== Part 2: The Group ===");

//arrays with the group name and work information
string[] names = { "Ada", "Grace", "Alan", "Katherine" };
double[] hoursWorked = { 22, 15, 30, 18 };
double[] hourlyRates = { 13.50, 16.00, 11.20, 14.80 };

//variables for trip information (Hello Professor, i keep on thinking if i should stack all the variables together or if i should keep separating them for each part like i have been doing)
int peopleGoing = names.Length;
double totalSlices = numberOfPizzasBought * numberOfSlicesPerPizza;
double slicesEach = totalSlices / names.Length;
double costPerPerson = tripTotal / names.Length;

//displaying the more trip information to the user
Console.WriteLine("People going: " + peopleGoing);
Console.WriteLine("Slices each: " + slicesEach.ToString("F1"));
Console.WriteLine("Cost per person: " + costPerPerson.ToString("C"));

//Part 3: Calculations about the individual and total hours worked from everyone as well as total and invidvidual take home pay, the report of work needed
Console.WriteLine("\n=== Part 3: Who Works How Long ===");

//varibales for the information about how much people work and how much they actually get back home after taxes
double totalHours = 0;
double totalTakeHome = 0;
double longest = 0;

// for loop to get the values of each person and displaying it to the user to see how long everyone works and how long everyone needs to work to cover ammount owed as well as total 
for (int i = 0; i < names.Length; i++)
{
    double takeHome = TakeHomePay(hoursWorked[i], hourlyRates[i], taxRate);
    double takeHomePerHour = takeHome / hoursWorked[i];
    double hoursNeeded = HoursToCover(costPerPerson, takeHomePerHour);

    totalHours += hoursWorked[i];
    totalTakeHome += takeHome;
    longest = Math.Max(longest, hoursNeeded);
//(Hello again professor, i kept trying to do this using interpolation with the $ but i couldnt get the toString convertion to work, whats the better and cleaner way of doing this?)
    Console.WriteLine(names[i] + ": takes home " + takeHome.ToString("C") + " for " + hoursWorked[i].ToString("F0") + " hours, " + takeHomePerHour.ToString("C") + " per hour, must work " + hoursNeeded.ToString("F2") + " hours");
}
//displaying the information to the user about total time worked, total take home pay and the longest anyone needs to work
Console.WriteLine("\nTotal hours worked: " + totalHours.ToString("F0"));
Console.WriteLine("Total take home pay: " + totalTakeHome.ToString("C"));
Console.WriteLine("Longest anyone must work: " + longest.ToString("F2"));

//Methods

//calculates the cost of the fuel for the trip, and returns the total fuel cost money based on how many miles travelled and the respective price of miles per galon
static double FuelCost(double miles, double milesPerGallon, double pricePerGallon)
{
    double gallonsNeeded = miles / milesPerGallon;
    return gallonsNeeded * pricePerGallon;
}
//calculates total money brought home after removing taxes, returns that respective ammount of money taken home after taxes based on hours worked, how much paid per hour and value of tax rate
static double TakeHomePay(double hours, double hourlyRate, double taxRate)
{
    double grossPay = hours * hourlyRate;
    double taxWithheld = grossPay * taxRate;
    return grossPay - taxWithheld;
}
//calculates how many hours of work are needed to pay for an certain amount of money owed, returns numbers of hours of work needed for the respective amount owed based on take home payment per hour and how much is the value owed
static double HoursToCover(double amountOwed, double takeHomePerHour)
{
    return amountOwed / takeHomePerHour;
}




/*System.Console.WriteLine("=== Part 1: Road Trip ===");

Console.Write("How many miles is your Trip? ");
int roundTripMiles = Convert.ToInt32(Console.ReadLine());

System.Console.Write("How much Miles per Gallon does your car use? ");
double milePerGallon = Convert.ToDouble(Console.ReadLine());

System.Console.Write("Whats the price per Gallon you paid? ");
double pricePerGallon = Convert.ToDouble(Console.ReadLine());

double gallonsNeeded = roundTripMiles / milePerGallon;

double fuelCost = gallonsNeeded * pricePerGallon;

System.Console.WriteLine("Gallons needed: " + gallonsNeeded.ToString("F2"));
System.Console.WriteLine("Fuel cost: " + fuelCost.ToString("C"));

//Part 2: Asking the user Questions about a Pizza Party: asking for number of people attending party, how much pizza ate to give information about number of slices and total slicer per person and cost per price.
System.Console.WriteLine("=== Part 2: Pizza Party ===");

System.Console.Write("How many people are going to the Pizza Pary? ");
int numberOfPeopleAttendingParty = Convert.ToInt32(Console.ReadLine());

System.Console.Write("How many Pizzas were bought for the Party? ");
int numberOfPizzasBought = Convert.ToInt32(Console.ReadLine());

System.Console.Write("How much is the cost of each Pizza? ");
double pricePerPizza = Convert.ToDouble(Console.ReadLine());

double totalSlices = numberOfPizzasBought * numberOfSlicesPerPizza;

double slicesPerPerson = totalSlices / numberOfPeopleAttendingParty;

double pizzaCost = numberOfPizzasBought * pricePerPizza;

System.Console.WriteLine("Total Slices: " + totalSlices.ToString("F2"));
System.Console.WriteLine("Slices per Person: " + slicesPerPerson.ToString("F2"));
System.Console.WriteLine("Pizza Cost: " + pizzaCost.ToString("C"));

//Part 3: Paycheck Calculator: Having Taxes into account, calculate paycheck based on hours worked weekly
System.Console.WriteLine("=== Part 3: Paycheck ===");

System.Console.Write("How many hours did you work this week? ");
double hoursWorkedWeekly = Convert.ToDouble(Console.ReadLine());

System.Console.Write("What is your hourly rate? ");
double hourlyRate = Convert.ToDouble(Console.ReadLine());

double grossPay = hoursWorkedWeekly * hourlyRate;

double taxWithheld = grossPay * TAX_RATE;

double takeHomePay = grossPay - taxWithheld;

System.Console.WriteLine("Gross Pay: " + grossPay.ToString("C"));
System.Console.WriteLine("Tax Withheld: " + taxWithheld.ToString("C"));
System.Console.WriteLine("Take Home Pay: " + takeHomePay.ToString("C"));

//Part 4: Doing the final calculations of the trip: Cost of the trip per person and how many hours of work needed to pay for said trip
System.Console.WriteLine("=== Part 4: The Whole Trip ===");

double tripTotal = fuelCost + pizzaCost;

double costPerPerson = tripTotal / numberOfPeopleAttendingParty;

double takeHomePayPerHour = takeHomePay / hoursWorkedWeekly;

double hoursNeededWorking = costPerPerson / takeHomePayPerHour;

System.Console.WriteLine("Trip Total: " + tripTotal.ToString("C"));
System.Console.WriteLine("Cost Per Person: " + costPerPerson.ToString("C"));
System.Console.WriteLine("Take home pay per hour: " + takeHomePayPerHour.ToString("C"));
System.Console.WriteLine("Hours you must work to cover your share: " + hoursNeededWorking.ToString("F2"));

*/