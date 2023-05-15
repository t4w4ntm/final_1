using System;
using System.Collections.Generic;

class City
{
    public int ID { get; set; }
    public string Name { get; set; }
    public int OutbreakLevel { get; set; }

    public City(int id, string name)
    {
        ID = id;
        Name = name;
        OutbreakLevel = 0;
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Enter the number of cities: ");
        int numOfCities = int.Parse(Console.ReadLine());

        List<City> cities = new List<City>();

        for (int i = 0; i < numOfCities; i++)
        {
            Console.Write($"Enter the name of city {i}: ");
            string cityName = Console.ReadLine();

            City city = new City(i, cityName);
            cities.Add(city);
        }

        Console.WriteLine();

        while (true)
        {
            Console.WriteLine("1. Show City Details");
            Console.WriteLine("2. Enter Event");
            Console.WriteLine("3. Exit");
            Console.Write("Enter your choice: ");
            int choice = int.Parse(Console.ReadLine());

            Console.WriteLine();

            if (choice == 1)
            {
                //ShowCityDetails(cities);
            }
            else if (choice == 2)
            {
                Console.Write("Enter the event (Outbreak, Vaccinate, Lockdown, Spread, Exit): ");
                string eventType = Console.ReadLine();

                if (eventType == "Outbreak")
                {
                    Console.Write("Enter the city ID where the outbreak occurred: ");
                    int outbreakCityID = int.Parse(Console.ReadLine());

                    if (outbreakCityID >= 0 && outbreakCityID < cities.Count)
                    {
                        City outbreakCity = cities[outbreakCityID];
                        outbreakCity.OutbreakLevel += 2;

                        foreach (City city in cities)
                        {
                            if (city.ID == outbreakCityID + 1 || city.ID == outbreakCityID - 1)
                            {
                                city.OutbreakLevel += 1;
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid ID");
                    }
                }
                else if (eventType == "Vaccinate")
                {
                    Console.Write("Enter the city ID where the vaccination occurred: ");
                    int vaccinateCityID = int.Parse(Console.ReadLine());

                    if (vaccinateCityID >= 0 && vaccinateCityID < cities.Count)
                    {
                        City vaccinateCity = cities[vaccinateCityID];
                        vaccinateCity.OutbreakLevel = 0;
                    }
                    else
                    {
                        Console.WriteLine("Invalid ID");
                    }
                }
                else if (eventType == "Lockdown")
                {
                    Console.Write("Enter the city ID where the lockdown occurred: ");
                    int lockdownCityID = int.Parse(Console.ReadLine());

                    if (lockdownCityID >= 0 && lockdownCityID < cities.Count)
                    {
                        City lockdownCity = cities[lockdownCityID];
                        lockdownCity.OutbreakLevel -= 1;

                        foreach (City city in cities)
                        {
                            if (city.ID == lockdownCityID + 1 || city.ID == lockdownCityID - 1)
                            {
                                if (city.OutbreakLevel > 0)
                                {
                                    city.OutbreakLevel -= 1;
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}