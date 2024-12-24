using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiveDNI : MonoBehaviour
{
    [SerializeField] private GameObject DNI;


    private void Start()
    {
        RequestManager.NewRequest.AddListener(NewRequest);
    }

    private void NewRequest(Request request)
    {
        if(WeekManager.currentWeek>=2)
        {
            DNI.transform.position = new Vector2(0,0);
        }
    }

}
