using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Folleto : MonoBehaviour
{
    public BoxCollider2D colliderFolleto;
    public Location location;
    public Sprite versionChica;
    public Sprite versionGrande;
    private GameObject expandObject;

    public float escala;

    private void Awake()
    {
        colliderFolleto = GetComponent<BoxCollider2D>();
    }


    private void OnMouseOver()
    {
        if(Input.GetMouseButtonDown(0))
        {
            
        }
    }

    private void OnMouseEnter()
    {
        expandObject =  Instantiate(this.gameObject);
        expandObject.transform.SetParent(this.transform);
        Destroy(expandObject.GetComponent<Folleto>());
        if(expandObject.GetComponent<Collider2D>()!=null)
        {
            Destroy(expandObject.GetComponent<Collider2D>());
        }
        SpriteRenderer spriteRenderer =  expandObject.GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = versionGrande;
        spriteRenderer.sortingOrder=10;
        expandObject.transform.localScale= transform.localScale*escala;
    }

    private void OnMouseExit()
    {
        Destroy(expandObject);
    }

}
