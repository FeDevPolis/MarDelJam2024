using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    [SerializeField] private GameObject PauseObject;

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
        PauseGame();
    }

    private void PauseGame()
    {
        PauseObject.SetActive(true);
        Time.timeScale=0;
    }



}
