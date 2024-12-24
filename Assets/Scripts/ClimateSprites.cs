using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClimateSprites : MonoBehaviour
{
    public List<SpriteRenderer> climateSprites;
    public Sprite sunny;
    public Sprite cloudy;
    public Sprite rainy;
    public Sprite stormy;
    public Sprite windy;

    private void Start()
    {
        GameManager.StartWeekEvent.AddListener(SetClimateSprites);
    }

    public void SetClimateSprites()
    {
        for(int i=0;i<7;i++)
        {
            Sprite climateSprite=null;
            Days day = (Days)i;
            if(Climate.GetClimate(day)==ClimateType.Sunny)
            {
                climateSprite=sunny;
            }
            else if(Climate.GetClimate(day)==ClimateType.Cloudy)
            {
                climateSprite=cloudy;
            }
            else if(Climate.GetClimate(day)==ClimateType.Rainy)
            {
                climateSprite=rainy;
            }
            else if(Climate.GetClimate(day)==ClimateType.Stormy)
            {
                climateSprite=stormy;
            }
            else if(Climate.GetClimate(day)==ClimateType.Windy)
            {
                climateSprite=windy;
            }
            climateSprites[i].sprite=climateSprite;
        }
    }

}
