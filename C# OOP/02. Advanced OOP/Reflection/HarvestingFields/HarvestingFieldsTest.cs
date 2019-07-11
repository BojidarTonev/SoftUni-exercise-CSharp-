using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace P01_HarvestingFields
{
    using System;
    public class HarvestingFieldsTest
    {
        private StringBuilder sb;
        private List<FieldInfo> result;

        public HarvestingFieldsTest()
        {
            this.sb = new StringBuilder();
            this.result = new List<FieldInfo>();
        }

        internal void ProcessRawData()
        {
            var fields =
                typeof(HarvestingFields).GetFields(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);

            string input = Console.ReadLine();
            while (input != "HARVEST")
            {
                switch (input)
                {
                    case "protected":
                        result = fields.Where(f => f.IsFamily).ToList();
                        Console.WriteLine(this.ResultAppender(result));
                        break;
                    case "public":
                        result = fields.Where(f => f.IsPublic).ToList();
                        Console.WriteLine(this.ResultAppender(result));
                        break;
                    case "private":
                        result = fields.Where(f => f.IsPrivate).ToList();
                        Console.WriteLine(this.ResultAppender(result));
                        break;
                    case "all":
                        Console.WriteLine(this.ResultAppender(fields));
                        break;
                    default:
                        break;
                }

                result.Clear();
                sb.Clear();
                input = Console.ReadLine();
            }
        }

        private string ResultAppender(IEnumerable<FieldInfo> collection)
        {
            foreach (var field in collection)
            {
                var modifier = field.Attributes.ToString().ToLower();
                if (modifier == "family")
                {
                    modifier = "protected";
                }

                sb.AppendLine($"{modifier} {field.FieldType.Name} {field.Name}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
