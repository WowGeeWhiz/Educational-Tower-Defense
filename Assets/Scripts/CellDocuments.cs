using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellDocuments : MonoBehaviour
{
    string color;
    string protein;
    Locations destination;
    public CellDocuments(string color, string protein, Locations destination)
    {
        this.color = color;
        this.protein = protein;
        this.destination = destination;
    }

    public string GetDestination()
    {
        switch(destination)
        {
            case (Locations)0:
                return "Brain";
            case (Locations)1:
                return "Liver";
            case (Locations)2:
                return "Lungs";
            case (Locations)3:
                return "Bones";
            case (Locations)4:
                return "Kidney";
            default:
                return "";
        }
    }
    public void UpdateDocuments(CellDocuments foreignCell)
    {
        this.color = foreignCell.color;
        this.protein = foreignCell.protein;
        this.destination = foreignCell.destination;
    }
    public void UpdateDocuments(string color, string protein, Locations destination)
    {
        this.color = color;
        this.protein = protein;
        this.destination = destination;
    }
}
