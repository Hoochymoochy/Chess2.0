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

    public PlayerClass(string name, bool isPlayer1) { Name = name; }




    public string TimeElapsed()
    {
        string updatedTime = _stopwatch.Elapsed.ToString("hh\\:mm\\:ss");
        return updatedTime;
    }

    public void TimerStart()
    {
        if (_timerStarted == false)
        {
            _stopwatch = new Stopwatch();
            _stopwatch.Start();
            _timerStarted = true;
        }
        _stopwatch.Start();
    }
}
