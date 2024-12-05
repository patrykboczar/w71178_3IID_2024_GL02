using System;

namespace lab5
{
    public interface IVehicle
    {
        void Start();
        void Stop();
        int MaxSpeed { get; set; }
    }
    public class Car : IVehicle
    {
        public int MaxSpeed { get; set; }
        public string Brand { get; set; }

        public Car(int maxSpeed, string brand)
        {
            MaxSpeed = maxSpeed;
            Brand = brand;
        }

        public void Start()
        {
            Console.WriteLine($"{Brand} car is starting.");
        }

        public void Stop()
        {
            Console.WriteLine($"{Brand} car is stopping.");
        }

        public void Honk()
        {
            Console.WriteLine($"{Brand} car is honking.");
        }
    }
    public class Bike : IVehicle
    {
        public int MaxSpeed { get; set; }
        public string Type { get; set; }

        public Bike(int maxSpeed, string type)
        {
            MaxSpeed = maxSpeed;
            Type = type;
        }
        public void Start()
        {
            Console.WriteLine($"{Type} bike is starting.");
        }
        public void Stop()
        {
            Console.WriteLine($"{Type} bike is stopping.");
        }
        public void RingBell()
        {
            Console.WriteLine($"{Type} bike is ringing the bell.");
        }
    }
    public class zadanie2
    {
        public static void Wykonaj()
        {
            IVehicle car = new Car(200, "Toyota");
            IVehicle bike = new Bike(30, "Mountain");

            car.Start();
            car.Stop();
            ((Car)car).Honk();

            bike.Start();
            bike.Stop();
            ((Bike)bike).RingBell();
        }
    }
}

