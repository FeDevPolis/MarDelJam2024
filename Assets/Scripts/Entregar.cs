using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class Entregar : MonoBehaviour
{

    public static UnityEvent PersonCanLeave;
    [SerializeField] SpriteRenderer buttonSprite;
    [SerializeField] Sprite buttonSpriteOff;
    [SerializeField] Sprite buttonSpriteOn;

    
    [SerializeField] List<GameObject> AllFolletos;
    [SerializeField] List<GameObject> currentWeekFolletos;

    [SerializeField] private GameObject DNI;

    private void Awake()
    {
        PersonCanLeave = new UnityEvent();
    }

    private void Start()
    {
        RequestManager.RequestResult.AddListener(GiveFolletos);
        RequestManager.NewRequest.AddListener(NewRequest);
        GameManager.StartWeekEvent.AddListener(StartNewWeek);
        DNI.SetActive(false);

        currentWeekFolletos.Add(AllFolletos[0]);
        currentWeekFolletos.Add(AllFolletos[1]);
        currentWeekFolletos.Add(AllFolletos[2]);
        currentWeekFolletos.Add(AllFolletos[3]);
        currentWeekFolletos.Add(AllFolletos[4]);

        foreach(GameObject folleto in AllFolletos)
        {
            folleto.GetComponent<SpriteRenderer>().enabled=false;
            folleto.transform.position = new Vector2(-20,-20);
        }
    }

    public void GiveFolletos(bool hasSelected,int score)
    {
        var sequence = DOTween.Sequence();
        List<GameObject> folletos = RequestManager.Instance.folletosMostrador;
        foreach(GameObject folleto in folletos)
        {
            sequence.Append(folleto.transform.DOMove(new Vector2(3,1),0.5f).SetEase(Ease.InBack).OnComplete(()=>
            {
                CompleteFolleto(folleto);
            }));
            
        }
        sequence.Append(DNI.transform.DOMove(new Vector2(4,0),0.5f));
        sequence.onComplete=AllFolletosDone;
    }

    public void CompleteFolleto(GameObject folleto)
    {
        folleto.GetComponent<SpriteRenderer>().enabled=false;
    }

    private void StartNewWeek()
    {
        foreach(GameObject folleto in AllFolletos)
        {
            folleto.GetComponent<SpriteRenderer>().enabled=false;
            folleto.transform.position = new Vector2(-20,-20);
        }
        if(WeekManager.currentWeek==2)
        {
            currentWeekFolletos.Add(AllFolletos[5]);
            currentWeekFolletos.Add(AllFolletos[6]);
        }
        else if(WeekManager.currentWeek==3)
        {
            currentWeekFolletos.Add(AllFolletos[7]);
            currentWeekFolletos.Add(AllFolletos[8]);
            currentWeekFolletos.Add(AllFolletos[9]);
        }
        RestockFolletos();
    }

    private void NewRequest(Request request)
    {
        if(WeekManager.currentWeek>=2)
        {
            StartCoroutine(EntregarDNI(request));
        }
    }

    IEnumerator EntregarDNI(Request request)
    {
        yield return new WaitForSeconds(1f);
        DNI.SetActive(true);
        DNI.transform.position = new Vector2(4,0);
        DNI.transform.DOMove(new Vector2(4,-2),0.1f);
        DNI.GetComponent<DNI>().SetDNI(request);
    }

    private void OnMouseDown()
    {
        if(!GameManager.Instance.OnTutorial)
        {
            buttonSprite.sprite = buttonSpriteOn;
            RequestManager.SendFolletos.Invoke();
        }
        else
        {
            GameManager.Instance.SkipTutorial=true;
        }
    }

    private void OnMouseUp()
    {
        buttonSprite.sprite=buttonSpriteOff;
    }

    public void AllFolletosDone()
    {
        DNI.SetActive(false);
        PersonCanLeave.Invoke();
        var sequence = DOTween.Sequence();
        foreach(GameObject folleto in RequestManager.Instance.folletosMostrador)
        {
            folleto.GetComponent<SpriteRenderer>().enabled=true;
            folleto.transform.position = new Vector2(0,-6);
            folleto.GetComponent<MoveFolleto>().currentFolletoLocation=FolletoLocation.pared;
            Vector2 newPosition = new Vector2(UnityEngine.Random.Range(-9.0f,-2.6f),UnityEngine.Random.Range(3.6f,0.2f));
            sequence.Append(folleto.transform.DOMove(newPosition,0.5f));
        }
    }

    public void RestockFolletos()
    {
        var sequence = DOTween.Sequence();
        foreach(GameObject folleto in currentWeekFolletos)
        {
            folleto.GetComponent<SpriteRenderer>().enabled=true;
            folleto.transform.position = new Vector2(0,-6);
            folleto.GetComponent<MoveFolleto>().currentFolletoLocation=FolletoLocation.pared;
            Vector2 newPosition = new Vector2(UnityEngine.Random.Range(-9.0f,-2.6f),UnityEngine.Random.Range(3.6f,0.2f));
            sequence.Append(folleto.transform.DOMove(newPosition,0.5f));
        }
    }
}
