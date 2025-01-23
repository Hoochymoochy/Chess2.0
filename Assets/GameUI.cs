using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameUI : MonoBehaviour
{

    public TMP_Text timer;

    public PlayerClass player1;
    public PlayerClass player2;
    public PlayerClass currentPlayer;
    private bool timerPressed = false;

    public void ToMenuBtn()
    {
        SceneManager.LoadSceneAsync("MainMenu");
    }

    /// <summary>
    /// Stops and starts timer while alternating between players.
    /// </summary>
    public void TimerButton()
    {
        if (timerPressed == false)
        {
            // Start timer / maybe also switches players?
            // Set timerPressed = true
        } 
        else
        {
            // stop timer
            // Set timerPressed = false
        }
    }


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        player1 = new PlayerClass(PlayerNames.player1Name, true);
        player2 = new PlayerClass(PlayerNames.player2Name, false);

        currentPlayer = player1;


    }

    // Update is called once per frame
    void Update()
    {
        //string updatedTimer = currentPlayer.TimeElapsed.ToString("hh\\:mm\\:ss");
        if (currentPlayer.IsPlaying == true)
        {
            timer.text = currentPlayer.TimeElapsed();
            
        }


    }

}
