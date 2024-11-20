using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIScript : MonoBehaviour
{
    public GameObject generateButton;
    public GameObject killButton;
    public GameObject acceptButton;
    public GameObject documentButton;
    public TMP_Text cancerKilled;

    public GameManager gameManager;

    public Slider healthBar;
    private void Start()
    {
        gameManager = FindAnyObjectByType<GameManager>();
        healthBar.maxValue = gameManager.GetMistakesAllowed();
        healthBar.value = healthBar.maxValue;
    }
    public void UpdateHealthBar()
    {
        healthBar.value = healthBar.maxValue - gameManager.GetCancerAllowed();
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
}
