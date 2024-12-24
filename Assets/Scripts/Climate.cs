using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ClimateType
{
	Sunny,
	Cloudy,
	Rainy,
	Stormy,
	Windy
}

public class Climate
{
	public static Dictionary <Days,ClimateType> ClimateDays;
	

	public static void CreateClimate()
	{
		ClimateDays = new Dictionary<Days, ClimateType>();
        Array climateValues = Enum.GetValues(typeof(ClimateType));

        foreach (Days day in Enum.GetValues(typeof(Days)))
		{
            ClimateType randomClimate = (ClimateType)climateValues.GetValue(UnityEngine.Random.Range(0, climateValues.Length));
            ClimateDays[day] = randomClimate;
        }
	}

	public static ClimateType GetClimate(Days day)
	{
		return ClimateDays[day];
	}
}
