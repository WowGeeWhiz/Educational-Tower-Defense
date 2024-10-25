using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuizAnswerButton : MonoBehaviour
{
    internal bool isCorrect = false;
    //public int buttonIndex;

    public void isPressed()
    {
        FindFirstObjectByType<QuizManager>().PickAnswer(isCorrect);
    }
}
