using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameUI : MonoBehaviour
{

    public TMP_Text timer;
    public TMP_Text txtCurrentPlayerName;

    public PlayerClass player1;
    public PlayerClass player2;
    public PlayerClass currentPlayer;
    //private bool timerPressed = false;

    public void ToMenuBtn()
    {
        SceneManager.LoadSceneAsync("MainMenu");
    }

    /// <summary>
    /// Stops and starts timer while alternating between players.
    /// </summary>
    public void TimerButton()
    {

        // Changes players and pauses or unpauses their respective timers.
        if (currentPlayer.IsPaused == true)
        {

            // Start timer
            currentPlayer.TimerStart();
            currentPlayer.IsPlaying = true;
            currentPlayer.IsPaused = false;

            // Set isPaused = false
            txtCurrentPlayerName.text = currentPlayer.Name;
        } 
        else
        {
            currentPlayer.TimerPause();
            // stop timer
            currentPlayer.IsPlaying = false;
            // Set isPaused = true
            currentPlayer.IsPaused = true;
            // Change current player.
            if (currentPlayer == player1) { currentPlayer = player2; }
            else { currentPlayer = player1; }

        }
    }


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // subject to change. Code for testing purposes.
        player1 = new PlayerClass(PlayerNames.player1Name, true);
        player2 = new PlayerClass(PlayerNames.player2Name, false);

        currentPlayer = player1;

    }

    // Update is called once per frame
    void Update()
    {
        //string updatedTimer = currentPlayer.TimeElapsed.ToString("hh\\:mm\\:ss");
        if (currentPlayer.IsPaused == false)
        {
            timer.text = currentPlayer.TimeElapsed();
            
        }


    }

}
