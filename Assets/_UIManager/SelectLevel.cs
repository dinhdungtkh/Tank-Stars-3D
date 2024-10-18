using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectLevel : UICanvas
{
    public Button buttonBack;
    public Button buttonLevel;
    private void OnEnable()
    {
        buttonBack.onClick.AddListener(ButtonBack);
        buttonLevel.onClick.AddListener(ButtonLevel);
    }
    private void ButtonBack()
    {
        UIManager.Ins.CloseAll();
        UIManager.Ins.OpenUI<MianMenu>();
    }
    private void ButtonLevel()
    {
        UIManager.Ins.CloseAll();
        UIManager.Ins.OpenUI<Loading>();
    }
}
