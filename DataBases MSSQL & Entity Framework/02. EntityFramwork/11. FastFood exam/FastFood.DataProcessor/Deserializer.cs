using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Xml.Serialization;
using FastFood.Data;
using FastFood.DataProcessor.Dto.Import;
using FastFood.Models;
using FastFood.Models.Enums;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using DataAnotations = System.ComponentModel.DataAnnotations;

namespace FastFood.DataProcessor
{
	public static class Deserializer
	{
		private const string FailureMessage = "Invalid data format.";
		private const string SuccessMessage = "Record {0} successfully imported.";

		public static string ImportEmployees(FastFoodDbContext context, string jsonString)
		{
		    var deserializedEmployees = JsonConvert.DeserializeObject<EmployeeDto[]>(jsonString);

		    var sb = new StringBuilder();

		    var validEmployees = new List<Employee>();
		    var positions = new HashSet<Position>();
		    foreach (var employeeDto in deserializedEmployees)
		    {
		        if (!IsValid(employeeDto))
		        {
		            sb.AppendLine(FailureMessage);
		            continue;
		        }

		        var position = positions
		            .FirstOrDefault(p => p.Name.Equals(employeeDto.Position, StringComparison.OrdinalIgnoreCase));
		        if (position == null)
		        {
		            position = new Position { Name = employeeDto.Position };

		            positions.Add(position);
		        }

		        var readyEmployee = new Employee
		        {
		            Name = employeeDto.Name,
		            Age = employeeDto.Age,
		            Position = position
		        };

		        sb.AppendLine(string.Format(SuccessMessage, readyEmployee.Name));

		        validEmployees.Add(readyEmployee);
		    }

		    context.Employees.AddRange(validEmployees);
		    context.SaveChanges();

		    var result = sb.ToString();
		    return result;
        }

		public static string ImportItems(FastFoodDbContext context, string jsonString)
		{
			var sb = new StringBuilder();
		    var jsonItems = JsonConvert.DeserializeObject<ItemDto[]>(jsonString);

            var items = new List<Item>();
		    var categories = new List<Category>();
		    foreach (var itemDto in jsonItems)
		    {
		        if (!IsValid(itemDto) ||
		            items.Any(i => i.Name.Equals(itemDto.Name, StringComparison.OrdinalIgnoreCase)))
                {
		            sb.AppendLine(FailureMessage);
                    continue;
		        }

		        var category = categories
		            .FirstOrDefault(c => c.Name == itemDto.Category);
		        if (category == null)
		        {
		            category = new Category()
		            {
                        Name = itemDto.Category
		            };
                    categories.Add(category);
		        }

                var item = new Item()
                {
                    Category = category,
                    Name = itemDto.Name,
                    Price = itemDto.Price
                };

                items.Add(item);
		        sb.AppendLine(string.Format(SuccessMessage, item.Name));
		    }
            context.Items.AddRange(items);
		    context.SaveChanges();

		    return sb
		        .ToString()
		        .TrimEnd();
		}

		public static string ImportOrders(FastFoodDbContext context, string xmlString)
		{
		    var sb = new StringBuilder();
		    var serializer = new XmlSerializer(typeof(OrderDto[]), new XmlRootAttribute("Orders"));
		    var deserialiedOrders = (OrderDto[])serializer.Deserialize(new StringReader(xmlString));

		    var orders = new List<Order>();

		    foreach (var orderDto in deserialiedOrders)
		    {
		        var orderItems = new List<OrderItem>();
		        bool areItemsValid = true;
		        if (!IsValid(orderDto))
		        {
		            sb.AppendLine(FailureMessage);
                    continue;
		        }

		        foreach (var itemDto in orderDto.Items)
		        {
		            var item = context.Items
		                .FirstOrDefault(i => i.Name == itemDto.Name);

		            if (!IsValid(itemDto) || item == null)
		            {
		                areItemsValid = false;
		                break;
		            }

                    var orderItem = new OrderItem()
                    {
                        Item = item,
                        Quantity = itemDto.Quantity
                    };

                    orderItems.Add(orderItem);
		        }

		        var employee = context.Employees
		            .FirstOrDefault(e => e.Name == orderDto.EmployeeName);

		        DateTime date;
		        bool IsValidDate = DateTime.TryParseExact(orderDto.DateTime,
                    "dd/MM/yyyy HH:mm",
		            CultureInfo.InvariantCulture,
		            DateTimeStyles.None,
		            out date);

		        if (!areItemsValid || employee == null || !IsValidDate)
		        {
		            sb.AppendLine(FailureMessage);
		            continue;
		        }

		        var order = new Order
		        {
		            Customer = orderDto.Customer,
		            Employee = employee,
		            DateTime = date,
		            Type = orderDto.Type,
		            OrderItems = orderItems
		        };

		        sb.AppendLine($"Order for {order.Customer} on {orderDto.DateTime} added");

                orders.Add(order);
		    }

            context.Orders.AddRange(orders);
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