using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EndScreen : MonoBehaviour
{
    public GameObject splashSprite;
    public GameObject continueButton;
    public TextMeshPro scoreText;
    public TextMeshPro rendimientoText;
    public GameObject cuaderno;

    [SerializeField] private WeekManager weekManager;
    [SerializeField] private GameManager gameManager;
    

    private void Start()
    {
        //GameManager.StartWeekEvent.AddListener(HideEndScreen);
        GameManager.EndWeekEvent.AddListener(ShowEndScreen);
        GameManager.FinishPerformanceEvent.AddListener(HideEndScreen);
    }

    private void HideEndScreen()
    {
        continueButton.SetActive(false);
        splashSprite.GetComponent<SpriteRenderer>().gameObject.SetActive(false);
        rendimientoText.gameObject.SetActive(false);
        scoreText.gameObject.SetActive(false);
        cuaderno.SetActive(false);

    }

    private void ShowEndScreen()
    {
        continueButton.SetActive(true);
        splashSprite.GetComponent<SpriteRenderer>().gameObject.SetActive(true);
        rendimientoText.gameObject.SetActive(true);
        scoreText.gameObject.SetActive(true);
        cuaderno.SetActive(true);
        scoreText.text="Clientes satisfechos: " + RequestManager.Instance.succefullClients+"\nClientes Enojados: "+ RequestManager.Instance.angryClientes+
        "\nPuntuacion semanal: "+weekManager.currentScore+"\nPuntuacion total: "+gameManager.totalScore;
        int highscore = Highscore.ReadHighscore();
        if(gameManager.totalScore>highscore)
        {
            Highscore.SaveHighscore(gameManager.totalScore);
            highscore=gameManager.totalScore;
        }
        if(WeekManager.currentWeek==3)
        {
            scoreText.text+="\nHighscore: "+ highscore;
        }
    }
}
