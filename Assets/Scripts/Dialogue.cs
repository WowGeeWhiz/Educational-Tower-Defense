using NUnit.Framework;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Dialogue : MonoBehaviour
{
    public TMP_Text text;
    List<TMP_Text> textHolder = new List<TMP_Text>();
    int textBoxes = 0;
    GameManager gameManager;

    
    public string[] cellResponses = { "I can’t wait to go to ", "Looking forward to working at the " };
    public string[] cellExcuses = { "" };
    public string[] playerResponses = { "Next Person in line", "Proteins Please," };
    public string[] negativePlayerResponses = { "Healthy cells only", "Not this time", "I don’t think so" };
    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindAnyObjectByType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        //cellText
    }
    public void playerResponse(int response)
    {
        //TMP_Text tempText = Instantiate(text, this.gameObject.transform);
        //tempText.text = playerResponses[response];
        
    }
    public void negativePlayerResponse()
    {
        //TMP_Text tempText = Instantiate(text, this.gameObject.transform);
        //tempText.text = negativePlayerResponses[UnityEngine.Random.Range(0, negativePlayerResponses.Length)];
    }
    public void CellPaperResponse()
    {
        //TMP_Text tempText = Instantiate(text, this.gameObject.transform);

        //tempText.text = cellResponses[UnityEngine.Random.Range(0, cellResponses.Length)] + gameManager.cell;
    }
    public void ClearText()
    {
        //while(textBoxes.)
        //textBoxes = 0;
    }
}
