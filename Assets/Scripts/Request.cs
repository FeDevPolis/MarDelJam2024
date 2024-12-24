using System;
using System.Collections.Generic;
using UnityEngine;


public enum LocationType
{
	Torreon,
	MuseoMAR,
	Puerto,
	Playa,
	JuegoAgua,
	Boliche,
	Casino,
	Acuario,
	Quilmes,
	CasaPuente
}

public enum Days
{
	Lunes,
	Martes,
	Miercoles,
	Jueves,
	Viernes,
	Sabado,
	Domingo
}


public class Request
{
	bool requestHour;
	bool requestDay;
	bool requestAnimal;

	int hour;
	Days day;
	DateTime dayOfBirth;
	public int personType;
	bool adult;
	
	public string dayOfBirthText {get {return dayOfBirth.Day+"/"+dayOfBirth.Month+"/"+dayOfBirth.Year;}}
	
	public Request(bool hasHour,bool hasDay, bool hasRain, bool hasAnimal)
	{
		if(hasHour)
		{
			requestHour = true;
			hour = UnityEngine.Random.Range(0, 24);
		}
		if(hasDay)
		{
			requestDay = true;
			int randomDay = UnityEngine.Random.Range(0, Enum.GetValues(typeof(Days)).Length);
			Console.WriteLine(randomDay);
			day = (Days)randomDay;
		}
		if (hasAnimal)
		{
			requestAnimal = UnityEngine.Random.Range(0, 2) == 1;
		}
		if(WeekManager.currentWeek>=2)
		{
			personType = UnityEngine.Random.Range(1,7);
		}
		else if(WeekManager.currentWeek==1)
			personType = UnityEngine.Random.Range(1,6);
		adult = true;
		if(personType == 6)
			adult = UnityEngine.Random.Range(0, 2) == 1;
		if(personType == 5)
		{
			requestAnimal = UnityEngine.Random.Range(0,2)==1;
		}
		if(adult)
		{
			int year = 2006 - UnityEngine.Random.Range(0, 60);
			int month =  UnityEngine.Random.Range(1, 13);
			int day = UnityEngine.Random.Range(1, 29);
			dayOfBirth = new DateTime(year, month, day);
		}
		else
		{
			int year = 2006 + UnityEngine.Random.Range(0, 5);
			int month = UnityEngine.Random.Range(1, 13);
			int day = UnityEngine.Random.Range(1, 29);
			dayOfBirth = new DateTime(year, month, day);
		}
		Debug.Log("nacimiento: "+dayOfBirth.ToString());
		Debug.Log("nacimiento 2: "+dayOfBirthText.ToString());
	}

	public int CheckRequest(Location location)
	{
		int result = 0;

		if(location.days.Contains(day))
		{
			result+=1;
			if(location.openHour< location.closeHour)
			{
				if(hour>= location.openHour && hour <=location.closeHour)
				{
					result++;
				}
				else
				{
					result--;
				}
			}
			else if(location.openHour< location.closeHour)
			{
				if(hour<= location.openHour || hour >=location.closeHour)
				{
					result++;
				}
				else
				{
					result--;
				}
			}
			if(location.acceptClimates.Contains( Climate.GetClimate(day)))
			{
				result+=1;
			}
			else
			{
				result-=1;
			}
		}
		else
		{
			result-=1;
		}
		
		if(requestAnimal)
		{
			if(location.animal)
			{
				result+=1;
			}
			else 
			{
				result-=1;
			}
		}
		if(location.adult)
		{
			if(adult)
			{
				result++;
			}
			else
			{
				result-=1;
			}
		}
		return result;
	}

	public string RequestDialogue()
	{
		string result = "Hola buenos dias, quería un lugar ";
		if(requestDay)
		{
			result += "el dia " + day.ToString()+" ";
		}
		if(requestHour)
		{
			result += "que este abierto a las " + hour+":00 ";
		}
		if(requestAnimal)
		{
			result += "y que pueda llevar a mi perrito"+" ";
		}
		return result;
	}
}
