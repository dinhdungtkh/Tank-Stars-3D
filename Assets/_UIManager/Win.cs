using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Win : UICanvas
{
    public Button retryButton;
    private void OnEnable() {
        retryButton.onClick.AddListener(RetryButton);
    }
    private void RetryButton(){
        SceneManager.LoadScene("Main");
    }

}
