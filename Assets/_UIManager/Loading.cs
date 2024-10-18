using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loading : UICanvas
{
    private void OnEnable()
    {
        StartCoroutine(GamePlay());
    }

    private IEnumerator GamePlay()
    {
        yield return new WaitForSeconds(1.5f);
        GameManager.ChangeState(GameState.GamePlay);
        UIManager.Ins.CloseAll();
        UIManager.Ins.OpenUI<GamePlay>();
    }
}
