using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CellDocuments : MonoBehaviour
{
    CellTypes cellType;
    string color;
    string protein;
    Locations destination;

    public CellDocuments(string color, string protein, Locations destination)
    {
        this.color = color;
        this.protein = protein;
        this.destination = destination;
    }
    public void UpdateDocuments(CellDocuments foreignCell)
    {
        this.color = foreignCell.color;
        this.protein = foreignCell.protein;
        this.destination = foreignCell.destination;
        Debug.Log(foreignCell.destination);
        Debug.Log(this.destination);
    }
    public void UpdateDocuments(CellTypes cellType, string color, string protein, Locations destination)
    {
        this.cellType = cellType;
        this.color = color;
        this.protein = protein;
        this.destination = destination;
    }
    public string GetDestination()
    {
        return destination.ToString();
    }
    public string GetColor()
    {
        return destination.ToString();
    }
    public string GetCellType()
    {
        return cellType.ToString();
    }

}
