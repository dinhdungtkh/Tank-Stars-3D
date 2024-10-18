using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadScene : UICanvas
{
    private void OnEnable()
    {
        StartCoroutine(LoadingScene());
    }

    private IEnumerator LoadingScene()
    {
        yield return new WaitForSeconds(1.5f);
        GameManager.ChangeState(GameState.MainMenu);
        UIManager.Ins.CloseAll();
        UIManager.Ins.OpenUI<MianMenu>();
    }
}
