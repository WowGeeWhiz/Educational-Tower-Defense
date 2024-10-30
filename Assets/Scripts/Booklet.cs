using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Booklet : MonoBehaviour
{
    public TMP_Text pageText;
    public GameObject prevPage;
    public GameObject nextPage;
    public TMP_Text pageNum;
    int pageNumber;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public void NextPage()
    {
        if(!prevPage.activeInHierarchy)
        {
            prevPage.SetActive(true);
        }
        pageText.pageToDisplay++;
        if (pageText.pageToDisplay == pageText.textInfo.pageCount)
        {
            nextPage.SetActive(false);
        }
    }
    public void PreviousPage()
    {
        if (!nextPage.activeInHierarchy)
        {
            nextPage.SetActive(true);
        }
        pageText.pageToDisplay--;
        if(pageText.pageToDisplay == 0 )
        {
            prevPage.SetActive( false );
        }
    }
}
