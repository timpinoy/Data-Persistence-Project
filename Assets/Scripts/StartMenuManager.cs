using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class StartMenuManager : MonoBehaviour
{
    public Text HighscoreText;
    public InputField Name;

    private void Start()
    {
        HighscoreText.text = $"Best Score : {HighscoreManager.Instance.HighscoreName} : {HighscoreManager.Instance.Highscore}";
    }

    public void StartButtonClicked()
    {
        HighscoreManager.Instance.CurrentName = Name.GetComponent<InputField>().text;
        SceneManager.LoadScene(1);
    }

    public void ExitButtonClicked()
    {
        #if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
        #else
        Application.Quit()
        #endif
    }
}
