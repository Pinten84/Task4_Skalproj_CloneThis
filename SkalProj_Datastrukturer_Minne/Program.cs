using System;
using System.Diagnostics.Metrics;
using System.Reflection;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SkalProj_Datastrukturer_Minne
{
    class Program
    {
        /// <summary>
        /// The main method, vill handle the menues for the program
        /// </summary>
        /// <param name="args"></param>
        static void Main()
        {

            while (true)
            {
                Console.WriteLine("Please navigate through the menu by inputting the number \n(1, 2, 3 ,4, 0) of your choice"
                    + "\n1. Examine a List"
                    + "\n2. Examine a Queue"
                    + "\n3. Examine a Stack"
                    + "\n4. CheckParenthesis"
                    + "\n0. Exit the application");
                char input = ' '; //Creates the character input to be used with the switch-case below.
                try
                {
                    input = Console.ReadLine()![0]; //Tries to set input to the first char in an input line
                }
                catch (IndexOutOfRangeException) //If the input line is empty, we ask the users for some input.
                {
                    Console.Clear();
                    Console.WriteLine("Please enter some input!");
                }
                switch (input)
                {
                    case '1':
                        ExamineList();
                        break;
                    case '2':
                        ExamineQueue();
                        break;
                    case '3':
                        ExamineStack();
                        break;
                    case '4':
                        CheckParanthesis();
                        break;
                    /*
                     * Extend the menu to include the recursive 
                     * and iterative exercises.
                     */
                    case '0':
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Please enter some valid input (0, 1, 2, 3, 4)");
                        break;
                }
            }
        }

        /// <summary>
        /// Examines the datastructure List
        /// </summary>

        /*
         * Loop this method untill the user inputs something to exit to main menue.
         * Create a switch statement with cases '+' and '-'
         * '+': Add the rest of the input to the list (The user could write +Adam and "Adam" would be added to the list)
         * '-': Remove the rest of the input from the list (The user could write -Adam and "Adam" would be removed from the list)
         * In both cases, look at the count and capacity of the list
         * As a default case, tell them to use only + or -
         * Below you can see some inspirational code to begin working.
        */

        //List<string> theList = new List<string>();
        //string input = Console.ReadLine();
        //char nav = input[0];
        //string value = input.substring(1);

        //switch(nav){...}

        static void ExamineList()
        {
            List<string> myList = new List<string>(); // Lista att testa med
            bool stayHere = true; // Stanna i loopen

            while (stayHere)
            {
                Console.WriteLine("\nUse +<name> to add, - to remove, or x to exit to main menu");
                Console.WriteLine($"Antal: {myList.Count}, Kapacitet: {myList.Capacity}"); // Visa vad som händer
                string ?userInput = Console.ReadLine(); // Input från användaren

                if (userInput != null && userInput.Length > 0) // Kolla så det inte är tomt
                {
                    char action = userInput[0]; // Första tecknet, + eller -
                    string value = userInput.Substring(1).Trim(); // Resten av texten

                    switch (action)
                    {
                        case '+':
                            myList.Add(value); // Lägg till i listan
                            Console.WriteLine($"Added {value}. Now there are {myList.Count} entries in the list, capacity: {myList.Capacity}");
                            // 2. När ökar kapaciteten? Den ökar när listan är full, alltså när antal = kapacitet.
                            // 3. Med hur mycket ökar den? Den dubblar sig ungefär, t.ex. från 4 till 8, sen 8 till 16.
                            //4. Varför ökar den inte i samma takt som element läggs till? För att det skulle ta för lång tid att ändra storlek varje gång, så det görs i "hopp" för att spara tid.
                            break;
                        case '-':
                            if (myList.Contains(value)) // Kolla om det finns
                            {
                                myList.Remove(value); // Ta bort
                                Console.WriteLine($"Removed {value}. Now there are {myList.Count} entries in the list, capacity: {myList.Capacity}");
                                // 5. Minskar kapaciteten när element tas bort? Nej, den minskar inte automatiskt, den håller kvar utrymmet.
                            }
                            else
                            {
                                Console.WriteLine($"{value} was not in the list.");
                            }
                            break;
                        case 'x':
                            stayHere = false; // Gå tillbaka till meny
                            break;
                        default:
                            Console.WriteLine("Only use + or - or x to go to main menu");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Wrong input");
                }
            }
            // 6. När är det fördelaktigt att använda en array istället för en lista? När jag vet exakt hur många saker jag behöver och inte vill ha onödigt utrymme, t.ex. en fast lista med 10 namn.
        }


        /// <summary>
        /// Examines the datastructure Queue
        /// </summary>
        static void ExamineQueue()
        {
            /*
             * Loop this method untill the user inputs something to exit to main menue.
             * Create a switch with cases to enqueue items or dequeue items
             * Make sure to look at the queue after Enqueueing and Dequeueing to see how it behaves
            */

            Queue<string> myQueue = new Queue<string>(); // Min kö för att testa
            bool keepGoing = true; // Håller loopen igång

            while (keepGoing)
            {
                Console.WriteLine("\nUse + to stand in line, - to move the que forward, or x to go to main manu");
                Console.WriteLine($"Number in line: {myQueue.Count}"); // Visa hur många som väntar
                string ?input = Console.ReadLine(); // Vad användaren skriver

                if (input != null && input.Length > 0)
                {
                    char choice = input[0]; // Första tecknet
                    string name = input.Substring(1).Trim(); // Namnet efter tecknet

                    switch (choice)
                    {
                        case '+':
                            myQueue.Enqueue(name); // Lägg till i kön
                            Console.WriteLine($"{name} just went into the que. Now queing {myQueue.Count} persons");
                            break;
                        case '-':
                            if (myQueue.Count > 0) // Kolla om kön inte är tom
                            {
                                string nextPerson = myQueue.Dequeue(); // Ta första i kön
                                Console.WriteLine($"{nextPerson} got expidited. Left in que: {myQueue.Count}");
                            }
                            else
                            {
                                Console.WriteLine("Noone in the que to expidite.");
                            }
                            break;
                        case 'x':
                            keepGoing = false; // Gå tillbaka till meny
                            break;
                        default:
                            Console.WriteLine("Use + or - or x to go to main menu");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Wrong input");
                }
            }
        }

        /// <summary>
        /// Examines the datastructure Stack
        /// </summary>
        static void ExamineStack()
        {
            /*
             * Loop this method until the user inputs something to exit to main menue.
             * Create a switch with cases to push or pop items
             * Make sure to look at the stack after pushing and and poping to see how it behaves
             */

            Stack<string> myStack = new Stack<string>(); // Skapar en ny stack för strängar
            bool keepGoing = true; // Sätter en flagga för att hålla loopen igång

            while (keepGoing)
            {
                Console.WriteLine("\nUse +<name> to push, - to pop, r to reverse text, or x to exit to main menu"); // Visa menyval
                Console.WriteLine($"Number in stack: {myStack.Count}"); // Visa hur många som är i stacken
                string? input = Console.ReadLine(); // Läs in vad användaren skriver

                if (!string.IsNullOrEmpty(input)) // Kolla så input inte är tom
                {
                    char action = input[0]; // Ta första tecknet som kommandot
                    string value = input.Length > 1 ? input.Substring(1).Trim() : ""; // Ta resten av texten om det finns

                    switch (action)
                    {
                        case '+':
                            myStack.Push(value); // Lägg till värdet högst upp i stacken
                            Console.WriteLine($"{value} pushed to stack. Stack size: {myStack.Count}"); // Bekräfta och visa storlek
                            break;
                        case '-':
                            if (myStack.Count > 0) // Se till att stacken inte är tom
                            {
                                string popped = myStack.Pop(); // Ta bort och spara det översta
                                Console.WriteLine($"{popped} popped from stack. Stack size: {myStack.Count}"); // Visa vad som togs bort
                            }
                            else
                            {
                                Console.WriteLine("Stack is empty."); // Meddela om stacken är tom
                            }
                            break;
                        case 'r':
                            ReverseText(); // Kör metoden för att vända text
                            break;
                        case 'x':
                            keepGoing = false; // Stäng av loopen och gå tillbaka
                            break;
                        default:
                            Console.WriteLine("Use +, -, r or x."); // Påminn om giltiga val
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Wrong input"); // Säg till om input är fel
                }
            }
        }

        // 2. Implementera en ReverseText-metod som läser in en sträng från användaren och
        // med hjälp av en stack vänder ordning på teckenföljden för att sedan skriva ut den
        // omvända strängen till användaren.
        static void ReverseText()
        {
            Console.WriteLine("Enter text to reverse:"); // Be användaren skriva text
            string? text = Console.ReadLine(); // Läs in texten
            if (string.IsNullOrEmpty(text)) // Kolla om texten är tom eller null
            {
                Console.WriteLine("No text entered."); // Meddela om inget skrivs
                return; // Avsluta metoden
            }

            Stack<char> charStack = new Stack<char>(); // Skapa en stack för tecken
            foreach (char c in text) // Gå igenom varje tecken i texten
            {
                charStack.Push(c); // Lägg till tecknet på stacken
            }

            Console.Write("Reversed: "); // Skriv ut "Omvänt:" innan resultatet
            while (charStack.Count > 0) // Så länge det finns tecken på stacken
            {
                Console.Write(charStack.Pop()); // Ta bort och skriv ut tecknet baklänges
            }
            Console.WriteLine(); // Lägg till ny rad efter utskrift
        }

        static void CheckParanthesis()
        {
            // Be användaren skriva in en sträng att kontrollera
            Console.WriteLine("Enter a string to check for balanced parenthesis:");
            string? input = Console.ReadLine();

            if (string.IsNullOrEmpty(input))
            {
                Console.WriteLine("No input provided.");
                return;
            }

            Stack<char> stack = new Stack<char>(); // Stack för att hålla koll på öppna parenteser
            // Dictionary för att matcha stängande mot öppnande parenteser
            Dictionary<char, char> matches = new Dictionary<char, char>
            {
                { ')', '(' },
                { ']', '[' },
                { '}', '{' }
            };

            bool isBalanced = true; // Flagga för att hålla koll på balansen

            foreach (char c in input)
            {
                // Om tecknet är en öppnande parentes, lägg på stacken
                if (c == '(' || c == '[' || c == '{')
                {
                    stack.Push(c);
                }
                // Om tecknet är en stängande parentes
                else if (c == ')' || c == ']' || c == '}')
                {
                    // Om stacken är tom eller inte matchar, är det obalanserat
                    if (stack.Count == 0 || stack.Pop() != matches[c])
                    {
                        isBalanced = false;
                        break;
                    }
                }
            }

            // Om stacken är tom och flaggan är sann, är det balanserat
            if (isBalanced && stack.Count == 0)
            {
                Console.WriteLine("Parenthesis are balanced.");
            }
            else
            {
                Console.WriteLine("Parenthesis are NOT balanced.");
            }
        }

    }
}

