using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Configuration;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;


public class CarManager
{
    private Dictionary<int, Car> cars;
    private Dictionary<int, Race> races;
    private Garage garage;

    public CarManager()
    {
        cars = new Dictionary<int, Car>();
        races = new Dictionary<int, Race>();
        garage = new Garage();
    }

    public void Register(int id, string type, string brand, string model, int yearOfProduction, int horsepower,
        int acceleration, int suspension, int durability)
    {
        switch (type)
        {
            case "Performance":
                PerformanceCar car = new PerformanceCar(brand, model, yearOfProduction, horsepower, acceleration, suspension, durability);
                cars.Add(id, car);
                break;
            case "Show":
                ShowCar car1 = new ShowCar(brand, model, yearOfProduction, horsepower, acceleration, suspension, durability);
                cars.Add(id, car1);
                break;
            default:
                throw new ArgumentException();
        }
    }

    public string Check(int id)
    {
        Car car = cars.FirstOrDefault(c => c.Key == id).Value;
        return car.ToString();
    }

    public void Open(int id, string type, int length, string route, int prizePool)
    {
        switch (type.ToLower())
        {
            case "casual":
                CasualRace casualRace = new CasualRace(length, route, prizePool);
                races.Add(id, casualRace);
                break;
            case "drag":
                DragRace dragRace = new DragRace(length, route, prizePool);
                races.Add(id, dragRace);
                break;
            case "drift":
                DriftRace driftRace = new DriftRace(length, route, prizePool);
                races.Add(id, driftRace);
                break;
            default:
                Console.WriteLine("not mached cathegory");
                break;
        }
    }

    public void Participate(int carId, int raceId)
    {
        if (!garage.ParkedCars.ContainsKey(carId))
        {
            if (races.ContainsKey(raceId) && races[raceId].hasStarted == false)
            {
                Car participant = cars.First(c => c.Key == carId).Value;
                participant.IsAvailable = false;
                races[raceId].Participants.Add(participant);
            }
        }
    }

    public string Start(int id)
    {
        if (races[id].Participants.Count == 0)
        {
            return "Cannot start the race with zero participants.";
        }

        string output = races.First(r => r.Key == id).Value.ToString();
        races.First(r => r.Key == id).Value.hasStarted = true;

        foreach (var car in races.First(r => r.Key == id).Value.Participants)
        {
            car.IsAvailable = true;
        }
        races.Remove(id);

        return output;
    }

    public void Park(int id)
    {
        Car car = cars.First(c => c.Key == id).Value;
        if (car.IsAvailable)
        {
            garage.ParkedCars.Add(id, car);
        }
    }

    public void Unpark(int id)
    {
        garage.ParkedCars.Remove(id);
    }

    public void Tune(int tuneIndex, string addOn)
    {
        if (garage.ParkedCars.Count > 0)
        {
            foreach (var parkedCar in garage.ParkedCars)
            {
                parkedCar.Value.HorsePower += tuneIndex;
                parkedCar.Value.Suspension += tuneIndex / 2;
                if (parkedCar.Value.GetType().Name == "ShowCar")
                {
                    ShowCar car = (ShowCar)parkedCar.Value;
                    car.Stars += tuneIndex;
                }
                else
                {
                    PerformanceCar car = (PerformanceCar)parkedCar.Value;
                    car.AddOns.Add(addOn);
                }
            }
        }
    }
}

