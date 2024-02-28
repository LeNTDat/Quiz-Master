
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndScreen : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI endGameScoreScreenText;

    public void EndGameScene(int score)
    {
        gameObject.SetActive(true);
        print(gameObject.active);
        endGameScoreScreenText.text = "Congratuation!" + "Your Score is :" + score;
    }

    public void ReloadGame()
    {
        SceneManager.LoadScene(0);
    }
}
