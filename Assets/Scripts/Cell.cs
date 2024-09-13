using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell : MonoBehaviour
{
    //Cells have the following attributes:
    //Color
    //Alive 
    //May need more if research shows they do
    //Documents are an associated object with the same variables

    string color;
    bool alive;
    string protein;

    //When the cell generator spawns a cell, it can assign these attributes randomly
    public Cell(string c, bool a, string p)
    {
        color = c;
        alive = a;
        p = protein;
    }
    
}
