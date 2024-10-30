using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public enum Locations { Brain, Liver, Lungs, Bones, Kidney, Nerves };
public enum CellTypes { Stem, Blood, Bone, Skin, Muscle, Nerve};

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;

    bool gameStart = false; 
    float timeTillLevelEnd;

    int HealthyCellsNeeded;
    int HealthyCellsLetThrough = 0;
    int HealthyCellsTerminated = 0;
    int CancerCellsLetThrough = 0;
    int CancerCellsTerminated = 0;

    //Prefab of cecll
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
    

    //Document ifnromationfor spawn
    Vector3 DocumentStartingPosition;
    Quaternion DocumentStartingRotation;

    //Document ifnromationfor spawn
    Vector3 CellStartingPosition;
    Quaternion CellStartingRotation;

    //Starting Multiplier for cancer spawns in the cell
    int cancerMultiplier = 1;
    
    // Audio manager is a script that handles music and sounds in the game

    public AudioManager audioManager;
    private void Start()
    {
        DocumentStartingPosition = new Vector3(Screen.width / 2, Screen.height / 2 - 200, 0f);
        DocumentStartingRotation = new Quaternion(0f, 0f, 0f, 0f);
        CellStartingPosition = new Vector3(Screen.width/2,Screen.height/2 - 100, 0f);
        CellStartingRotation = new Quaternion(0f, 0f, 0f, 0f);

        //Trigger the first tutorial step when the tutorial level starts
        FindFirstObjectByType<TutorialManager>().WelcomePopUps();
    }


    // Cell Management

    /*
     * 
     */
    public void KillCell()
    {

        //code to trigger animation used to kill cells

        if (!currentCell.GetCancerStatus())
        {
            HealthyCellsTerminated++;
        }
        else
        {
            CancerCellsTerminated++;

        }
        currentCell.gameObject.SetActive(false);
        Destroy(currentCell.gameObject);
        currentCell = null;
        ActiveDocument.gameObject.SetActive(false);
        Destroy(ActiveDocument.gameObject);
        ActiveDocument = null;

        //Trigger scoreboard tutorial
        FindFirstObjectByType<TutorialManager>().TriggerScoreboardTutorial();
    }
    /*
     * 
     */
    public void AcceptCell()
    {
        if(!currentCell.GetCancerStatus())
        {
            HealthyCellsLetThrough++;
        }
        else
        {
            CancerCellsLetThrough++;
        }
        currentCell.gameObject.SetActive(false);
        Destroy(currentCell.gameObject);
        currentCell = null;
        ActiveDocument.gameObject.SetActive(false);
        Destroy(ActiveDocument.gameObject);
        ActiveDocument = null;

        //Trigger scoreboard tutorial
        FindFirstObjectByType<TutorialManager>().TriggerScoreboardTutorial();
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
            FindFirstObjectByType<TutorialManager>().TriggerCellSpawnTutorial();
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
        FindFirstObjectByType<TutorialManager>().TriggerDocumentTutorial();

    }


    //Methods that grab information from the gamemanger class
    public int GetHealthyTerminated()
    {
        return HealthyCellsTerminated;
    }
    public int GetHealthyAllowed()
    {
        return HealthyCellsLetThrough;
    }
    public int GetCancerTerminated()
    {
        return CancerCellsTerminated;
    }
    public int GetCancerAllowed()
    {
        return CancerCellsLetThrough;
    }

}


