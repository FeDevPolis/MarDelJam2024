using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;


public class Person : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    // Start is called before the first frame update
    void Start()
    {
        RequestManager.NewRequest.AddListener(MoveToPlace);
        Entregar.PersonCanLeave.AddListener(LeavePlace);
    }
    

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MoveToPlace(Request request)
    {
        transform.position = new Vector2(-4f,0.9f);
        transform.DOMoveX(3f,0.8f);
        transform.DOMoveY(0.8f,0.2f).SetEase(Ease.InSine).SetLoops(4,LoopType.Yoyo);
    }

    public void LeavePlaceNoComplete()
    {
        transform.DOMoveX(-3f,0.8f);
        transform.DOMoveY(0.8f,0.2f).SetEase(Ease.InSine).SetLoops(4,LoopType.Yoyo);
    }

    public void LeavePlace()
    {
        transform.DOMoveX(-3f,0.8f).onComplete=PersonLeft;
        transform.DOMoveY(0.8f,0.2f).SetEase(Ease.InSine).SetLoops(4,LoopType.Yoyo);
    }

    private void PersonLeft()
    {
        RequestManager.Instance.StartNewRequest();
    }
}
