using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

//think about how to implement halfway healthbar
public enum Locations { Brain, Liver, Lungs, Bones, Kidney, Nerves };
public enum CellTypes { Stem, Blood, Bone, Skin, Muscle, Nerve};

public class GameManager : MonoBehaviour
{
    //private static GameManager _instance;
    public GameObject TCell1;
    public GameObject TCell2;
    public Animator TopofScreen;

    bool gameStart = false; 
    float timeTillLevelEnd;

    //Level requirements
    public int HealthyCellsNeeded;
    public int cancerKillsNeeded;
    public int mistakesAllowed;

    int healthyCellsAllowed = 0;
    int healthyCellsKilled = 0;
    int cancerCellsAllowed = 0;
    int cancerCellsKilled = 0;

    //Prefab of cell
    public Cell cellTemplate;
    public Sprite cancerCellSprite;
    //Actual Cell object that will be manipulated
    public Cell currentCell;
    //Script that generates random cells
    public CellGeneration CellGenerator;
    //Parent that instantiated objects will spawn on
    public Transform DocumentsUI;

    //Pefab of the document item
    public CellDocuments DocumentTemplate;

    //Spawned Document object that acts as the document on the table
    public CellDocuments ActiveDocument;

    UIScript ui;
    Dialogue dialogueBox;
    bool run = false;

    //Document information for spawn
    Vector3 DocumentStartingPosition;
    Quaternion DocumentStartingRotation;

    //Document information for spawn
    Vector3 CellStartingPosition;
    Quaternion CellStartingRotation;

    //Starting Multiplier for cancer spawns in the cell
    int cancerMultiplier = 1;
    
    // Audio manager is a script that handles music and sounds in the game

    public AudioManager audioManager;

    TutorialManager tutorialManager;

    //DeathGame miniGame;
    private void Start()
    {
        ui = FindAnyObjectByType<UIScript>();
        dialogueBox = FindAnyObjectByType<Dialogue>();
        DocumentStartingPosition = new Vector3(Screen.width / 2, Screen.height / 2 - 200, 0f);
        DocumentStartingRotation = new Quaternion(0f, 0f, 0f, 0f);
        CellStartingPosition = new Vector3(Screen.width/2,Screen.height/2 - 100, 0f);
        CellStartingRotation = new Quaternion(0f, 0f, 0f, 0f);
        tutorialManager = FindFirstObjectByType<TutorialManager>();
        //Trigger the first tutorial step when the tutorial level starts
        if(tutorialManager != null )
        tutorialManager.WelcomePopUps();
    }

    void Update()
    {
        Invoke("LoadQuizScene", 5);

        if (currentCell != null && run)
        {
            currentCell.gameObject.transform.localPosition += new Vector3(10f * Time.deltaTime,0,0);
        }
    }
    // Cell Management
    /*
     * 
     */
    public void KillCell()
    {
        StartCoroutine(KillC());
    }
    IEnumerator KillC()
    {

        //code to trigger animation used to kill cells
        dialogueBox.negativePlayerResponse();
        if (!currentCell.GetCancerStatus())
        {
            healthyCellsKilled++;
            ui.UpdateHealthBar();
        }
        else
        {
            cancerCellsKilled++;
            ui.UpdateCancerKilled();
        }
        GameObject T1 = Instantiate(TCell1, new Vector3(-5, 0, 0), Quaternion.identity);
        GameObject T2 =Instantiate(TCell2, new Vector3(-5, 0, 0), Quaternion.identity);
        yield return new WaitForSeconds(3);
        Destroy(T1);
        Destroy(T2);
        DestroyPrefabs();
        dialogueBox.ClearText();
        //Trigger scoreboard tutorial
        if (tutorialManager != null)
        tutorialManager.TriggerScoreboardTutorial();
    }
    /*
     * 
     */
    public void AcceptCell()
    {
        StartCoroutine(AcceptC());
    }
    IEnumerator AcceptC()
    {
        run = true;
        if (!currentCell.GetCancerStatus())
        {
            healthyCellsAllowed++;
        }
        else
        {
            cancerCellsAllowed++;
            ui.UpdateHealthBar();
        }
        yield return new WaitForSeconds(1.5f);
        run = false;
        DestroyPrefabs();
        //Trigger scoreboard tutorial
        if (tutorialManager != null)
        tutorialManager.TriggerScoreboardTutorial();
    }

