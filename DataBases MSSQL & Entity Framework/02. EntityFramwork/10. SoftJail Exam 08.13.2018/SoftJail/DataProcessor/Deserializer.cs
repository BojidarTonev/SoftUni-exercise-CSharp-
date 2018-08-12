using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;
using System.Xml.Serialization;
using Newtonsoft.Json;
using SoftJail.Data.Models;
using SoftJail.Data.Models.Enums;
using SoftJail.DataProcessor.ImportDto;
using DataAnotations = System.ComponentModel.DataAnnotations;

namespace SoftJail.DataProcessor
{

    using Data;
    using System;

    public class Deserializer
    {
        private const string ERROR = "Invalid Data";

        public static string ImportDepartmentsCells(SoftJailDbContext context, string jsonString)
        {
            var sb = new StringBuilder();
            var jsonDepartmentCells = JsonConvert.DeserializeObject<DepartmentDto[]>(jsonString);
            var departments = new List<Department>();

            foreach (var departmentDto in jsonDepartmentCells)
            {
                if (!IsValid(departmentDto))
                {
                    sb.AppendLine(ERROR);
                    continue;
                }

                var cells = new List<Cell>();
                bool areCellsValid = true;
                foreach (var cellDto in departmentDto.Cells)
                {
                    if (!IsValid(cellDto))
                    {
                        sb.AppendLine(ERROR);
                        areCellsValid = false;
                        break;
                    }

                    var cell = new Cell()
                    {
                        CellNumber = cellDto.CellNumber,
                        HasWindow = cellDto.HasWindow
                    };
                    cells.Add(cell);
                }

                if (areCellsValid)
                {
                    var department = new Department()
                    {
                        Name = departmentDto.Name,
                        Cells = cells
                    };

                    departments.Add(department);
                    sb.AppendLine($"Imported {department.Name} with {department.Cells.Count} cells");
                    context.Cells.AddRange(cells);
                }
            }

            context.Departments.AddRange(departments);
            context.SaveChanges();

            return sb
                .ToString()
                .TrimEnd();
        }

        public static string ImportPrisonersMails(SoftJailDbContext context, string jsonString)
        {
            var sb = new StringBuilder();
            var jsonPrisoners = JsonConvert.DeserializeObject<PrisonerDto[]>(jsonString);
            var prisoners = new List<Prisoner>();

            foreach (var prisonerDto in jsonPrisoners)
            {
                if (!IsValid(prisonerDto))
                {
                    sb.AppendLine(ERROR);
                    continue;
                }

                var mails = new List<Mail>();

                var IncDate = DateTime.ParseExact(prisonerDto.IncarcerationDate, "dd/MM/yyyy",
                    CultureInfo.InvariantCulture);
                DateTime reDate;
                DateTime.TryParseExact(prisonerDto.ReleaseDate, "dd/MM/yyyy",
                    CultureInfo.InvariantCulture, DateTimeStyles.None ,out reDate);


                bool areMailsValid = true;

                foreach (var mailDto in prisonerDto.Mails)
                {
                    if (!IsValid(mailDto))
                    {
                        sb.AppendLine(ERROR);
                        areMailsValid = false;
                        break;
                    }

                    var mail = new Mail()
                    {
                        Address = mailDto.Address,
                        Description = mailDto.Description,
                        Sender = mailDto.Sender
                    };
                    mails.Add(mail);
                }

                if (areMailsValid)
                {
                    var prisoner = new Prisoner()
                    {
                        FullName = prisonerDto.FullName,
                        Nickname = prisonerDto.Nickname,
                        Age = prisonerDto.Age,
                        IncarcerationDate = IncDate,
                        ReleaseDate = reDate,
                        Bail = prisonerDto.Bail,
                        CellId = prisonerDto.CellId,
                        Mails = mails
                    };

                    prisoners.Add(prisoner);
                    context.Mails.AddRange(mails);
                    sb.AppendLine($"Imported {prisoner.FullName} {prisoner.Age} years old");
                }
            }
            
            context.Prisoners.AddRange(prisoners);
            context.SaveChanges();

            return sb
                .ToString()
                .TrimEnd();
        }

        public static string ImportOfficersPrisoners(SoftJailDbContext context, string xmlString)
        {
            var sb = new StringBuilder();
            var serializer = new XmlSerializer(typeof(OfficerDto[]), new XmlRootAttribute("Officers"));
            var deserializedOfficers = (OfficerDto[])serializer.Deserialize(new StringReader(xmlString));

            var officers = new List<Officer>();

            foreach (var officerDto in deserializedOfficers)
            {
                //Position position;
                Enum.TryParse(typeof(Position), officerDto.Position, out object position);
                //Weapon weapon; 
                Enum.TryParse(typeof(Weapon), officerDto.Weapon, out object weapon);

                if (!IsValid(officerDto) || position == null || weapon == null)
                {
                    sb.AppendLine(ERROR);
                    continue;;
                }

                var prisoners = new List<OfficerPrisoner>();

                foreach (var prisonerDto in officerDto.Prisoners)
                {
                    var prisoner = new OfficerPrisoner()
                    {
                        PrisonerId = prisonerDto.Id
                    };
                    prisoners.Add(prisoner);
                }

                var officer = new Officer()
                {
                    FullName = officerDto.Name,
                    Salary = officerDto.Money,
                    Position = (Position) position,
                    Weapon = (Weapon) weapon,
                    DepartmentId = officerDto.DepartmentId,
                    OfficerPrisoners = prisoners
                };

                officers.Add(officer);
                sb.AppendLine($"Imported {officer.FullName} ({officer.OfficerPrisoners.Count} prisoners)");
            }

            context.Officers.AddRange(officers);
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