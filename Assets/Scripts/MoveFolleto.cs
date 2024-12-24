using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Unity.VisualScripting;
using UnityEngine;


public enum FolletoLocation
{
    mostrador,
    pared
}

public class MoveFolleto : MonoBehaviour
{
    private Vector2 originalPosition;
    private bool hasSelected;
    private Folleto folleto;
    public FolletoLocation currentFolletoLocation;

    [SerializeField] List<GameObject> AllFolletos;
    [SerializeField] List<GameObject> currentWeekFolletos;
    
    // Start is called before the first frame update

    private void Awake()
    {
        folleto = GetComponent<Folleto>();
    }

    void Start()
    {
        currentFolletoLocation = FolletoLocation.pared;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if(hasSelected)
        {
            transform.position = mousePosition;
        }
        if(hasSelected && Input.GetMouseButtonUp(0))
        {
            if(transform.position.x>-1.8f)
            {
                 transform.DOMove(new Vector2(transform.position.x,-2f),0.2f).SetEase(Ease.OutQuad).OnComplete(()=>
                 {
                    if(currentFolletoLocation==FolletoLocation.mostrador)
                            RequestManager.Instance.AddFolleto(folleto);
                    else if(currentFolletoLocation==FolletoLocation.pared)
                            RequestManager.Instance.RemoveFolleto(folleto);

                 });
            }
            hasSelected=false;
        }
    }

    

    private void OnMouseDown()
    {
        hasSelected=true;
        originalPosition = transform.position;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag.Equals("mostrador"))
        {
            currentFolletoLocation = FolletoLocation.mostrador;
        }
        
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if(col.tag.Equals("mostrador"))
        {
            currentFolletoLocation = FolletoLocation.pared;
        }
    }

}
