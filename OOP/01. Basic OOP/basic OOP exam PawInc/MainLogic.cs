using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class MainLogic
{
    public List<AdoptionCenter> adoptionCenters;
    public List<CleansingCenter> cleansingCenters;
    public List<string> adoptedAnimals;
    public List<string> cleansedAnimals;

    public MainLogic()
    {
        this.adoptionCenters = new List<AdoptionCenter>();
        this.cleansingCenters = new List<CleansingCenter>();
        this.adoptedAnimals = new List<string>();
        this.cleansedAnimals = new List<string>();
    }


    public void RegisterCleansingCenter(string name)
    {
        CleansingCenter center = new CleansingCenter(name);
        cleansingCenters.Add(center);
    }

    public void RegisterAdoptionCenter(string name)
    {
        AdoptionCenter center = new AdoptionCenter(name);
        adoptionCenters.Add(center);
    }

    public void RegisterDog(string name, int age, int learnedCommands, string adoptionCenter)
    {
        Dog dog = new Dog(name, age, learnedCommands);
        adoptionCenters.First(c => c.Name == adoptionCenter).Animals.Add(dog);
    }

    public void RegisterCat(string name, int age, int intelligence, string adoptionCenter)
    {
        Cat cat = new Cat(name, age, intelligence);
        adoptionCenters.First(c => c.Name == adoptionCenter).Animals.Add(cat);
    }

    public void SendForCleansing(string adoptionCenter, string cleansingCenter)
    {
        AdoptionCenter adoptCenter = adoptionCenters.First(c => c.Name == adoptionCenter);
        CleansingCenter cleanCenter = cleansingCenters.First(c => c.Name == cleansingCenter);
        for (int i = 0; i < adoptCenter.Animals.Count; i++)
        {
            if (adoptCenter.Animals[i].Clean == false)
            {
                adoptCenter.Animals[i].sendBackTo = adoptCenter.Name;
                cleanCenter.Animals.Add(adoptCenter.Animals[i]);
                adoptCenter.Animals.Remove(adoptCenter.Animals[i]);
                i--;
            }
        }
    }

    public void Cleanse(string cleansingCenterName)
    {
        CleansingCenter cleanCenter = cleansingCenters.First(c => c.Name == cleansingCenterName);
        for (int i = 0; i < cleanCenter.Animals.Count; i++)
        {
            if (cleanCenter.Animals[i].Clean == false) 
            {
                AdoptionCenter adoptCenter = adoptionCenters.First(c => c.Name == cleanCenter.Animals[i].sendBackTo);
                cleanCenter.Animals[i].Clean = true;
                cleansedAnimals.Add(cleanCenter.Animals[i].Name);
                adoptCenter.Animals.Add(cleanCenter.Animals[i]);
                cleanCenter.Animals.Remove(cleanCenter.Animals[i]);
                i--;
            }
        }
    }

    public void Adopt(string adoptioNCenterName)
    {
        AdoptionCenter center = adoptionCenters.First(c => c.Name == adoptioNCenterName);
        for (int i = 0; i < center.Animals.Count; i++)
        {
            if (center.Animals[i].Clean == true)
            {
                adoptedAnimals.Add(center.Animals[i].Name);
                center.Animals.Remove(center.Animals[i]);
                i--;
            }
        }
    }
}

