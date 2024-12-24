using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class DNI : MonoBehaviour
{
    [SerializeField] public TextMeshPro dayOfBirthText;
    [SerializeField] public SpriteRenderer spriteDNI;

    [SerializeField] public List<Sprite> clientsDNI;

    public void SetDNI(Request request)
    {
        this.dayOfBirthText.text = request.dayOfBirthText;
        spriteDNI.sprite = clientsDNI[request.personType-1];
    }
}
