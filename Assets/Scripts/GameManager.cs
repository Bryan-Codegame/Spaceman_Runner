using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Este objeto puede ser accedido desde cualquier parte del proyecto, es decir podemos 
llamarlo desde playerController sin instanciarlo ya que aquí  se define como global*/
public enum GameState {
    menu,
    inGame,
    gameOver,
}
public class GameManager : MonoBehaviour
{
    //Singleton
    /* Static -> Significa que sólo va a existir una instancia la cual es compartida con todo el 
    mundo. Es decir, una variable que actúa como jefe al que todos le obedecen */
    public static GameManager sharedInstance;

    //Inicial State of the game
    public GameState currentGameState = GameState.menu;

    PlayerController controller;

    void Awake() 
    {
        if (sharedInstance == null)
        {
            /* Game manager es representado por este sharedInstance el cual será llamado para establecer los estados del juego
            entre otras cosas generales.*/
            sharedInstance = this;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        controller = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        //Se activa presionando space o enter ambos están asociados a este submit en el input manager.
        if (Input.GetButtonDown("Submit") && currentGameState != GameState.inGame)
        {
            StartGame();
        }
    }

    /* ---------------------------- */
    /* Functions */
    public void StartGame() 
    {
        SetGameState(GameState.inGame);
    }

    public void GameOver()
    {
        SetGameState(GameState.gameOver);
    }

    public void BackToMenu() 
    {
        SetGameState(GameState.menu);
    }


    private void SetGameState(GameState state)
    {
        if (state == GameState.menu){
            //TODO: Menu
        } else if (state == GameState.inGame) {
            controller.StartGame();
        } else if (state == GameState.gameOver) {
            //TODO: gameOver
        }

        this.currentGameState = state;
    }
}
