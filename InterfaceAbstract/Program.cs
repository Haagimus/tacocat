using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace InterfaceAbstract
{
    class Program
    {
        static void Main()
        {
            // Example vehicle creation and display
            //Vehicle ford = new Car
            //{
            //    Year = 2016,
            //    Runs = "Yes",
            //    Make = "Ford",
            //    Model = "Mustang"
            //};
            //displayVehicle(ford);

            // Example vehicle creation and display
            //Vehicle vw = new Car
            //{
            //    Year = 2010,
            //    Runs = "No",
            //    Make = "Volkswagen",
            //    Model = "GTI"
            //};
            //displayVehicle(vw);

            // Example vehicle creation and display
            //Vehicle tundra = new Truck
            //{
            //    Year = 2014,
            //    Runs = "Yes",
            //    Make = "Toyota",
            //    Model = "Tundra"
            //};
            //displayVehicle(tundra);

            Console.Clear();
            Console.WriteLine("What type of vehicle do you want to make and press Enter:");
            Console.WriteLine("1. Car");
            Console.WriteLine("2. Truck");
            Console.WriteLine("3. Exit");
            var selection = Console.ReadLine();

            try
            {
                // Check that the number entered was actually one of the available options and alert user if not
                if (int.Parse(selection) < 1 || int.Parse(selection) > 3)
                {
                    Console.Clear();
                    Console.WriteLine("Please only enter one of the available selections. Press any key to restart.");
                    Console.ReadKey();
                    Main();
                }

                // User selected car
                if (int.Parse(selection) == 1)
                {
                    int _year = 0;
                    do
                    {
                        _year = getYear();
                    } while (_year == 0);

                    string _runs;
                    do
                    {
                        _runs = getRuns();
                    } while (_runs == null);

                    string _make;
                    do
                    {
                        _make = getMake();
                    } while (_make == null);

                    string _model;
                    do
                    {
                        _model = getModel();
                    } while (_model == null);

                    Car car = new Car
                    {
                        Year = _year,
                        Runs = _runs,
                        Make = _make,
                        Model = _model
                    };

                    displayVehicle(car);
                }

                // User selected truck
                if (int.Parse(selection) == 2)
                {
                    int _year = 0;
                    do
                    {
                        _year = getYear();
                    } while (_year == 0);

                    string _runs;
                    do
                    {
                        _runs = getRuns();
                    } while (_runs == null);

                    string _make;
                    do
                    {
                        _make = getMake();
                    } while (_make == null);

                    string _model;
                    do
                    {
                        _model = getModel();
                    } while (_model == null);

                    string _4wd;
                    do
                    {
                        _4wd = get4wd();
                    } while (_4wd == null);

                    Truck truck = new Truck
                    {
                        Year = _year,
                        Runs = _runs,
                        Make = _make,
                        Model = _model,
                        FourWheelDrive = _4wd
                    };

                    displayVehicle(truck, truck.FourWheelDrive);
                }

                // User selected exit
                if (int.Parse(selection) == 3)
                {
                    Environment.Exit(0);
                }
            }
            // If something other that a number was entered alert the user to try again and restart
            catch (FormatException)
            {
                Console.Clear();
                Console.WriteLine("You did not enter a number please try again. Press any key to continue.");
                Console.ReadKey();
                Main();
            }

            // Get user input for vehicle year and validate that it is a number, if its not alert the user
            int getYear()
            {
                int result;

                Console.Clear();
                Console.WriteLine("Type the vehicle year and press Enter:");
                var _year = Console.ReadLine();

                try
                {
                    result = int.Parse(_year);
                }
                catch (FormatException)
                {
                    Console.Clear();
                    Console.WriteLine("You did not enter a number please try again. Press any key to continue.");
                    Console.ReadKey();
                    return 0;
                }

                return result;
            }

            // Get user input for whether the vehicle runs and verify it is a yes or no, if its not alert the user
            string getRuns()
            {
                Console.Clear();
                Console.WriteLine("Does the vehicle run?");
                var _runs = Console.ReadLine().ToLower();

                if (Regex.IsMatch(_runs, "(yes|no)"))
                {
                    return _runs;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Please enter \"yes\" or \"no\". Press any key to continue.");
                    Console.ReadKey();
                    return null;
                }
            }

            // Get user input for vehicle make
            string getMake()
            {
                Console.Clear();
                Console.WriteLine("Type the vehicle make and press Enter:");
                return Console.ReadLine();
            }

            // Get user input for vehicle model
            string getModel()
            {
                Console.Clear();
                Console.WriteLine("Type the vehicle model and press Enter:");
                return Console.ReadLine();
            }

            // Get user input for whether the vehicle is four wheel drive and verify it is a yes or no, if its not alert the user
            string get4wd()
            {
                Console.Clear();
                Console.WriteLine("Is the truck 4WD?");
                var _4wd = Console.ReadLine();

                if (Regex.IsMatch(_4wd, "(yes|no)"))
                {
                    return _4wd;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Please enter \"yes\" or \"no\". Press any key to continue.");
                    Console.ReadKey();
                    return null;
                }
            }

            /// <summary>
            /// Output the vehicle information that is stored for that object so the user can read it
            /// </summary>
            /// <param name="vehicle">The vehicle object to get the information from</param>
            /// <param name="_4wd">Optional string stating if the vehicle is four wheel drive or not</param>
            void displayVehicle(Vehicle vehicle, string _4wd = null)
            {
                Console.Clear();
                Console.WriteLine($"{vehicle.Year} {vehicle.Make + " " + vehicle.Model}");
                Console.WriteLine($"Runs? {vehicle.Runs}");
                if (_4wd != null)
                {
                    Console.WriteLine($"Is truck 4WD? {_4wd}");
                }
                Console.WriteLine("This vehicle is " + vehicle.YearsOld(vehicle.Year) + " year(s) old");
                Console.WriteLine();

                Console.Write("Press any key to continue.");
                Console.ReadKey();
            }
        }
    }

    /// <summary>
    /// Generic vehicle interface
    /// </summary>
    public interface IVehicle
    {
        Int32 Year();
        string Runs();
        string Make();
        string Model();
    }

    /// <summary>
    /// Generic vehicle class with age calculation
    /// </summary>
    public abstract class Vehicle
    {
        public abstract Int32 Year { get; set; }
        public abstract string Runs { get; set; }
        public abstract string Make { get; set; }
        public abstract string Model { get; set; }

        public Int32 YearsOld(int year)
        {
            return DateTime.Now.Year - Year;
        }
    }

    /// <summary>
    /// Car class constructor
    /// </summary>
    public class Car : Vehicle
    {
        Int32 _year;
        public override Int32 Year
        {
            get { return _year; }
            set { _year = value; }
        }

        string _runs;
        public override string Runs
        {
            get { return _runs; }
            set { _runs = value; }
        }

        string _make;
        public override string Make
        {
            get { return _make; }
            set { _make = value; }

        }

        string _model;
        public override string Model
        {
            get { return _model; }
            set { _model = value; }

        }
    }

    /// <summary>
    /// Truck class constructor
    /// </summary>
    public class Truck : Vehicle
    {
        Int32 _year;
        public override Int32 Year
        {
            get { return _year; }
            set { _year = value; }
        }

        string _runs;
        public override string Runs
        {
            get { return _runs; }
            set { _runs = value; }
        }

        string _make;
        public override string Make
        {
            get { return _make; }
            set { _make = value; }

        }

        string _model;
        public override string Model
        {
            get { return _model; }
            set { _model = value; }

        }

        string _4wd;
        public string FourWheelDrive
        {
            get { return _4wd; }
            set { _4wd = value; }
        }
    }
}
