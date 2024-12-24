using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotonCreditos : MonoBehaviour
{
    [SerializeField] GameObject canvas;
    [SerializeField] GameObject canvasCreditos;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void PressButton()
    {
        canvasCreditos.SetActive(true);
        canvas.SetActive(false);
    }

    public void BackMenu()
    {
        canvas.SetActive(true);
        canvasCreditos.SetActive(false);
    }

}
