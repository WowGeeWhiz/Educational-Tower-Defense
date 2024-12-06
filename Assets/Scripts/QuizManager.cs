using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class QuizManager : MonoBehaviour
{
    public GameObject startQuizButton;
    public GameObject questionText;
    public GameObject nextLevelButton;
    public string nextLevelText;
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
        public string[] incorrectAnswers = new string[3];


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
        startQuizButton.SetActive(false);
        questionText.SetActive(true);
        for (int i = 0; i < answerButtons.Length; i++)
        {
            Debug.LogWarning("Update this to just hit the quizparent object");
            answerButtons[i].gameObject.SetActive(true);
        }
    }
    public void ShowQuestion()
    {
        if (!isQuizing) return;
        currentQuestion++;
        if (currentQuestion >= questions.Length)
        {
            isQuizing = true;
            DisplayScore();
            for (int i = 0; i < answerButtons.Length; i++)
            {
                answerButtons[i].gameObject.SetActive(false);
                Debug.LogWarning("Update this to just hit the quizparent object");
            }
            return;
        }
        questionDisplay.text = questions[currentQuestion].question;
        int[] setTo = new int[] { -1, -1, -1, -1};
        //foreach answer
        for (int i = 0; i < setTo.Length; i++)
        {
            int temp = -1;
            do
            {
                //not right
                //needs to randomize answer spots
                temp = rand.Next(0, setTo.Length);
                bool noDouble = true;
                for (int j = 0; j < i; j++)
                {
                    if (setTo[j] == temp) noDouble = false;
                }
                if (noDouble) setTo[i] = temp;
            } while (setTo[i] == -1);
            //set determined encoding here
        }

        //for each answer button
        for (int k = 0; k < setTo.Length; k++)
        {
            //if not correct answer
            if (setTo[k] > 0)
            {
                answerButtons[k].gameObject.GetComponentInChildren<TextMeshProUGUI>().text = questions[currentQuestion].incorrectAnswers[setTo[k] - 1];
                answerButtons[k].gameObject.GetComponent<QuizAnswerButton>().isCorrect = false;
            }
            //otherwise its correct answer
            else
            {
                answerButtons[k].gameObject.GetComponentInChildren<TextMeshProUGUI>().text = questions[currentQuestion].correctAnswer;
                answerButtons[k].gameObject.GetComponent<QuizAnswerButton>().isCorrect = true;
            }
        }
    }

    public void PickAnswer(bool rightAnswer)
    {
        Debug.LogWarning("Not implemented");

        if (rightAnswer) wasCorrect[currentQuestion] = true;
        //if answer is correct update wascorrect[currentquestion] to true 

        //then display the next question or end screen
        if (currentQuestion >= questions.Length)
        {
            DisplayScore();
            for (int i = 0; i < answerButtons.Length; i++)
            {
                answerButtons[i].gameObject.SetActive(false);
                Debug.LogWarning("Update this to just hit the quizparent object");
            }
        }
        else ShowQuestion();
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
        nextLevelButton.SetActive(true);
    }
    public void NextLevel()
    {
        SceneManager.LoadScene(nextLevelText);
    }
}
