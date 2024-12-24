using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Unity.VisualScripting;
using UnityEngine;

public class ExpandSprite : MonoBehaviour
{
    private GameObject expandObject;
    public float scale;

    private bool hasSelected;

    void Start()
    {
        expandObject = this.gameObject;
    }
    

    private void OnMouseEnter()
    {
        expandObject =  Instantiate(this.gameObject);
        Destroy(expandObject.GetComponent<ExpandSprite>());
        if(expandObject.GetComponent<Collider2D>()!=null)
        {
            Destroy(expandObject.GetComponent<Collider2D>());
        }
        for(int i =0;i<transform.childCount;i++)
        {
            Transform child = transform.GetChild(i);
            child.gameObject.SetActive(false);

        }
        if(GetComponent<SpriteRenderer>()!=null)
        {
            GetComponent<SpriteRenderer>().enabled=false;
        }
        this.gameObject.SetActive(true);
        expandObject.transform.localScale= transform.localScale*scale;
    }

    private void OnMouseExit()
    {
        Destroy(expandObject);
        for(int i =0;i<transform.childCount;i++)
        {
            Transform child = transform.GetChild(i);
            child.gameObject.SetActive(true);
        }
        if(GetComponent<SpriteRenderer>()!=null)
        {
            GetComponent<SpriteRenderer>().enabled=true;
        }
    }


    // Update is called once per frame
    void Update()
    {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if(hasSelected)
        {
            transform.position = mousePosition;
            expandObject.transform.position=mousePosition;
        }
        if(hasSelected && Input.GetMouseButtonUp(0))
        {
            hasSelected=false;
            transform.DOMove(new Vector2(transform.position.x,-2f),0.2f).SetEase(Ease.OutQuad);
        }
    }

    private void OnMouseDown()
    {
        hasSelected=true;
    }
}
