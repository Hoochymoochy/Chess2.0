using System.Collections.Generic;
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
    private readonly PlayerClass whitePlayer = new PlayerClass("white", true);
    private List<GameObject> whitePieces;
    private readonly PlayerClass blackPlayer = new PlayerClass("black", false);
    private List<GameObject> blackPieces;

    public void Start()
    {
        currentState = GameState.WhiteTurn;
        whitePieces = new List<GameObject>
        {
            GameObject.Find("White Bishop"),
            GameObject.Find("White Bishop (1)"),
            GameObject.Find("White Knight"),
            GameObject.Find("White Knight (1)"),
            GameObject.Find("White Rook"),
            GameObject.Find("White Rook (1)"),
            GameObject.Find("White King"),
            GameObject.Find("White Queen"),
            GameObject.Find("White Pawn (1)"),
            GameObject.Find("White Pawn (2)"),
            GameObject.Find("White Pawn (3)"),
            GameObject.Find("White Pawn (4)"),
            GameObject.Find("White Pawn (5)"),
            GameObject.Find("White Pawn (6)"),
            GameObject.Find("White Pawn (7)"),
            GameObject.Find("White Pawn (8)")
        };
        blackPieces = new List<GameObject>
        {
            GameObject.Find("White Bishop"),
            GameObject.Find("White Bishop (1)"),
            GameObject.Find("White Knight"),
            GameObject.Find("White Knight (1)"),
            GameObject.Find("White Rook"),
            GameObject.Find("White Rook (1)"),
            GameObject.Find("White King"),
            GameObject.Find("White Queen"),
            GameObject.Find("White Pawn (1)"),
            GameObject.Find("White Pawn (2)"),
            GameObject.Find("White Pawn (3)"),
            GameObject.Find("White Pawn (4)"),
            GameObject.Find("White Pawn (5)"),
            GameObject.Find("White Pawn (6)"),
            GameObject.Find("White Pawn (7)"),
            GameObject.Find("White Pawn (8)")
        };

    }

    // TODO: Disable pieces that are not on the active turn.
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
            ChangeGameState();
        }
        if (whitePlayer.IsPlaying)
        {
            DisableBlackPieces();
            EnableWhitePieces();
            // Have white timer count down
        }
        if (blackPlayer.IsPlaying)
        {
            DisableWhitePieces();
            EnableBlackPieces();
            // Have black timer count down
        }
    }

    private void DisableWhitePieces()
    {
        foreach (var piece in whitePieces)
        {
            piece.GetComponent<Collider>().enabled = false;
        }
    }

    private void DisableBlackPieces()
    {
        foreach (var piece in blackPieces)
        {
            piece.GetComponent<Collider>().enabled = false;
        }
    }

    private void EnableWhitePieces()
    {
        foreach (var piece in whitePieces)
        {
            piece.GetComponent<Collider>().enabled = true;
        }
    }

    private void EnableBlackPieces()
    {
        foreach (var piece in blackPieces)
        {
            piece.GetComponent<Collider>().enabled = true;
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
    public void ChangeGameState()
    {
        switch (currentState)
        {
            case GameState.WhiteTurn:
                if (CheckWin())
                {
                    endGame(whitePlayer);
                }
                else
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
