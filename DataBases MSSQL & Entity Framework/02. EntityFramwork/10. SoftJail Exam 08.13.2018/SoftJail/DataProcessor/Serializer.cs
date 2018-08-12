using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using Newtonsoft.Json;
using SoftJail.DataProcessor.ExportDto;
using Formatting = Newtonsoft.Json.Formatting;

namespace SoftJail.DataProcessor
{

    using Data;
    using System;

    public class Serializer
    {
        public static string ExportPrisonersByCells(SoftJailDbContext context, int[] ids)
        {
            var prisoners = context.Prisoners
                .Where(p => ids.Any(id => id == p.Id))
                .Select(p => new
                {
                    Id = p.Id,
                    Name = p.FullName,
                    CellNumber = p.Cell.CellNumber,
                    Officers = p.PrisonerOfficers
                        .OrderBy(o => o.Officer.FullName)
                        .ThenBy(o => o.Prisoner.Id)
                        .Select(po => new
                    {
                        OfficerName = po.Officer.FullName,
                        Department = po.Officer.Department.Name
                    })
                        .ToArray(),
                    TotalOfficerSalary = p.PrisonerOfficers.Sum(po => po.Officer.Salary)
                })
                .ToArray()
                .OrderBy(x => x.Name)
                .ThenBy(x => x.Id);

            var jsonString = JsonConvert.SerializeObject(prisoners, Formatting.Indented);
            return jsonString;
        }

        public static string ExportPrisonersInbox(SoftJailDbContext context, string prisonersNames)
        {
            var namesArray = prisonersNames.Split(',').ToArray();

            var prisoners = context.Prisoners
                .Where(p => namesArray.Any(name => name == p.FullName))
                .ToList();

            var validExport = new List<ExportPrisonerDto>();

            foreach (var prisoner in prisoners)
            {
                var validMails = new List<EncrytptedMessegeDto>();

                foreach (var mail in prisoner.Mails)
                {
                    string reversed = "";
                    for (int i = mail.Description.Length - 1; i >= 0; i--)
                    {
                        reversed += mail.Description[i];
                    }
                    var massege = new EncrytptedMessegeDto()
                    {
                        Description = reversed
                    };

                    validMails.Add(massege);
                }

                var validPrisoner = new ExportPrisonerDto()
                {
                    Id = prisoner.Id,
                    Name = prisoner.FullName,
                    IncarcerationDate = prisoner.IncarcerationDate.ToString("yyyy-MM-dd"),
                    EncryptedMessages = validMails.ToArray()
                };

                validExport.Add(validPrisoner);
            }


            validExport = validExport.OrderBy(x => x.Name).ThenBy(x => x.Id).ToList();

            var sb = new StringBuilder();
            var xmlNamespaces = new XmlSerializerNamespaces(new[] {XmlQualifiedName.Empty});

            var serializer = new XmlSerializer(typeof(ExportPrisonerDto[]), new XmlRootAttribute("Prisoners"));
            serializer.Serialize(new StringWriter(sb), validExport.ToArray(), xmlNamespaces);

            return sb
                .ToString()
                .TrimEnd();

        }
    }
}