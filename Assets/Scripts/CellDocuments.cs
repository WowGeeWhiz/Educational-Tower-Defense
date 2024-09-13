using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellDocuments : MonoBehaviour
{
    string color;
    string protein; 

    public CellDocuments(string color, string protein)
    {
        this.color = color;
        this.protein = protein;
    }
}
