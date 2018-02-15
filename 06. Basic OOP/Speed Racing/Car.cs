using System;
using System.Collections.Generic;
using System.Text;


class Car
{
    public static List<Car> cars = new List<Car>();

    private string model;

    public string Model
    {
        get { return model; }
        set { model = value; }
    }

    private double fuelAmount;

    public double FuelAmount
    {
        get { return fuelAmount; }
        set { fuelAmount = value; }
    }

    private double fuelConsumption;

    public double FuelConsumption
    {
        get { return fuelConsumption; }
        set { fuelConsumption = value; }
    }

    private double distnceTravelled;

    public double DistanceTravelled
    {
        get { return distnceTravelled; }
        set { distnceTravelled = value; }
    }

    public Car(string model, double fuelAmount, double fuelConsumption)
    {
        this.model = model;
        this.fuelAmount = fuelAmount;
        this.fuelConsumption = fuelConsumption;
        this.distnceTravelled = 0;
        cars.Add(this);
    }

    public static void DriveTheWay(string model, int desiredDistance)
    {
        foreach (var car in cars)
        {
            if (car.Model == model)
            {
                double wantedFuel = car.FuelConsumption * desiredDistance;
                if (wantedFuel > car.FuelAmount)
                {
                    Console.WriteLine("Insufficient fuel for the drive");
                    return;
                }
                else
                {
                    car.DistanceTravelled += desiredDistance;
                    car.FuelAmount -= wantedFuel;
                }

                break;
            }
        }
    }
}

