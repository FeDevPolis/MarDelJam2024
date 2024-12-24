using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContinueButton : MonoBehaviour
{

    private void OnMouseDown()
    {
        GameManager.FinishPerformanceEvent.Invoke();
    }
}
