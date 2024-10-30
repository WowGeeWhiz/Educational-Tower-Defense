using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DocumentText : MonoBehaviour
{
    public CellDocuments cellDocument;
    public TMP_Text destinationText;
    public TMP_Text cellTypeText;
    public TMP_Text proteinText;
    private void Update()
    {
        destinationText.text = "Destination: " + cellDocument.GetDestinationText();
        cellTypeText.text = "Cell Type: " + cellDocument.GetCellTypeText();
        proteinText.text = "Proteins: " + Environment.NewLine + cellDocument.GetProteinText();

    }
}
