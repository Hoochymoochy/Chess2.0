using System;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class PlayerClass
{

    public string Name { get; private set; }
    public int Score {  get; set; }
    public bool IsPlaying { get; set; } = false;
    private bool _timerStarted = false;
    private Stopwatch _stopwatch;
    private string time;

    public PlayerClass(string name, bool isPlayer1) 
    {
        Name = name;
        _stopwatch = new Stopwatch();
    }




    public string TimeElapsed()
    {
        
        string updatedTime = _stopwatch.Elapsed.ToString("hh\\:mm\\:ss");
        
        return updatedTime;
    }

    public void TimerStart()
    {
        if (_timerStarted == false) _timerStarted = true;
        _stopwatch.Start();
    }

    public void TimerPause()
    {
        _stopwatch.Stop();
    }
}
