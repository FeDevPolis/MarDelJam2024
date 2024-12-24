using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeekManager : MonoBehaviour
{
    public static int currentWeek;
    public int currentScore;
    [SerializeField] private float timeLimit;
    [SerializeField] private float passedTime;
    private bool weekStarted;
    private bool weekEnded;

    private void Awake()
    {
        currentWeek=0;
    }

    private void Start()
    {

        RequestManager.RequestResult.AddListener(RequestResult);
        GameManager.StartWeekEvent.AddListener(StartWeek);
        weekStarted=false;

    }

    private void StartWeek()
    {
        Debug.Log("Empezando la semana");
        timeLimit=120f;
        passedTime=0f;
        currentScore=0;
        currentWeek++;
        Debug.Log("week "+currentWeek);
        weekStarted=true;
        weekEnded=false;

    }

    private void Update()
    {
        if(weekStarted && !weekEnded)
        {
            passedTime+= Time.deltaTime;
            if(passedTime>=timeLimit)
            {
                EndWeekTime();   
                weekEnded=true;
            }
        }
    }

    private void EndWeekTime()
    {
        Debug.Log("Se termino el dia");
        Debug.Log("La puntuación es:" + currentScore);
        GameManager.EndTimeEvent.Invoke();
    }

    private void RequestResult(bool hasSelected, int score)
    {
        currentScore+=score;
    }
    
}
