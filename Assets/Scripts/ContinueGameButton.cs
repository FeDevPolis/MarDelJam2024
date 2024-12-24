using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContinueGameButton : MonoBehaviour
{

    [SerializeField] private GameObject PauseObject;
    
    private void OnMouseDown()
    {
        UnPause();
    }

    private void UnPause()
    {
        Time.timeScale=1;
        PauseObject.SetActive(false);
    }
}
