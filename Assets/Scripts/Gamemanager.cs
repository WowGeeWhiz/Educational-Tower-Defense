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
    private static GameManager _instance;
    public GameObject TCell1;
    public GameObject TCell2;

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

    DeathGame miniGame;
    private void Start()
    {
        DocumentStartingPosition = new Vector3(Screen.width / 2, Screen.height / 2 - 200, 0f);
        DocumentStartingRotation = new Quaternion(0f, 0f, 0f, 0f);
        CellStartingPosition = new Vector3(Screen.width/2,Screen.height/2 - 100, 0f);
        CellStartingRotation = new Quaternion(0f, 0f, 0f, 0f);
        tutorialManager = FindFirstObjectByType<TutorialManager>();
        //Trigger the first tutorial step when the tutorial level starts
        if(tutorialManager != null )
        tutorialManager.WelcomePopUps();
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

        if (!currentCell.GetCancerStatus())
        {
            healthyCellsKilled++;
        }
        else
        {
            cancerCellsKilled++;

        }
        GameObject T1 = Instantiate(TCell1, new Vector3(-5, 0, 0), Quaternion.identity);
        GameObject T2 =Instantiate(TCell2, new Vector3(-5, 0, 0), Quaternion.identity);
        yield return new WaitForSeconds(3);
        Destroy(T1);
        Destroy(T2);
        DestroyPrefabs();
        //Trigger scoreboard tutorial
        if (tutorialManager != null)
        tutorialManager.TriggerScoreboardTutorial();
    }
    /*
     * 
     */
    public void AcceptCell()
    {

        if(!currentCell.GetCancerStatus())
        {
            healthyCellsAllowed++;
        }
        else
        {
            cancerCellsAllowed++;
        }
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
        if (currentCell == null)
        {
            currentCell = Instantiate(cellTemplate, CellStartingPosition, CellStartingRotation, DocumentsUI);
            ActiveDocument = Instantiate(DocumentTemplate, DocumentStartingPosition, DocumentStartingRotation, DocumentsUI);
            CellGenerator.GenerateCell(0.33f * cancerMultiplier, 5, currentCell, ActiveDocument);
            if(currentCell.GetCancerStatus())
            {
                Image cellImage = currentCell.GetComponent<Image>();
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
            if(tutorialManager != null)
            tutorialManager.TriggerCellSpawnTutorial();
        }
    }
    public void AcquireDocuments()
    {
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
}


