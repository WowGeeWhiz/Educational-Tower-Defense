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
    public GameObject moreInfoButton;

    public GameObject moreInfoText;
    public TMP_Text infoTitle;
    public TMP_Text moreInfoBody;

    public GameObject healthyCell;
    public GameObject unHealthyCell;
    // Start is called before the first frame update
    void Start()
    {
        pageNum.text = "";
        Debug.Log(pageText.pageToDisplay.ToString());
    }

    // Update is called once per frame
    public void NextPage()
    {
        if (!prevPage.activeInHierarchy)
        {
            prevPage.SetActive(true);
        }
        pageText.pageToDisplay++;
        if (pageText.pageToDisplay == pageText.textInfo.pageCount)
        {
            nextPage.SetActive(false);
        }
        SetCellImages();
        SetPageText();
    }
    public void PreviousPage()
    {
        if (!nextPage.activeInHierarchy)
        {
            nextPage.SetActive(true);
        }
        pageText.pageToDisplay--;
        if (pageText.pageToDisplay == 1)
        {
            prevPage.SetActive(false);
        }
        SetCellImages();
        SetPageText();
    }
    void SetPageText()
    {
        int pageNumber = pageText.pageToDisplay - 1;
        if (pageNumber != 0)
            pageNum.text = pageNumber.ToString();
        else
        {
            pageNum.text = "";
            moreInfoButton.SetActive(false);
        }
        if (pageNumber > 1 && !moreInfoButton.activeInHierarchy)
        {
            moreInfoButton.SetActive(true);
        }
    }
    public void TriggerInfoText()
    {
        moreInfoText.SetActive(true);
        infoTitle.pageToDisplay = pageText.pageToDisplay;
        moreInfoBody.pageToDisplay = pageText.pageToDisplay;
    }
    void SetCellImages()
    {
        if (pageText.pageToDisplay == 3 || pageText.pageToDisplay == 4)
        {
            healthyCell.SetActive(true);
            unHealthyCell.SetActive(true);
        }
        else
        {
            healthyCell.SetActive(false);
            unHealthyCell.SetActive(false);
        }
    }
}