    void DestroyPrefabs()
    {
        currentCell.gameObject.SetActive(false);
        Destroy(currentCell.gameObject);
        currentCell = null;
        ActiveDocument.gameObject.SetActive(false);
        Destroy(ActiveDocument.gameObject);
        ActiveDocument = null;
    }
    /*
     * Meant to be called after a cell is called in after the previous cell is either terminated or let through.
     */
    public void GenerateCell()
    {
        dialogueBox.playerResponse(0);
        if (currentCell == null)
        {
            if (TopofScreen != null)
            {
                TopofScreen.Play("Move");
            }
            currentCell = Instantiate(cellTemplate,new Vector3(-2,0,0), CellStartingRotation);
            ActiveDocument = Instantiate(DocumentTemplate, DocumentStartingPosition, DocumentStartingRotation, DocumentsUI);
            CellGenerator.GenerateCell(0.33f * cancerMultiplier, 5, currentCell, ActiveDocument);
            if(currentCell.GetCancerStatus())
            {
                SpriteRenderer cellImage = currentCell.GetComponent<SpriteRenderer>();
                cellImage.sprite = cancerCellSprite;
            }
            ActiveDocument.gameObject.SetActive(false);
            if (!currentCell.GetCancerStatus())
            {
                cancerMultiplier++;     
            }
            else
            {
                cancerMultiplier = 1;
            }
            //Trigger the tutorial pop-up when the first cell spawns
            if (tutorialManager != null)
            tutorialManager.TriggerCellSpawnTutorial();
        }
    }
    public void AcquireDocuments()
    {
        dialogueBox.playerResponse(1);
        //public static Object Instantiate(Object original, Vector3 position, Quaternion rotation, Transform parent);
        if (!ActiveDocument.gameObject.activeInHierarchy)
        {
            ActiveDocument.gameObject.SetActive(true);
        }
        //DocumentItem

        //Trigger tutorial pop-up for documents
        if(tutorialManager != null)
        tutorialManager.TriggerDocumentTutorial();

    }

    private void LoadQuizScene()
    {
        if (GetCancerKilled() == GetCancerKillsNeeded())
        {
            //Find quiz object in scene and load it
            GameObject quizManager = GameObject.Find("QuizManager");
            GameObject MainUI = GameObject.Find("MainUI");
            GameObject Camera = GameObject.Find("Main Camera");
            Transform backgroundTransform = Camera.transform.Find("Background");

            if (backgroundTransform != null)
            {
                //Set the Background GameObject to inactive
                backgroundTransform.gameObject.SetActive(false);
                Debug.Log("Background component has been set to inactive.");
            }
            //Deactivate the main UI
            if (MainUI != null)
            {
                MainUI.SetActive(false);
            }

            if (quizManager != null)
            {
                CanvasGroup canvasGroup = quizManager.GetComponent<CanvasGroup>();
                if (canvasGroup != null)
                {
                    //Make it visibile
                    canvasGroup.alpha = 1;
                    canvasGroup.interactable = true;
                    //Don't allow clicks on objects behind the quiz
                    canvasGroup.blocksRaycasts = true;
                }
                else
                {
                    Debug.LogError("CanvasGroup component not found on QuizManager.");
                }
            }
            else
            {
                Debug.LogError("QuizManager not found in scene");
            }
        }
    }

    public int GetCancerKillsNeeded()
    {
        return cancerKillsNeeded;
    }

    //Methods that grab information from the gamemanger class
    public int GetHealthyKilled()
    {
        return healthyCellsKilled;
    }
    public int GetHealthyAllowed()
    {
        return healthyCellsAllowed;
    }
    public int GetCancerKilled()
    {
        return cancerCellsKilled;
    }
    public int GetCancerAllowed()
    {
        return cancerCellsAllowed;
    }
    public int GetMistakesAllowed()
    {
        return mistakesAllowed;
    }
}


