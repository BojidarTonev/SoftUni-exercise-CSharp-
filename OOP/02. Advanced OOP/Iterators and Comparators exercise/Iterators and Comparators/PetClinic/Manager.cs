using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PetClinicc;


public class Manager
{
    private List<Clinic> clinics;
    private List<Pet> pets;

    public Manager()
    {
        this.clinics = new List<Clinic>();
        this.pets = new List<Pet>();
    }

    public void CreatePet(string name, int age, string kind)
    {
        Pet pet = new Pet(name, age, kind);
        pets.Add(pet);
    }

    public void CreateClinic(string name, int numberOfRooms)
    {
        if (numberOfRooms % 2 == 0)
        {
            throw new InvalidOperationException("Invalid Operation!");
        }

        if (numberOfRooms < 1 || numberOfRooms > 101)
        {
            throw new InvalidOperationException("Invalid Operation!");
        }
        Clinic clinic = new Clinic(name, numberOfRooms);
        clinics.Add(clinic);
    }

    public bool Add(string petName, string clinicName)
    {
        Pet pet = pets.FirstOrDefault(p => p.Name == petName);
        Clinic clinic = clinics.FirstOrDefault(c => c.Name == clinicName);
        if (pet == null || clinic == null)
        {
            throw new InvalidOperationException("Invalid Operation!");
        }

        if (clinic.Add(pet))
        {
            pets.Remove(pet);
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool Release(string clinicName)
    {
        Clinic clinic = clinics.FirstOrDefault(c => c.Name == clinicName);
        if (clinic == null)
        {
            throw new InvalidOperationException("Invalid Operation!");
        }

        return clinic.Release();
    }

    public bool HasEmptyRooms(string clinicName)
    {
        Clinic clinic = clinics.FirstOrDefault(c => c.Name == clinicName);
        if (clinic == null)
        {
            throw new InvalidOperationException("Invalid Operation!");
        }

        return clinic.HasEmptyRooms();
    }

    public string PrintClinic(string clinicName)
    {
        Clinic clinic = clinics.FirstOrDefault(c => c.Name == clinicName);
        if (clinic == null)
        {
            throw new InvalidOperationException("Invalid Operation!");
        }
        var sb = new StringBuilder();
        foreach (var pet in clinic.animalsInside)
        {
            if (pet == null)
            {
                sb.AppendLine("Room empty");
            }
            else
            {
                sb.AppendLine(pet.ToString());
            }           
        }

        return sb.ToString().TrimEnd();
    }

    public string PrintSingle(string clinicName, int room)
    {
        room--;
        Clinic clinic = clinics.FirstOrDefault(c => c.Name == clinicName);
        if (clinic == null)
        {
            throw new InvalidOperationException("Invalid Operation!");
        }

        if (room >= clinic.animalsInside.Length)
        {
            throw new InvalidOperationException("Invalid Operation!");
        }

        Pet petToReturn = clinic.animalsInside[room];
        return petToReturn.ToString();
    }
}

