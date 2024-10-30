using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CellDocuments : MonoBehaviour
{
    CellTypes cellType;
    string color;
    string[] proteins = new string[4];
    Locations destination;

    public CellDocuments(string color, string[] proteins, Locations destination)
    {
        this.color = color;
        this.proteins = proteins;
        this.destination = destination;
    }
    public void UpdateDocuments(CellDocuments foreignCell)
    {
        this.color = foreignCell.color;
        this.proteins = foreignCell.proteins;
        this.destination = foreignCell.destination;
    }
    public void UpdateDocuments(CellTypes cellType, string color, string[] proteins, Locations destination)
    {
        this.cellType = cellType;
        this.color = color;
        this.proteins = proteins;
        this.destination = destination;
    } 
    //Get text values of various variables for the document object
    #region DocumentTextFunctions
    public string GetDestinationText()
    {
        return destination.ToString();
    }
    public string GetColorText()
    {
        return destination.ToString();
    }
    public string GetCellTypeText()
    {
        return cellType.ToString();
    }
    public string GetProteinText()
    {
        string temp = "";
        for (int i = 0; i < proteins.Length; i++)
        {
            temp = temp + proteins[i].ToString() + Environment.NewLine;
        }
        return temp;
    }
    #endregion

}
