using UnityEngine;

/// <summary>
/// Enum for the state of the game.
/// </summary>
public enum GameState
{
    WhiteTurn,
    BlackTurn,
    GameOver
}

/// <summary>
/// The controller class for determining the state of the game, as well as logic that makes the game playable.
/// </summary>
public class GameStateController : MonoBehaviour
{
    public GameState currentState;
    private PlayerClass whitePlayer = new PlayerClass("TempName",true);
    private PlayerClass blackPlayer = new PlayerClass("TempName2",false);

    public void Start()
    {
        currentState = GameState.WhiteTurn;
    }

    /// TODO: Disable pieces that are not on the active turn.
    // TODO: Ending one player's turn checks for checkmates before transitioning to either game over or the other player's turn

    public void Update()
    {
        switch (currentState)
        {
            case GameState.WhiteTurn:
                Debug.Log("White Turn Start");
                whitePlayer.IsPlaying = true;
                blackPlayer.IsPlaying = false;
                break;

            case GameState.BlackTurn:
                Debug.Log("Black Turn Start");
                whitePlayer.IsPlaying = false;
                blackPlayer.IsPlaying = true;
                break;

            case GameState.GameOver:
                Debug.Log("Game Over Start");
                whitePlayer.IsPlaying = false;
                blackPlayer.IsPlaying = false;
                break;
        }
        if (Input.GetKeyDown(KeyCode.P)) // Temp if statement to force change game state between players
        {
            changeGameState();
        }
    }

    /// <summary>
    /// These three functions control the actual changing of GameState, setting the enum value to one of the available options.
    /// </summary>
    private void setTurnWhite() { currentState = GameState.WhiteTurn; }
    private void setTurnBlack() { currentState = GameState.BlackTurn; }
    /// <param name="player">This is the player who wins the game</param>
    private void endGame(PlayerClass player)
    {
        currentState = GameState.GameOver;
        Debug.Log(player.Name + " Wins!");
        // Logic to change scene to a victory screen displaying score, names, final time remaining, and option to play again (which should send users back to the start screen).
    }

    /// <summary>
    /// A function to use the currentState in a switch statement where if it is WhiteTurn it checks for if the BlackKing is captured and vice versa for BlackTurn.
    /// </summary>
    private bool CheckWin()
    {
        bool returnValue = false;
        switch (currentState)
        {
            case GameState.WhiteTurn:
                // if black king isCaptured, return true
                break;
            case GameState.BlackTurn:
                // if white king isCaptured, return true
                break;
            default:
                break;
        }
        return returnValue;
    }

    /// <summary>
    /// Switch statement on currentState that calls the setState functions and CheckWin to determine when the game should end.
    /// </summary>
    public void changeGameState()
    {
        switch (currentState)
        {
            case GameState.WhiteTurn:
                if (CheckWin())
                {
                    endGame(whitePlayer);
                } else
                {
                    setTurnBlack();
                }
                break;
            case GameState.BlackTurn:
                if (CheckWin())
                {
                    endGame(blackPlayer);
                }
                else
                {
                    setTurnWhite();
                }
                break;
            default:
                break;
        }
    }
}
