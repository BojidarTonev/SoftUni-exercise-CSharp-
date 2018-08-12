using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using FastFood.Data;
using FastFood.DataProcessor.Dto.Export;
using FastFood.Models;
using FastFood.Models.Enums;
using Newtonsoft.Json;
using Remotion.Linq.Parsing.ExpressionVisitors.Transformation.PredefinedTransformations;
using Formatting = Newtonsoft.Json.Formatting;

namespace FastFood.DataProcessor
{
	public class Serializer
	{
		public static string ExportOrdersByEmployee(FastFoodDbContext context, string employeeName, string orderType)
		{
		    OrderType order;
		    var isvalidOrder = Enum.TryParse(orderType, out order);

		    var employeeOrders = context.Employees
		        .Select(e => new
		        {
		            Name = e.Name,
		            Orders = e.Orders
		                .Where(o => o.Type == order)
		                .Select(o => new
		                {
		                    Customer = o.Customer,
		                    Items = o.OrderItems.Select(oi => new
		                    {
		                        Name = oi.Item.Name,
		                        Price = oi.Item.Price,
		                        Quantity = oi.Quantity
		                    }),
		                    TotalPrice = o.TotalPrice
		                })
		                .OrderByDescending(o => o.TotalPrice)
		                .ThenByDescending(o => o.Items.Count())
		        })
		        .FirstOrDefault(e => e.Name.Equals(employeeName, StringComparison.OrdinalIgnoreCase));


            var jsonString = JsonConvert.SerializeObject(employeeOrders, Formatting.Indented);
		    return jsonString;


		}

		public static string ExportCategoryStatistics(FastFoodDbContext context, string categoriesString)
		{
		    var categoriesNames = categoriesString.Split(',');

		    var stats = context.Categories
		        .Where(c => categoriesNames.Any(n => n.Equals(c.Name, StringComparison.OrdinalIgnoreCase)))
		        .Select(c => new
		        {
		            Name = c.Name,
		            TopItem = c.Items
		                .OrderByDescending(i => i.OrderItems
		                    .Sum(oi => oi.Quantity * oi.Item.Price))
		                .FirstOrDefault()
		        })
		        .Select(c => new CategoryDto
		        {
		            Name = c.Name,
		            Item = new MostPopularItemDto
		            {
		                Name = c.TopItem.Name,
		                TimesSold = c.TopItem.OrderItems
		                    .Select(oi => oi.Quantity)
		                    .Sum(),
		                TotalMade = c.TopItem.OrderItems
		                    .Sum(oi => oi.Quantity * oi.Item.Price)
		            }
		        })
		        .OrderByDescending(c => c.Item.TotalMade)
		        .ThenByDescending(c => c.Item.TimesSold)
		        .ToArray();

		    var sb = new StringBuilder();

		    var serializer = new XmlSerializer(typeof(CategoryDto[]), new XmlRootAttribute("Categories"));
		    serializer.Serialize(new StringWriter(sb), stats, new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty }));

		    var result = sb.ToString();
		    return result;
        }
	}
}