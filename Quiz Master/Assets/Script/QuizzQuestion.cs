using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Question", menuName = "Quiz Question")]
public class QuizzQuestion : ScriptableObject
{
    [TextArea(2, 4)]
    [SerializeField] string questionText = "Enter new question";
    [SerializeField] string[] answer = new string[4];
    [SerializeField] int correctAnswerIndex;

    public string GetQuestion()
    {
        return questionText;    
    }

    public int GetCorrectAnswerIndex ()
    {
        return correctAnswerIndex;
    }

    public string GetAnswer(int index)
    {
        return answer[index];
    }
}
