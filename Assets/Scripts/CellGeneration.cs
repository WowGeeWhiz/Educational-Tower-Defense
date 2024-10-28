using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellGeneration : MonoBehaviour
{
    //public enum CellTypes { Stem, Blood, Bone, Skin, Muscle, Nerve };
    string[] cancerProteins;
    string[] stemProteins;
    string[] bloodProteins;
    string[] boneProteins;
    string[] muscleProteins;
    string[] nerveProteins;

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
        int age;
        bool dividing;
        //Uses random integer to assign a location for the cell to move to.
        int location = UnityEngine.Random.Range(0, Enum.GetNames(typeof(Locations)).Length);
        Locations destination = AssignLocation(location);
        CellTypes cellType = AssignCellType(location);
        string[] proteins = AssignProteins(cellType);
        age = 0; //We just need to decide a healthy range
        dividing = false;

        if (UnityEngine.Random.Range(0.0f, 1.0f) < DefectRate)// if true generate Defect.
        {
            cancer = true;// I left out multiple discrepencys for right now I think we take it one step at a time
                
            //Legacy Code I don't know the intention of this
            //switch (UnityEngine.Random.Range(0, 2))
            //{
            //    case 0://protiens
            //        proteins[UnityEngine.Random.Range(0, 2)] = "1";//Need to switch out the num with an enum of cancer types
            //        break;
            //    case 1://Division
            //        dividing = true;
            //        break;
            //    case 2://Destination - Age
            //           //I could not remember exactly, but this will probablly need to be together in order to work
            //        break;
            //    default:
            //        break;
            //}
                
            //Randomizes a random protein to additional cancer proteins;
            if (UnityEngine.Random.Range(0, 1) == 1)
            {
                proteins[0] = cancerProteins[UnityEngine.Random.Range(0, cancerProteins.Length)]; 
            }
            if (UnityEngine.Random.Range(0, 1) == 1)
            {
                proteins[1] = cancerProteins[UnityEngine.Random.Range(0, cancerProteins.Length)];
            }
            if (UnityEngine.Random.Range(0, 1) == 1)
            {
                proteins[2] = cancerProteins[UnityEngine.Random.Range(0, cancerProteins.Length)];
            }
            //Randomizes Location and cell type to give indication that something is wrong
            destination = AssignLocation(UnityEngine.Random.Range(0, Enum.GetNames(typeof(Locations)).Length));
            cellType = AssignCellType(Enum.GetNames(typeof(CellTypes)).Length);
        }
        cell.UpdateCell(cellType, cancer, color, alive, proteins, age, dividing, destination);
        //Preliminary CelldocumentGeneration for testing
        cd.UpdateDocuments(cellType,"red", proteins, destination);
    }
    //public enum Locations { Brain, Liver, Lungs, Bones, Kidney, Nerves };
    //public enum CellTypes { Stem, Blood, Bone, Skin, Muscle, Nerve }

    #region AssignmentFunctions
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
    string[] AssignProteins(CellTypes celltype)
    {
        string[] proteins = new string[3];
        switch (celltype)
        {
            case CellTypes.Stem:

                break;
            case CellTypes.Blood:

                break;
            case CellTypes.Bone:

                break;
            case CellTypes.Skin:

                break;
            case CellTypes.Muscle:

                break;
            case CellTypes.Nerve:

                break;
        }
        return proteins;
    }
    #endregion
}
