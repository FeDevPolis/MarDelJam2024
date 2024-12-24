using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class RequestManager : MonoBehaviour
{
    public static UnityEvent<Request> NewRequest;
    public static UnityEvent SendFolletos;
    public static UnityEvent<bool,List<Location>> SelectedFolletoEvent;
    public static UnityEvent<bool,int> RequestResult;
    private List<Location> selectedLocations;
    public List<GameObject> folletosMostrador;
    private Request currentRequest;

    public int succefullClients;
    public int angryClientes;
    public int score;

    public static RequestManager Instance{get; private set;}

    private bool AcceptsPerson;

    [SerializeField] GameObject starPrefab;

    private void Awake()
    {

      Instance=this;

      NewRequest = new UnityEvent<Request>();
      SendFolletos = new UnityEvent();
      SelectedFolletoEvent = new UnityEvent<bool, List<Location>>();
      RequestResult = new UnityEvent<bool, int>();

      SelectedFolletoEvent.AddListener(SelectedFolletos);
      SendFolletos.AddListener(SendFolleto);
      

      selectedLocations = new List<Location>();
      folletosMostrador = new List<GameObject>();
    }

    void Start()
    {
      GameManager.StartWeekEvent.AddListener(StartWeek);
      GameManager.EndTimeEvent.AddListener(EndWeekTime);
      AcceptsPerson=true;
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.P))
        {
          currentRequest = new Request(true,true,false,false);
          NewRequest.Invoke(currentRequest);
        }
    }

    private void StartWeek()
    {
      AcceptsPerson=true;
      succefullClients=0;
      angryClientes=0;
      score=0;
      selectedLocations.Clear();
      folletosMostrador.Clear();
      StartNewRequest();
    }

    public void StartNewRequest()
    {
      if(AcceptsPerson)
      {
        selectedLocations.Clear();
        folletosMostrador.Clear();
        currentRequest = new Request(true,true,false,false);
        NewRequest.Invoke(currentRequest);
      }
      else
      {
        GameManager.EndWeekEvent.Invoke();
      }
    }

    public void AddFolleto(Folleto folleto)
    {
      if(!selectedLocations.Contains(folleto.location))
      {
        Debug.Log("Adding location");
        selectedLocations.Add(folleto.location);
      }
      if(!folletosMostrador.Contains(folleto.gameObject))
        folletosMostrador.Add(folleto.gameObject);
    }

    public void RemoveFolleto(Folleto folleto)
    {
      Debug.Log("Remove location");
      if(selectedLocations.Contains(folleto.location))
        selectedLocations.Remove(folleto.location);
      if(folletosMostrador.Contains(folleto.gameObject))
        folletosMostrador.Remove(folleto.gameObject);
    }


    public void SendFolleto()
    {
      SelectedFolletos(true,selectedLocations);
    }
    public void SelectedFolletos(bool hasSelected, List<Location> locations)
    {
      if(locations.Count>0)
      {
        score = 0;
        Debug.Log(locations.Count);
        foreach (Location location in locations)
        {
          score += currentRequest.CheckRequest(location);
        }
        if(score<0)
        {
          angryClientes++;
        }
        else if(score>=1)
        {
          succefullClients++;
        }
        Debug.Log("Score: "+score);
        StartCoroutine(starRoutine(score));
        RequestResult.Invoke(true,score);
      }
      else
      {
        RequestResult.Invoke(false,0);
      }
    }

    IEnumerator starRoutine(int score)
    {
      for(int i=0;i<score/2;i++)
        {
          Instantiate(starPrefab);
          yield return new WaitForSeconds(0.2f);
        }
    }

    private void EndWeekTime()
    {
      AcceptsPerson=false;
    }
}
