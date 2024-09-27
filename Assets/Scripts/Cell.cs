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

    bool Cancer;
    string color;
    bool alive;//Couldn't remember the particular reason for this one
    CellDocuments CD;//We don't have this yet so blank for now
    string[] proteins;
    int Age;
    bool Dividing;// May remove later currently meant for showcasing division in real time
    string Destination;


    //When the cell generator spawns a cell, it can assign these attributes randomly
    public Cell(bool can, string c, bool a, string[] p, int age, bool d, string dest)
    {
        Cancer = can;
        color = c;
        alive = a;
        proteins = new string[p.Length];
        int temp = 0;
        foreach (string s in p)
        {
            proteins[temp] = s;
            temp++;
        }
        Age = age;
        Dividing = d;
        Destination = dest;
    }

    public Cell()
    {
        Cancer = false;
        color = "Red";
        alive = true;
        proteins = new string[0];
        Age = 0;
        Dividing = false;
        Destination = "Empty";
    }
    
}
