
using TMPro;
using UnityEngine;

public class EndScreen : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI endGameScoreScreenText;
    ScoreKeeper scoreKeeper;

    void Start()
    {
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
        endGameScoreScreenText.text = "Congratuation! \n" + "Your Score is : " + scoreKeeper.CalculateScore() + "%";
    }
}
