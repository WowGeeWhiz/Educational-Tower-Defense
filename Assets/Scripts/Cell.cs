using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell : MonoBehaviour
{
    //Cells have the following attributes:
    //Color
    //Alive 
    //Documents
        //Need to decide if documents are their own object that is assigned to a cell, or if a document's contents come from a cell's attributes
    //Sprite

    public GameObject cell;
    string color;
    bool alive;    

    //When the cell generator spawns a cell, it can assign these attributes randomly
    public Cell(GameObject sprite, string c, bool a)
    {
        cell = sprite;
        color = c;
        alive = a;
    }
    void Start()
    {
        alive = true;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
