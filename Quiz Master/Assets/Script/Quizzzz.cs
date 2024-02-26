using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Quizzzz : MonoBehaviour
{
    [Header("Question")]
    [SerializeField] TextMeshProUGUI questionText;
    [SerializeField] QuizzQuestion question;

    [Header("Answer")]
    [SerializeField] GameObject[] answerButton;

    [Header("Button Sprite")]
    [SerializeField] Sprite defaultAnswerSprite;
    [SerializeField] Sprite correctAnswerSprite;

    [Header("Image")]
    [SerializeField] Image timerImage;
    Timer timer;
    int correctIndex;
    void Start()
    {
        DisplayQuestion();
        timer = FindObjectOfType<Timer>();
    }

    void Update()
    {
        timerImage.GetComponent<Image>().fillAmount = timer.fillFraction;
    }


    public void OnSelectAnswer(int index)
    {
        Image correctSprite = answerButton[correctIndex].GetComponent<Image>();
        if (index == correctIndex)
        {
            questionText.text = "Correct!!!!";
        }
        else
        {
            questionText.text = "Sorry the right answer is " + question.GetAnswer(correctIndex);
        }

        correctSprite.sprite = correctAnswerSprite;
        Invoke("SetDefaultButtonSprites", 2.0f);
        SetButtonState(false);
    }

    void SetDefaultButtonSprites()
    {
        for (int i = 0; i < answerButton.Length; i++)
        {
            Image sprite = answerButton[i].GetComponent<Image>();
            sprite.sprite = defaultAnswerSprite;
        }
    }

    void DisplayQuestion ()
    {
        questionText.text = question.GetQuestion();
        correctIndex = question.GetCorrectAnswerIndex();
        for (int i = 0; i < answerButton.Length; i++)
        {
            TextMeshProUGUI answer = answerButton[i].GetComponentInChildren<TextMeshProUGUI>();
            answer.text = question.GetAnswer(i);
        }
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
