using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class QuizManager : MonoBehaviour
{
    //public Button submit;
    public List<QuestionAndAnswers> QnA;
    public GameObject[] options;
    public int currentQuestion;

     

    public Text QuestionText;
    public GameObject QuizPanel;
    public GameObject GoPanel;
    public GameObject GameEnd;
    int questionDisplayedOnBox = 0;
    int totalQn = 1;


    public int score;
    public Text ScoreText; 
    public Text Score;                          //hint text

    int totalQuestions = 0;

    private void Start()
    {
        GameEnd.SetActive(false);
        totalQuestions = QnA.Count;
        GoPanel.SetActive(false);
        //QnA.RemoveAt(currentQuestion);
        generateQuestion();

    }

    public void Retry()
    {
        GoPanel.SetActive(false);
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }

    // public void onSubmit(){
    //     submit.interactable = false;
    //     username = Login.username1;
    //     Debug.Log(username);

    //     StartCoroutine(TrySubmit());

    // }

    void GameOver()                                       // Display next hint
    {
        GoPanel.SetActive(true);
        QuizPanel.SetActive(false);
        questionDisplayedOnBox = 1;                             //starts displaying questions 
    }

    public void Correct()
    {
        score++;
        QnA.RemoveAt(currentQuestion);
        generateQuestion();
    }

    public void wrong()
    {
        // when you answer wrong
        QnA.RemoveAt(currentQuestion);
        generateQuestion();
    }


    void SetAnswer()
    {
        for(int i = 0; i < options.Length; i++)
        {
            options[i].GetComponent<AnswerScript>().isCorrect = false;
            options[i].transform.GetChild(0).GetComponent<Text>().text = QnA[currentQuestion].Answers[i];

            if(QnA[currentQuestion].CorrectAnswer == i+1)
            {
                options[i].GetComponent<AnswerScript>().isCorrect = true;
            }
        }
    }

    void GameEndFunc()
    {
        GameEnd.SetActive(true);
        Score.text = score + "/" + totalQn;  
        QuizPanel.SetActive(false);

    }

   

    void generateQuestion()
    {
        if(QnA.Count == 1)                                            ///TESTTTTT
            {
                GameEndFunc();

            }
        else if(QnA.Count > 0 && questionDisplayedOnBox<5)
        {
            totalQn++;
            questionDisplayedOnBox++;
            currentQuestion = Random.Range(0, QnA.Count);
            QuestionText.text = QnA[currentQuestion].Questions;
            SetAnswer();

            

        }
         
        else
        {
            Debug.Log(score);
            Debug.Log("out of questions");
            GameOver();

        }
    }
}