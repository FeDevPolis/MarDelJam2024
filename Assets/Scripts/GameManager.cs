using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    [SerializeField] private WeekManager weekManager;
    [SerializeField] private PersonRequest tutorialMan;
    public static GameManager Instance;

    public int totalScore;

    public static UnityEvent StartWeekEvent;
    public static UnityEvent EndTimeEvent;
    public static UnityEvent EndWeekEvent;
    public static UnityEvent FinishPerformanceEvent;
    public bool OnTutorial;
    public bool SkipTutorial;

    
	private void Awake()
	{
        StartWeekEvent = new UnityEvent();
        EndTimeEvent = new UnityEvent();
        EndWeekEvent = new UnityEvent();
        FinishPerformanceEvent = new UnityEvent();
		Climate.CreateClimate();

        Instance=this;
	}

	void Start()
    {
        Debug.Log("Start game");
        totalScore=0;
        EndWeekEvent.AddListener(EndWeek);
        StartCoroutine(tutorialMan.StartTutorial1());
        OnTutorial=true;
        SkipTutorial=false;
        FinishPerformanceEvent.AddListener(FinishPerformance);
    }

    void Update()
    {
        
    }

    void OnDestroy()
    {
        StopAllCoroutines();
    }

    private void FinishPerformance()
    {
        Debug.Log("finish" + WeekManager.currentWeek);
        OnTutorial=true;
        SkipTutorial=false;
        Debug.Log("week: "+OnTutorial);
        if(WeekManager.currentWeek==1)
        {
            StartCoroutine(tutorialMan.StartTutorial2());
        }
        else if(WeekManager.currentWeek==2)
        {
            StartCoroutine(tutorialMan.StartTutorial3());
        }
        else if(WeekManager.currentWeek==3)
        {
            if(totalScore>=100)
            {
                StartCoroutine(tutorialMan.StartCutsceneGood());
            }
            else 
            {
                StartCoroutine(tutorialMan.StartCutsceneBad());
            }
        }
    }

    private void EndWeek()
    {
        totalScore+=weekManager.currentScore;
    }
}
