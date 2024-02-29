using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    Quizzzz quiz;
    EndScreen endScreen;
    int scene;
    void Start()
    {
        quiz = FindObjectOfType<Quizzzz>();
        endScreen = FindObjectOfType<EndScreen>();
        scene = SceneManager.GetActiveScene().buildIndex;
        if(scene == 1)
        {
            quiz.gameObject.SetActive(true);
            endScreen.gameObject.SetActive(false);
        }
        else
        {
            quiz.gameObject.SetActive(false); 
            endScreen.gameObject.SetActive(false);
        }
    }

    void Update()
    {
        if (quiz.isComplete && scene == 1)
        {
            quiz.gameObject.SetActive (false);
            endScreen.gameObject.SetActive(true);
        }
    }



    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void ReloadGame()
    {
        SceneManager.LoadScene(1);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

}
