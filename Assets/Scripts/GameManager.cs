using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState {
    menu,
    inGame,
    gameOver,
}
public class GameManager : MonoBehaviour
{
    public GameState currentGameState = GameState.menu;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame() 
    {

    }

    public void GameOver()
    {

    }

    public void BackToMenu() 
    {

    }

    private void SetGameState(GameState state)
    {
        if (state == GameState.menu){
            //TODO: Menu
        } else if (state == GameState.inGame) {
            //TODO: inGame
        } else if (state == GameState.gameOver) {
            //TODO: gameOver
        }

        this.currentGameState = state;
    }
}
