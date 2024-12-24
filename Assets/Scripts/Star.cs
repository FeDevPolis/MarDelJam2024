using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Star : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Start star");
        transform.position = new Vector2(3,1.5f);
        Vector2 newPosition = new Vector2(UnityEngine.Random.Range(-3f,3.0f),1.5f);
        newPosition+=(Vector2)transform.position;
         var sequence = DOTween.Sequence();
        sequence.Append( transform.DOMove(newPosition,1.0f).SetEase(Ease.OutBack));
        sequence.Append(transform.DOMove(new Vector2(0,-10f),1.0f).SetEase(Ease.InSine));
        sequence.onComplete=CompleteAnimation;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CompleteAnimation()
    {
        Destroy(this.gameObject);
    }
}
