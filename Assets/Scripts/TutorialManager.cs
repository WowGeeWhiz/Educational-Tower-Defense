using UnityEngine;
using UnityEngine.UI;
using TMPro; 

public class TutorialManager : MonoBehaviour
{
    public GameObject tutorialPopupPrefab;
    public Transform canvasTransform;
    private GameObject currentPopup;
    private TMP_Text tutorialText;           
    private Button nextButton;
    public GameObject Default_Layer;

    //Index for tutorial steps
    private int stepIndex = 0;

    //Want to add another array for step titles as well
    //Get drag and drop functionality working
    //Make the pop ups generate at the right times
    //Resize them, make sure text is readable 

    //Tutorial steps as strings
    //My mindset is if there's an array of tutorial prompts in the code, we only need one prefab that can dynamically load the right prompt
    private string[] tutorialSteps = {
        "Welcome to the tutorial!\nIn this game, you will learn how to identify cancer cells from healthy cells,\njust like how our bodies do!",
        "Your job is to man this checkpoint, and check each cell's documents to make sure they check out. Their documents contain details about the cell.",
        "This is a set of documents. You can drag them around. Check the information on it carefully to decide if the cell is cancerous or healthy.",
        "Use the 'Allow' button to let a healthy cell pass through, or 'Kill' to eliminate a cancerous cell.",
        "This is the scoreboard. It tracks the number of healthy and cancer cells you’ve killed or allowed.",
        "Would you like to replay the tutorial or move on to the game on your own?"
    };

    //Start the tutorial when the level loads
    private void Start()
    {
        ShowNextPopup();
    }

    //Show the next tutorial step
    public void ShowNextPopup()
    {
        if (currentPopup == null)
        {
            //Instatiate as a child of default layer object
            //object.transform.setparent()
            //object.transform.SetParent(newParent) 
            currentPopup = Instantiate(tutorialPopupPrefab);
            currentPopup.transform.SetParent(Default_Layer.transform);

            //Ensure it can be dragged
            if (currentPopup.GetComponent<DragObject>() == null)
            {
                currentPopup.AddComponent<DragObject>();
            }

            tutorialText = currentPopup.GetComponentInChildren<TMPro.TextMeshProUGUI>();
            nextButton = currentPopup.GetComponentInChildren<Button>();
            nextButton.onClick.AddListener(OnNextButtonClicked);
        }

        if (stepIndex < tutorialSteps.Length)
        {
            if (currentPopup == null)
            {
                //Instantiate a new pop-up from the prefab
                currentPopup = Instantiate(tutorialPopupPrefab, canvasTransform);

                //Find the TextMeshPro component in the children
                tutorialText = currentPopup.GetComponentInChildren<TMP_Text>();

                //Find the Button component in the children
                nextButton = currentPopup.GetComponentInChildren<Button>();

                //Add listener for the "Next" button
                nextButton.onClick.AddListener(OnNextButtonClicked);
            }

            //Update the text for the current step
            tutorialText.text = tutorialSteps[stepIndex];
        }
        else
        {
            //Close the tutorial after the last step
            CloseTutorial();
        }
    }

    //Handle the first pop up
    public void WelcomePopUps()
    {
        stepIndex = 0;
        ShowNextPopup();
    }

    //Handle "Next" button clicks
    private void OnNextButtonClicked()
    {
        stepIndex++;
        ShowNextPopup();
    }

    //Close the tutorial and cleanup
    private void CloseTutorial()
    {
        Destroy(currentPopup);
        //Reset the tutorial index
        stepIndex = 0;  
    }

    //Custom triggers for tutorial steps
    public void TriggerCellSpawnTutorial()
    {
        //This is when the first cell spawns
        stepIndex = 2;  
        ShowNextPopup();
    }

    public void TriggerScoreboardTutorial()
    {
        //After player makes a decision
        stepIndex = 4;
        ShowNextPopup();
    }

    public void TriggerFinalStep()
    {
        //After showing scoreboard
        stepIndex = 5;
        ShowNextPopup();
    }


}

