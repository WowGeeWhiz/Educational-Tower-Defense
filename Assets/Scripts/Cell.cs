using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell: MonoBehaviour
{
    CellTypes cellType;
    bool Cancer;
    string color;
    bool alive;//Couldn't remember the particular reason for this one
    string[] proteins;
    int Age;
    bool Dividing;// May remove later currently meant for showcasing division in real time
    Locations destination;

    //When the cell generator spawns a cell, it can assign these attributes randomly
    public Cell(bool can, string c, bool a, string[] p, int age, bool d, Locations dest)
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
        destination = dest;
    }

    public Cell()
    {
        Cancer = false;
        color = "Red";
        alive = true;
        proteins = new string[0];
        Age = 0;
        Dividing = false;
        destination = Locations.Brain;
    }
    public bool GetCancerStatus()
    {
        return Cancer;
    }
    public void UpdateCell(CellTypes cell, bool can, string c, bool a, string[] p, int age, bool d, Locations dest)
    {
        cellType = cell;
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
        destination = dest;
    }
}
