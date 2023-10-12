using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour, ISubject
{
    private int progression;
    private float timer;

    /*private List<IObserver> observers = new List<IObserver>();

    public int Progression { get { return progression; } }

    public void Attach (IObserver observer)
    {
        observers.Add(observer);
    }

    public void Detach(IObserver observer)
    {
        observers.Remove(observer);
    }

    public void Notify()
    {
        foreach (IObserver observer in observers)
        {
            observer.Execute(this);
        }
    }
    */
    public event Action<int> OnProgressionChanged = (int value) => { };


    //Singleton
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
            //Notify();
            OnProgressionChanged(progression);
        }
    }

    /*public void ResetProgression(Action OnCallback)
    {
        timer = 0;
        progression = 0;
        OnCallback?.Invoke();
    }*/
}
