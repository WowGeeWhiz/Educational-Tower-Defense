using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DocumentText : MonoBehaviour
{
    public CellDocuments cellDocument;
    public TMP_Text destinationText;
    public TMP_Text cellTypeText;
    private void Update()
    {
        destinationText.text = "Destination: " + cellDocument.GetDestination();
        cellTypeText.text = "Cell Type: " + cellDocument.GetCellType();
    }
}
