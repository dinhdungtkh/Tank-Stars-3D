using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MianMenu : UICanvas
{
    public Button buttonPlayGame;
    private void OnEnable()
    {
        buttonPlayGame.onClick.AddListener(PlayButton);
    }
    public void PlayButton()
    {
        UIManager.Ins.CloseAll();
        UIManager.Ins.OpenUI<SelectLevel>();
    }
}
