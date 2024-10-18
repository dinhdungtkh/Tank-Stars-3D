using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.Events;
public enum GameState
{
    MainMenu,
    GamePlay,
    Win,
    Lose,
}
public class GameManager : Singleton<GameManager>
{
    public Camera cameraMain;
    private static GameState gameState = GameState.MainMenu;


    // Start is called before the first frame update
    protected void Awake()
    {
        ChangeState(GameState.MainMenu);

        UIManager.Ins.OpenUI<MianMenu>();
    }
    public static void ChangeState(GameState state)
    {
        gameState = state;
    }

    public static bool IsState(GameState state)
    {
        return gameState == state;
    }

}
