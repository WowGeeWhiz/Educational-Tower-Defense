using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIScript : MonoBehaviour
{
    public GameObject generateButton;
    public GameObject killButton;
    public GameObject acceptButton;
    public GameObject documentButton;
    public TMP_Text cancerKilled;

    Button generate;
    public GameManager gameManager;

    public Slider healthBar;
    public GameObject lossMenu;

    public string nextLevelName;

    private void Start()
    {
        gameManager = FindAnyObjectByType<GameManager>();

        generateButton.GetComponent<Button>().onClick.AddListener(() => { gameManager.GenerateCell(); });
        killButton.GetComponent<Button>().onClick.AddListener( () => { gameManager.KillCell(); });
        acceptButton.GetComponent<Button>().onClick.AddListener ( () => { gameManager.AcceptCell(); });
        documentButton.GetComponent<Button>().onClick.AddListener( () => { gameManager.AcquireDocuments(); });
        healthBar.maxValue = gameManager.GetMistakesAllowed();
        healthBar.value = healthBar.maxValue;
        UpdateCancerKilled();
    }
    public void UpdateHealthBar()
    {
        healthBar.value = healthBar.maxValue - gameManager.GetCancerAllowed() - gameManager.GetHealthyKilled();
        if (healthBar.value == 0 )
        {
            lossMenu.SetActive( true );
        }
    }
    public void UpdateCancerKilled()
    {
        cancerKilled.text = gameManager.GetCancerKilled() + "/" + gameManager.GetCancerKillsNeeded();
    }
    public void GenerateButton()
    {
        generateButton.SetActive(false);
        killButton.SetActive(true);
        acceptButton.SetActive(true);
        documentButton.SetActive(true);
    }
    public void DocumentButton()
    {
        documentButton.SetActive(false);
    }
    public void ChoiceButtons()
    {
        documentButton.SetActive(false);
        killButton.SetActive(false);
        acceptButton.SetActive(false);
        generateButton.SetActive(true);
    }
    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().ToString());
    }
    public void NextLevel()
    {
        SceneManager.LoadScene(nextLevelName);
    }
    public void QuitToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
