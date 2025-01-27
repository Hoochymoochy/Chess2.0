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
    public bool IsPaused { get; set; } = true;
    private Stopwatch _stopwatch;
    private string time;

    public PlayerClass(string name, bool isPlayer1) 
    {
        Name = name;
        _stopwatch = new Stopwatch();
    }

    /// <summary>
    /// Returns the elapsed time.
    /// </summary>
    /// <returns></returns>
    public string TimeElapsed()
    {
        
        string updatedTime = _stopwatch.Elapsed.ToString("hh\\:mm\\:ss");
        
        return updatedTime;
    }

    /// <summary>
    /// Resumes timer. Starts timer if it has not been started yet.
    /// </summary>
    public void TimerStart()
    {
        if (_timerStarted == false) _timerStarted = true;
        _stopwatch.Start();
    }

    /// <summary>
    /// Pauses timer.
    /// </summary>
    public void TimerPause()
    {
        _stopwatch.Stop();
    }
}
