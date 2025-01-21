using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameUI : MonoBehaviour
{

    public TMP_Text timer;

    public PlayerClass player1;
    public PlayerClass player2;
    public PlayerClass currentPlayer;

    public void ToMenuBtn()
    {
        SceneManager.LoadSceneAsync("MainMenu");
    }

    /// <summary>
    /// Stops and starts timer while alternating between players.
    /// </summary>
    public void TimerButton()
    {
        currentPlayer.IsPlaying = true;
        currentPlayer.TimerStart();
    }


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //timeElapsed = new Stopwatch();
        //timeElapsed.Start();

        player1 = new PlayerClass(PlayerNames.player1Name, true);
        player2 = new PlayerClass(PlayerNames.player2Name, false);

        currentPlayer = player1;


    }

    // Update is called once per frame
    void Update()
    {
        //string updatedTimer = currentPlayer.TimeElapsed.ToString("hh\\:mm\\:ss");
        if (currentPlayer.IsPlaying == true) timer.text = currentPlayer.TimeElapsed();

    }

}
