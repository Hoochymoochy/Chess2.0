using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;


public class Menu : MonoBehaviour
{
    public TMP_InputField inputP1Name;
    public TMP_InputField inputP2Name;

    /// <summary>
    /// Called on startGame button press. Takes player names and stores them in static variables before the actual switch.
    /// </summary>
    public void SceneSwitch()
    {
        string s1 = inputP1Name.text;
        string s2 = inputP2Name.text;

        if (string.IsNullOrWhiteSpace(s1) || s1 == "") s1 = "player 1";
        if (string.IsNullOrWhiteSpace(s2) || s2 == "") s2 = "player 2";

        PlayerNames.player1Name = s1;
        PlayerNames.player2Name = s2;
        
        Debug.Log(PlayerNames.player1Name + "\n" + PlayerNames.player2Name);

        SceneManager.LoadSceneAsync("SampleScene");
    }


}
