using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellGeneration : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public Cell GenerateCell(float DefectRate, int NumOfDefect)
    {
        Cell Cell = new Cell();
        CellDocuments CD;// Not Implemented in Cell Yet
        bool cancer;
        string color;
        bool alive;
        string[] protiens = new string[3];//Not sure about the size yet, but 3 felt good
        int age;
        bool dividing;
        string destination;

        cancer = false;
        alive = true;
        color = "Red";
        protiens[0] = "A"; // Going to have to implment an enum of it
        protiens[1] = "B";
        protiens[2] = "C";
        age = 0; //We just need to decide a healthy range
        dividing = false;
        destination = "brain"; // We need a second enum for this
            if (Random.Range(0.0f, 1.0f) < DefectRate)// if true generate Defect.
            {
                cancer = true;// I left out multiple discrepencys for right now I think we take it one step at a time

                switch (Random.Range(0, 2))
                {
                    case 0://protiens
                        protiens[Random.Range(0, 2)] = "1";//Need to switch out the num with an enum of cancer types
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
            }
        Cell = new Cell(cancer, color,alive,protiens,age,dividing,destination);
        return Cell;
    }

}
