﻿using System;

using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;





namespace FestivalManager.Entities.Factories
{
	using Contracts;
	using Entities.Contracts;
	using Sets;

	public class SetFactory : ISetFactory
	{
		public ISet CreateSet(string name, string type)
		{
		    Type typeOfSet = Assembly.GetCallingAssembly().GetTypes().FirstOrDefault(t => t.Name.Equals(type));

		    ISet instance = (ISet) Activator.CreateInstance(typeOfSet, new object[] {name});

		    return instance;
		}
	}




}
