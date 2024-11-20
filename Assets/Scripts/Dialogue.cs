using TMPro;
using UnityEngine;

public class Dialogue : MonoBehaviour
{
    public TMP_Text cellText;
    public TMP_Text playerText;

    GameManager gameManager;

    public string[] cellResponses = { "I can’t wait to go to ", "Looking forward to working at the " };
    public string[] cellExcuses = { "" };
    public string[] playerResponses = { "Next Person in line", "Proteins Please," };
    public string[] negativePlayerResponses = { "Healthy cells only", "Not this time", "I don’t think so" };
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //cellText
    }
}
