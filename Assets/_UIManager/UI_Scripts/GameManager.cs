using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.Events;
public enum GameState
{
    LoadScene,
    MainMenu,
    GamePlay,
    Win,
    Lose,
}
public class GameManager : Singleton<GameManager>
{
    public Camera cameraMain;
    private static GameState gameState = GameState.LoadScene;


    // Start is called before the first frame update
    protected void Awake()
    {
        ChangeState(GameState.LoadScene);

        UIManager.Ins.OpenUI<LoadScene>();
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
