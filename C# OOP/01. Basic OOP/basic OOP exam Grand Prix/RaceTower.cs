using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public class RaceTower
{
    private List<Driver> failedDrivers;
    private List<Driver> drivers;
    public Track track;
    private string weather;

    public RaceTower()
    {
        this.failedDrivers = new List<Driver>();
        this.drivers = new List<Driver>();
        this.weather = "Sunny";
    }

    public void SetTrackInfo(int lapsNumber, int trackLength)
    {
        this.track = new Track(lapsNumber, trackLength);
    }//done

    public void RegisterDriver(List<string> commandArgs)
    {
        string type = commandArgs[1];
        string name = commandArgs[2];
        bool validHp = int.TryParse(commandArgs[3], out int hp);
        bool validFuelAmount = double.TryParse(commandArgs[4], out double fuelAmount);
        string tyreType = commandArgs[5];
        bool validTyreHardness = double.TryParse(commandArgs[6], out double tyreHardness);
        if (tyreType.ToLower() == "ultrasoft")
        {
            bool validGrip = double.TryParse(commandArgs[6], out double grip);
            if (validFuelAmount && validHp && validTyreHardness && validGrip)
            {
                Tyre tyre = new UltrasoftTyre(tyreHardness, grip);
                Car car = new Car(hp, fuelAmount, tyre);
                if (type.ToLower() == "aggressive")
                {
                    Driver driver = new AggressiveDriver(name, car);
                    drivers.Add(driver);
                }
                else if (type.ToLower() == "endurance")
                {
                    Driver driver = new AggressiveDriver(name, car);
                    drivers.Add(driver);
                }
            }
        }
        else if (tyreType.ToLower() == "hard")
        {
            if (validFuelAmount && validHp && validTyreHardness)
            {
                Tyre tyre = new HardTyre(tyreHardness);
                Car car = new Car(hp, fuelAmount, tyre);
                if (type.ToLower() == "aggresive")
                {
                    Driver driver = new AggressiveDriver(name, car);
                    drivers.Add(driver);
                }
                else if (type.ToLower() == "endurance")
                {
                    Driver driver = new EnduranceDriver(name, car);
                    drivers.Add(driver);
                }
            }
        }
    }//done

    public void DriverBoxes(List<string> commandArgs)
    {
        string reason = commandArgs[1];
        string driverName = commandArgs[2];
        if (reason == "ChangeTyres")
        {
            string tyreType = commandArgs[3];
            double tyreHardness = double.Parse(commandArgs[4]);
            if (tyreType == "Ultrasoft")
            {
                double grip = double.Parse(commandArgs[5]);
                Tyre tyre = new UltrasoftTyre(tyreHardness, grip);
                drivers.FirstOrDefault(d => d.Name == driverName).Car.Tyre = tyre;
                drivers.FirstOrDefault(d => d.Name == driverName).TotalTime += 20;

            }
            else
            {
                Tyre tyre = new HardTyre(tyreHardness);
                drivers.FirstOrDefault(d => d.Name == driverName).Car.Tyre = tyre;
                drivers.FirstOrDefault(d => d.Name == driverName).TotalTime += 20;
            }
        }
        else
        {
            drivers.FirstOrDefault(d => d.Name == driverName).Car.FuelAmount = 160;
            drivers.FirstOrDefault(d => d.Name == driverName).TotalTime += 20;
        }
    }//done

    public string CompleteLaps(List<string> commandArgs)
    {
        int numberOfLaps = int.Parse(commandArgs[0]);
        if (track.LapsNumber - track.currentLap < numberOfLaps)
            return $"There is no time! On lap {this.track.currentLap}";


        for (int i = 0; i < numberOfLaps; i++)
        {
            DecreaseData();
            drivers = drivers.OrderBy(x => x.TotalTime).ToList();
            Overtaking();

            track.currentLap++;
        }

        return "";
    }


    private string Overtaking()
    {
        StringBuilder sb = new StringBuilder();

        for (int j = 0; j < drivers.Count - 1; j++)
        {
            //Overtaking
            Driver secondDriver = drivers[j];
            Driver firstDriver = drivers[j + 1];

            bool isAggressiveDriver = secondDriver.GetType().Name == "AggressiveDriver";
            bool isUltrasoftTyre = secondDriver.Car.Tyre.Name == "Ultrasoft";
            bool isFoggyWeather = weather == "Foggy";

            bool isEnduranceDriver = secondDriver.GetType().Name == "EnduranceDriver";
            bool isHardTyre = secondDriver.Car.Tyre.Name == "Hard";
            bool isRainyWeather = weather == "Rainy";


            if (isAggressiveDriver && isUltrasoftTyre && isFoggyWeather && firstDriver.TotalTime - secondDriver.TotalTime <= 3)
            {
                secondDriver.TotalTime -= 3;
                firstDriver.TotalTime += 3;
                secondDriver.failiure = "Crashed";
                failedDrivers.Add(secondDriver);
                drivers.Remove(secondDriver);
            }
            else if (isEnduranceDriver && isHardTyre && isRainyWeather && firstDriver.TotalTime - secondDriver.TotalTime <= 3)
            {
                secondDriver.TotalTime -= 3;
                firstDriver.TotalTime += 3;
                secondDriver.failiure = "Crashed";
                failedDrivers.Add(secondDriver);
                drivers.Remove(secondDriver);
            }
            else if (firstDriver.TotalTime - secondDriver.TotalTime <= 2)
            {
                secondDriver.TotalTime -= 2;
                firstDriver.TotalTime += 2;
                sb.AppendLine($"{secondDriver.Name} has overtaken {firstDriver.Name} on lap {this.track.currentLap}.");

                j++;
            }
        }

        string result = sb.ToString().TrimEnd();

        return result;
    }


    private void DecreaseData()
    {
        foreach (var driver in drivers.OrderByDescending(x => x.TotalTime))
        {
            if (driver.failiure != "")
            {
                try
                {
                    driver.TotalTime += 60 / (track.Length / driver.Speed);
                    driver.Car.FuelAmount -= track.Length * driver.FuelConsumptionPerKm;
                    driver.Car.Tyre.DegradeTyre();
                }
                catch (Exception e)
                {
                    driver.failiure = e.Message;
                    failedDrivers.Add(driver);
                    drivers.Remove(driver);
                    Console.WriteLine(e.Message);
                }
            }
        }
    }

    public string GetLeaderboard()
    {
        var sb = new StringBuilder();
        sb.AppendLine($"Lap {this.track.currentLap}/{this.track.LapsNumber}");
        drivers = drivers.OrderBy(x => x.TotalTime).ToList();
        for (int i = 0; i < drivers.Count; i++)
        {
            sb.AppendLine($"{i} {drivers[i].Name} {drivers[i].TotalTime}");
        }

        return sb.ToString();
    }

    public void ChangeWeather(List<string> commandArgs)
    {
        if (commandArgs[1].ToLower() == "rainy")
        {
            this.weather = "Rainy";
        }
        else if (commandArgs[1].ToLower() == "foggy")
        {
            this.weather = "Foggy";
        }
        else
        {
            this.weather = "Sunny";
        }
    }//done

}

