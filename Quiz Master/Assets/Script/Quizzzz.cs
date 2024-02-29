using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Quizzzz : MonoBehaviour
{
    [Header("Question")]
    [SerializeField] TextMeshProUGUI questionText;
    [SerializeField] List<QuizzQuestion> questions = new List<QuizzQuestion>();
    QuizzQuestion currentQuestions;
    int currentIndex = 0;

    [Header("Answer")]
    [SerializeField] GameObject[] answerButton;
    bool hasAnsweredEarly = false;

    [Header("Button Sprite")]
    [SerializeField] Sprite defaultAnswerSprite;
    [SerializeField] Sprite correctAnswerSprite;

    [Header("Image")]
    [SerializeField] Image timerImage;
    Timer timer;
    int correctIndex;

    [Header("Scoring")]
    [SerializeField] TextMeshProUGUI scoreText;
    ScoreKeeper scoreKeeper;

    [Header("ProgressBar")]
    [SerializeField] Slider progressBar;

    public bool isComplete = false;
    void Start()
    {
        timer = FindObjectOfType<Timer>();
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
        progressBar.maxValue = questions.Count;
        progressBar.value = 0;
    }

    void Update()
    {
        timerImage.fillAmount = timer.fillFraction;
        if (timer.loadNextQuestion)
        {
            GetNextQuestion();
            timer.loadNextQuestion = false;
        }
        else if (!timer.isAnswering && !hasAnsweredEarly)
        {
            DisplayAnswers(-1);
        }
    }



    public void OnSelectAnswer(int index)
    {
        DisplayAnswers(index);
        SetButtonState(false);
        timer.CancelTimer();
        scoreText.text = "Score : " + scoreKeeper.CalculateScore() + "%";

        if (progressBar.value == progressBar.maxValue)
        {
            isComplete = true;
            timer.FinishGame();
            gameObject.SetActive(false);
        }
    }

    void SetDefaultButtonSprites()
    {
        for (int i = 0; i < answerButton.Length; i++)
        {
            Image sprite = answerButton[i].GetComponent<Image>();
            sprite.sprite = defaultAnswerSprite;
        }
    }

    void DisplayAnswers(int index)
    {
        Image spriteShow = answerButton[correctIndex].GetComponent<Image>();
        if (currentQuestions)
        {
            if (index == correctIndex)
            {
                questionText.text = "Correct!!!!";
                hasAnsweredEarly = true;
                scoreKeeper.IncrementCorrectAnswers();
            }
            else
            {
                questionText.text = "Sorry the right answer is " + currentQuestions.GetAnswer(correctIndex);
                hasAnsweredEarly = false;
            }
        }
        spriteShow.sprite = correctAnswerSprite;
    }

    void RandomQuesiton ()
    {
        
        if (currentIndex < questions.Count)
        {
            int randomIndex = UnityEngine.Random.Range(0, questions.Count);
            currentQuestions = questions[randomIndex];
            questions.RemoveAt(randomIndex);
            scoreKeeper.IncrementQuestionsSeen();
        }


    }

    void DisplayQuestion ()
    {
        RandomQuesiton();
        questionText.text = currentQuestions.GetQuestion();
        correctIndex = currentQuestions.GetCorrectAnswerIndex();
        progressBar.value += 1;
        for (int i = 0; i < answerButton.Length; i++)
        {
            TextMeshProUGUI answer = answerButton[i].GetComponentInChildren<TextMeshProUGUI>();
            answer.text = currentQuestions.GetAnswer(i);
        }
    }

    void GetNextQuestion ()
    {
        SetButtonState(true);
        SetDefaultButtonSprites();
        DisplayQuestion();
    }

    void SetButtonState(bool state)
    {
        for (int i = 0; i < answerButton.Length; i++)
        {
            Button button = answerButton[i].GetComponent<Button>();
            button.interactable = state;
        }
    }
}
