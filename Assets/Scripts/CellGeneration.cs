using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellGeneration : MonoBehaviour
{
    /*
     * Uses empty currentCell from Gamemanager to "update" the cell that's spawned in 
     * Similar operation occurs with the ActiveDocument
    */
    public void GenerateCell(float DefectRate, int NumOfDefect, Cell cell, CellDocuments cd)
    {
        //Cell Generation
        
        bool cancer = false;
        string color = "red";
        bool alive = true;
        string[] proteins = new string[3];//Not sure about the size yet, but 3 felt good
        int age;
        bool dividing;
        //Unity was giving an error where "an uninstantiated variable can't be used" so this assignment is here solely to fix it.
        Locations destination = Locations.Brain;

        proteins[0] = "A"; // Going to have to implment an enum of it
        proteins[1] = "B";
        proteins[2] = "C";
        age = 0; //We just need to decide a healthy range
        dividing = false;
        int location = UnityEngine.Random.Range(0, Enum.GetNames(typeof(Locations)).Length);
        switch (location)
        {
            case 0:
                break;
            case 1:
                destination = Locations.Liver; break;
            case 2:
                destination = Locations.Lungs; break;
            case 3:
                destination = Locations.Bones; break;
            case 4:
                destination = Locations.Kidney; break;
        }
            if (UnityEngine.Random.Range(0.0f, 1.0f) < DefectRate)// if true generate Defect.
            {
                cancer = true;// I left out multiple discrepencys for right now I think we take it one step at a time

                switch (UnityEngine.Random.Range(0, 2))
                {
                    case 0://protiens
                        proteins[UnityEngine.Random.Range(0, 2)] = "1";//Need to switch out the num with an enum of cancer types
                        break;
                    case 1://Division
                        dividing = true;
                        break;
                    case 2://Destination - Age
                           //I could not remember exactly, but this will probablly need to be together in order to work
                        break;
                    default:
                        break;
                }
            }
        cell.UpdateCell(cancer, color, alive, proteins, age, dividing, destination);
        //Preliminary CelldocumentGeneration for testing



        cd.UpdateDocuments("red", "protein", Locations.Brain);
    }
}
