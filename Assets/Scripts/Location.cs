using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Location:ScriptableObject
{
	public LocationType type;
	public List<Days> days;
	public int openHour;
	public int closeHour;
	public List<ClimateType> acceptClimates;
	public bool adult;
	public bool animal;
}
