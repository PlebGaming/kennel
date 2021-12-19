using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inlamningsuppgift1
{
    public class Menu : IMenu
    {
        public bool Show(IKennel kennel)
        {

            Console.WriteLine("Hello and welcome to the Kennel!");
            Console.WriteLine("Please pick an option!");
            Console.WriteLine("1 Check in your dog");
            Console.WriteLine("2 Check out your dog");
            Console.WriteLine("3 Register new customer");
            Console.WriteLine("4 Register new dog(must be a registered customer!)");
            Console.WriteLine("5 Check Dogs and their owner");
            Console.WriteLine("6 View Registered Customers");
            Console.WriteLine("7 View Registered Dogs");
            Console.WriteLine("8 View Dogs in the kennel");
            Console.WriteLine("20 To exit program!");

            
            string inputChoice = Console.ReadLine();
            switch (inputChoice)
            {
                case "1":
                    Console.WriteLine("Please enter the name of your dog to check it in");
                    var checkInOfdog = Console.ReadLine();
                    bool dogFound = false;
                    dogFound = CheckIn(kennel, checkInOfdog, dogFound);
                    if (!dogFound) Console.WriteLine("Your dog didn't exist, please enter the name correct or register your dog if you havn't already");
                    Console.WriteLine("Press enter to continue");
                    Console.ReadLine();
                    Console.Clear();
                    break;
                case "2":
                    Console.WriteLine("Please enter the name of your dog to check it out");
                    var checkOutDog = Console.ReadLine();
                    bool dogOutFound = false;
                    dogOutFound = CheckOut(kennel, checkOutDog, dogOutFound);
                    if (!dogOutFound) Console.WriteLine("Make sure to spell your dogs name right!");
                    Console.WriteLine("Press enter to continue");
                    Console.ReadLine();
                    Console.Clear();
                    break;

                case "3":
                    Console.WriteLine("Please enter your first name:");
                    string firstName = Console.ReadLine();
                    Console.WriteLine("Please enter your last name:");
                    string lastName = Console.ReadLine();
                    kennel.NewCustomer(firstName, lastName);
                    Console.WriteLine("Press enter to continue");
                    Console.ReadLine();
                    Console.Clear();
                    break;
                case "4":
                    Console.WriteLine("Please enter your dogs name:");
                    string dogName = Console.ReadLine();
                    Console.WriteLine("Please enter YOUR first name:");
                    string custName = Console.ReadLine();
                    bool customerFound = false;
                    customerFound = CustomerCheck(kennel, dogName, custName, customerFound);
                    if (!customerFound) Console.WriteLine("Please Enter a correct first name, if you didnt register as a customer please do so before you register your dog!");
                    Console.WriteLine("Press enter to continue");
                    Console.ReadLine();
                    Console.Clear();
                    break;
                case "5":
                    kennel.DogAndOwner();
                    Console.WriteLine("Press enter to continue");
                    Console.ReadLine();
                    Console.Clear();
                    break;
                case "6":
                    Console.WriteLine("Customers:");
                    kennel.CheckRegisteredCustomers();
                    Console.WriteLine("Press enter to continue");
                    Console.ReadLine();
                    Console.Clear();
                    break;
                case "7":
                    Console.WriteLine("Dogs:");
                    kennel.CheckRegisteredDogs();
                    Console.WriteLine("Press enter to continue");
                    Console.ReadLine();
                    Console.Clear();
                    break;
                case "8":
                    Console.WriteLine("Dogs running around insida the kennel");
                    DogsInTheKennel(kennel);
                    Console.WriteLine("Press enter to continue");
                    Console.ReadLine();
                    Console.Clear();
                    break;
                case "20":
                    return (false);                    
                default:

                    break;
            }
            return (true);
        }

        public void DogsInTheKennel(IKennel kennel)
        {
            foreach (var dogInkennel in kennel.DogsInKennel)
            {
                Console.WriteLine(dogInkennel.Name);
            }
            if (kennel.DogsInKennel.Count <= 0)
            {
                Console.WriteLine("Zero at the moment");
            }
        }

        public bool CustomerCheck(IKennel kennel, string dogName, string custName, bool customerFound)
        {
            foreach (var cust in kennel.Customers)
            {
                if (cust.FirstName.ToLower() == custName.ToLower())
                {
                    kennel.NewDog(dogName, cust);
                    customerFound = true;
                    break;
                }
            }

            return customerFound;
        }

        public bool CheckIn(IKennel kennel, string checkInOfdog, bool dogFound)
        {
            foreach (var dog in kennel.Dogs)
            {
                if (checkInOfdog.ToLower() == dog.Name.ToLower())
                {
                    kennel.CheckInDog(dog);
                    dog.ServicesOrdered.Add(new DogCare());
                    Console.WriteLine("Do you want to add the service dog wash? y or n?");
                    string answer = Console.ReadLine();
                    if (answer.ToLower() == "y")
                    {
                        dog.ServicesOrdered.Add(new DogWash());
                    }
                    Console.WriteLine("Do you want to add the service claw trimming? y or n?");
                    string answer2 = Console.ReadLine();
                    if (answer.ToLower() == "y")
                    {
                        dog.ServicesOrdered.Add(new ClawTrimming());
                    }
                    dogFound = true;
                    break;
                }
            }
            return dogFound;
        }

        public bool CheckOut(IKennel kennel, string checkOutDog, bool dogOutFound)
        {
            foreach (var dog in kennel.DogsInKennel)
            {
                if (checkOutDog.ToLower() == dog.Name.ToLower())
                {
                    kennel.CheckOutDog(dog);
                    int totalPrice = 0;
                    foreach (IDogServices order in dog.ServicesOrdered)
                    {
                        totalPrice += order.Price;
                    }
                    Console.WriteLine("Thanks for everything! That'll be $" + totalPrice + " for all the services");
                    dogOutFound = true;
                    break;
                }
            }
            return dogOutFound;
        }
    }
}

