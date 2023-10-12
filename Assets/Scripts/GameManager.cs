using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private int progression;
    private float timer;

    public event Action<int> OnProgressionChanged = (int value) => { };

    private static GameManager instance;

    public static GameManager Instance => instance;

    void Awake()
    {
        instance = this;
    }


    void Update()
    {
        timer += Time.deltaTime;
        if (timer > progression)
        {
            progression++;
            OnProgressionChanged(progression);
        }
    }

    public void ResetProgression(Action OnCallback)
    {
        timer = 0;
        progression = 0;
        OnCallback?.Invoke();
    }
}
