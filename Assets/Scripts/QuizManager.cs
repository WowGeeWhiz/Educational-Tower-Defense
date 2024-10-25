using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.Search;
using UnityEngine;
using UnityEngine.UI;

public class QuizManager : MonoBehaviour
{
    public Button[] answerButtons;
    public TextMeshProUGUI questionDisplay;
    [Header("Format questions as follows: question\\correctAnswer\\incorrectAnswer1\\incorrectAnswer2\\incorrectAnswer3")]
    public List<string> questionsInput = new List<string>();
    Question[] questions;
    internal bool isQuizing = false;
    int currentQuestion = 0;
    bool[] wasCorrect;
    System.Random rand;

    class Question
    {
        public string question;
        public string correctAnswer;
        public string[] incorrectAnswers;

        public Question(string input)
        {
            string[] temp = input.Split('\\',5);
            question = temp[0];
            correctAnswer = temp[1];
            for (int i = 0; i < 3; i++)
            {
                incorrectAnswers[i] = temp[i + 2];
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        rand = new System.Random();
        questions = new Question[questionsInput.Count];
        for (int i = 0; i < questionsInput.Count; i++) 
        {
            questions[i] = new Question(questionsInput[i]);
        }
    }

    public void StartQuiz()
    {
        isQuizing = true;
        currentQuestion = -1;
        wasCorrect = new bool[questionsInput.Count];
        ShowQuestion();
    }

    public void ShowQuestion()
    {
        if (!isQuizing) return;
        currentQuestion++;
        questionDisplay.text = questions[currentQuestion].question;
        int[] setTo = new int[] { -1, -1, -1, -1};
        //foreach answer
        for (int i = 0; i < setTo.Length; i++)
        {
            int temp = -1;
            do
            {

                temp = rand.Next(0, setTo.Length);
            } while (setTo[temp] != -1);
        }
    }

    public void PickAnswer(int answerIndex)
    {
        Debug.LogWarning("Not implemented");


        currentQuestion++;
        if (currentQuestion >= questions.Length)
        {
            DisplayScore();
        }
    }

    public void DisplayScore()
    {
        isQuizing = false;
        int numCorrect = 0;
        for (int i = 0; i < wasCorrect.Length; i++)
        {
            if (wasCorrect[i]) { numCorrect++; }
        }
        questionDisplay.text = "you got " + numCorrect + "/" + wasCorrect.Length + " questions correct";
    }
}
