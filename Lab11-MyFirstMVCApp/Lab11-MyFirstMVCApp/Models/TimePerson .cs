using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Lab11_MyFirstMVCApp.Models
{
    public class TimePerson
	{
		public int Year { get; set; }
		public string Honor { get; set; }
		public string Name { get; set; }
		public string Country { get; set; }
		public int BirthYear { get; set; }
		public int DeathYear { get; set; }
		public string Title { get; set; }
		public string Category { get; set; }
		public string Context { get; set; }

		/// <summary>
		/// The static method that is used to get the pathing and able to use from year and to year and use the cvs file that is in wwwroot folder. This will then read the file and instantiate timeperson to the list. From this list it will LINQ query to only grab years that user inputted.
		/// </summary>
		/// <param name="fromYear">From what year</param>
		/// <param name="toYear">To what year from Controller</param>
		/// <param name="path">Pathing from the controller</param>
		/// <returns>List of timeperson</returns>
		public static List<TimePerson> GetPersons(int fromYear, int toYear, string path)
		{
			List<TimePerson> timePeoples = new List<TimePerson>();

			string[] lines = File.ReadAllLines(path);

			foreach (var line in lines)
			{
				if (line != "Year,Honor,Name,Country,Birth Year,Death Year,Title,Category,Context")
				{
					TimePerson timePeople = new TimePerson();
					var lino = line.Split(",");
					Console.WriteLine(lino);
					timePeople.Year = int.Parse(lino[0]);
					timePeople.Honor = lino[1];
					timePeople.Name = lino[2];
					timePeople.Country = lino[3];
					if (Int32.TryParse(lino[4], out int _))
					{
						timePeople.BirthYear = int.Parse(lino[4]);
					}
					if (Int32.TryParse(lino[5], out int _))
					{
						timePeople.DeathYear = int.Parse(lino[5]);
					}
					timePeople.Title = lino[6];
					timePeople.Category = lino[7];
					timePeople.Context = lino[8];

					timePeoples.Add(timePeople);
				}
			}

			List<TimePerson> filterPeople = timePeoples.Where(p => p.Year > fromYear && p.Year < toYear)
				.Select(p => p).ToList();

			return filterPeople;

		}
	}

	
}
