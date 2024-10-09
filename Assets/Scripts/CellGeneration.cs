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
        CellTypes cellType = CellTypes.Stem;

        proteins[0] = "A"; // Going to have to implment an enum of it
        proteins[1] = "B";
        proteins[2] = "C";
        age = 0; //We just need to decide a healthy range
        dividing = false;

        //Uses random integer to assign a location for the cell to move to.
        int location = UnityEngine.Random.Range(0, Enum.GetNames(typeof(Locations)).Length);
        destination = AssignLocation(location);
        cellType = AssignCellType(location);
        //Debug.Log(destination);
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
            destination = AssignLocation(UnityEngine.Random.Range(0, Enum.GetNames(typeof(Locations)).Length));
            cellType = AssignCellType(Enum.GetNames(typeof(CellTypes)).Length);
            }
        cell.UpdateCell(cellType, cancer, color, alive, proteins, age, dividing, destination);
        //Preliminary CelldocumentGeneration for testing
        cd.UpdateDocuments(cellType,"red", "protein", destination);
    }
    //public enum Locations { Brain, Liver, Lungs, Bones, Kidney, Nerves };
    //public enum CellTypes { Stem, Blood, Bone, Skin, Muscle, Nerve }
    CellTypes AssignCellType(int location)
    {
        int temp = 0;
        switch (location)
        {
            case 0:
                temp = UnityEngine.Random.Range(0, 1);
                if (temp == 0)
                return CellTypes.Stem;
                else
                return CellTypes.Blood;
            case 1:
                temp = UnityEngine.Random.Range(0, 1);
                if (temp == 0)
                    return CellTypes.Stem;
                else
                    return CellTypes.Blood;
            case 2:
                temp = UnityEngine.Random.Range(0, 1);
                if (temp == 0)
                    return CellTypes.Stem;
                else
                    return CellTypes.Blood;
            case 3:
                temp = UnityEngine.Random.Range(0, 1);
                if (temp == 0)
                    return CellTypes.Stem;
                else
                    return CellTypes.Blood;
            case 4:
                temp = UnityEngine.Random.Range(0, 1);
                if (temp == 0)
                    return CellTypes.Stem;
                else
                    return CellTypes.Blood;
            case 5:
                temp = UnityEngine.Random.Range(0, 1);
                if (temp == 0)
                    return CellTypes.Nerve;
                else
                    return CellTypes.Stem;
            default:
                return CellTypes.Stem;
        }
    }

    Locations AssignLocation(int location)
    {
        switch (location)
        {
            case 0:
                return Locations.Brain;
            case 1:
                return Locations.Liver;
            case 2:
                return Locations.Lungs;
            case 3:
                return Locations.Bones;
            case 4:
                return Locations.Kidney;
            case 5:
                return Locations.Nerves;
            default:
                return Locations.Brain;
        }
    }
}
