using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using Newtonsoft.Json;
using PetClinic.App.Dtos.Import;
using PetClinic.Models;
using DataAnotations = System.ComponentModel.DataAnnotations;

namespace PetClinic.DataProcessor
{
    using System;

    using PetClinic.Data;

    public class Deserializer
    {

        public static string ImportAnimalAids(PetClinicContext context, string jsonString)
        {
            var sb = new StringBuilder();
            var jsonAnimalAids = JsonConvert.DeserializeObject<AnimalAidsDto[]>(jsonString);
            var animalAids = new List<AnimalAid>();

            foreach (var animalAidDto in jsonAnimalAids)
            {
                if (!IsValid(animalAidDto))
                {
                    sb.AppendLine("Error: Invalid data.");
                    continue;
                }
                var animalAid = new AnimalAid()
                {
                    Name = animalAidDto.Name,
                    Price = animalAidDto.Price
                };

                if (animalAids.Any(a => a.Name == animalAid.Name))
                {
                    sb.AppendLine("Error: Invalid data.");
                    continue;
                }

                animalAids.Add(animalAid);
                sb.AppendLine($"Record {animalAid.Name} successfully imported.");
            }
            context.AnimalAids.AddRange(animalAids);
            context.SaveChanges();

            return sb
                .ToString();
        }

        public static string ImportAnimals(PetClinicContext context, string jsonString)
        {
            var sb = new StringBuilder();
            var jsonAnimals = JsonConvert.DeserializeObject<AnimalDto[]>(jsonString);
            var animals = new List<Animal>();
            var passports = new List<Passport>();

            foreach (var animalDto in jsonAnimals)
            {
                if (!IsValid(animalDto) || !IsValid(animalDto.Passport) || passports.Any(p => p.SerialNumber.Equals(animalDto.Passport.SerialNumber, StringComparison.OrdinalIgnoreCase)))
                {
                    sb.AppendLine("Error: Invalid data.");
                    continue;
                }

                DateTime registrationDate = DateTime
                    .ParseExact(animalDto.Passport.RegistrationDate, "dd-MM-yyyy",
                    CultureInfo.InvariantCulture);


                var passport = new Passport()
                {
                    SerialNumber = animalDto.Passport.SerialNumber,
                    OwnerName = animalDto.Passport.OwnerName,
                    OwnerPhoneNumber = animalDto.Passport.OwnerPhoneNumber,
                    RegistrationDate = registrationDate
                };

                passports.Add(passport);

                var animal = new Animal()
                {
                    Name = animalDto.Name,
                    Type = animalDto.Type,
                    Age = animalDto.Age,
                    Passport = passport,
                    PassportSerialNumber = animalDto.Passport.SerialNumber
                };

                animals.Add(animal);
                sb.AppendLine($"Record {animal.Name} Passport №: {passport.SerialNumber} successfully imported.");
            }

            context.Passports.AddRange(passports);
            context.Animals.AddRange(animals);
            context.SaveChanges();

            return sb
                .ToString()
                .TrimEnd();
        }

        public static string ImportVets(PetClinicContext context, string xmlString)
        {
            var sb = new StringBuilder();
            var serializer = new XmlSerializer(typeof(VetDto[]), new XmlRootAttribute("Vets"));
            var deserializedVets = (VetDto[]) serializer.Deserialize(new StringReader(xmlString));

            var vets = new List<Vet>();

            foreach (var vetDto in deserializedVets)
            {
                if (!IsValid(vetDto) || vets.Any(v => v.PhoneNumber == vetDto.PhoneNumber))
                {
                    sb.AppendLine("Error: Invalid data.");
                    continue;
                }

                var vet = new Vet()
                {
                    Name = vetDto.Name,
                    Profession = vetDto.Profession,
                    Age = vetDto.Age,
                    PhoneNumber = vetDto.PhoneNumber
                };

                vets.Add(vet);
                sb.AppendLine($"Record {vet.Name} successfully imported.");
            }

            context.Vets.AddRange(vets);
            context.SaveChanges();

            return sb
                .ToString()
                .TrimEnd();
        }

        public static string ImportProcedures(PetClinicContext context, string xmlString)
        {
            var sb = new StringBuilder();
            var serializer = new XmlSerializer(typeof(ProcedureDto[]), new XmlRootAttribute("Procedures"));
            var deserialiedCategories = (ProcedureDto[])serializer.Deserialize(new StringReader(xmlString));

            var procedures = new List<Procedure>();

            foreach (var procedureDto in deserialiedCategories)
            {
                if (!IsValid(procedureDto) || 
                    procedureDto.AnimalAids.Select(a => a.Name).Distinct().Count() != procedureDto.AnimalAids.Length)
                {
                    sb.AppendLine("Error: Invalid data.");
                    continue;
                }

                var vet = context.Vets
                    .FirstOrDefault(v => v.Name == procedureDto.VetName);
                if (vet == null)
                {
                    sb.AppendLine("Error: Invalid data.");
                    continue;
                }

                var animal = context.Animals
                    .FirstOrDefault(a => a.Passport.SerialNumber == procedureDto.AnimalSerialNumber);
                if (animal == null)
                {
                    sb.AppendLine("Error: Invalid data.");
                    continue;
                }

                var animalAids = context.AnimalAids
                    .Where(a => procedureDto.AnimalAids.Any(dto =>
                        dto.Name.Equals(a.Name, StringComparison.OrdinalIgnoreCase))).ToArray();
                if (animalAids.Length != procedureDto.AnimalAids.Length)
                {
                    sb.AppendLine("Error: Invalid data.");
                    continue;
                }

                var date = DateTime.ParseExact(procedureDto.DateTime, "dd-MM-yyyy", CultureInfo.InvariantCulture);

                var procedureAnimalAids = new List<ProcedureAnimalAid>();
                foreach (var dto in animalAids)
                {
                    procedureAnimalAids.Add(new ProcedureAnimalAid()
                    {
                        AnimalAidId = dto.Id
                    });
                }

                var procedure = new Procedure()
                {
                    VetId = vet.Id,
                    AnimalId = animal.Id,
                    DateTime = date,
                    ProcedureAnimalAids = procedureAnimalAids
                };

                procedures.Add(procedure);
                sb.AppendLine("Record successfully imported.");
            }

            context.Procedures.AddRange(procedures);
            context.SaveChanges();
            return sb
                .ToString()
                .TrimEnd();
        }

        private static bool IsValid(object obj)
        {
            var validationContext = new DataAnotations.ValidationContext(obj);
            var validationResults = new List<DataAnotations.ValidationResult>();

            return DataAnotations.Validator.TryValidateObject(obj, validationContext, validationResults, true);
        }
    }
}