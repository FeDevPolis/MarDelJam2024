using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoBackButton : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnMouseDown()
    {
        GoBackGame();
    }

    public void GoBackGame()
    {
        Time.timeScale=1;
        MenuManager.LoadMenu();
    }
}
