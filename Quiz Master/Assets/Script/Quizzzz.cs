using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Quizzzz : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI questionText;
    [SerializeField] QuizzQuestion question;
    [SerializeField] GameObject[] answerButton;
    int correctIndex;
    [SerializeField] Sprite defaultAnswerSprite;
    [SerializeField] Sprite correctAnswerSprite;

    void Start()
    {
        questionText.text = question.GetQuestion();
        correctIndex = question.GetCorrectAnswerIndex();
        for (int i = 0; i < answerButton.Length; i++)
        {
            TextMeshProUGUI answer= answerButton[i].GetComponentInChildren<TextMeshProUGUI>();
            answer.text = question.GetAnswer(i);
        }
    }

    public void OnSelectAnswer(int index)
    {
        print(index);
        if(index == correctIndex)
        {
            questionText.text = "!Correct";
            Image correctSprite = answerButton[index].GetComponent<Image>();
            correctSprite.sprite = correctAnswerSprite;
        }
    }
}
