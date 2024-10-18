using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Pause : UICanvas
{
    public Button buttonRetry;
    public Button buttonContinue;
    private void OnEnable()
    {
        buttonRetry.onClick.AddListener(ButtonRetry);
        buttonContinue.onClick.AddListener(ButtonContinue);
    }
    public void ButtonRetry()
    {
        SceneManager.LoadScene("Main");
        Time.timeScale = 1f;
    }
    public void ButtonContinue()
    {
        Time.timeScale = 1f;
        Close(0);
    }
}
