using UnityEngine;
using DG.Tweening;
using System.Collections.Generic;
using System.Collections;

public class Jukebox : MonoBehaviour {
    BpmManager bpm;
    public Material pulseMaterial;
    private BeatObserver observer;

    public List<Obstacle> obstacles;

    void Start()
    {
        observer = GetComponent<BeatObserver>();
        //obstacles = new List<Obstacle>();
        /*bpm = GetComponent<BpmManager>();
        bpm.Play(100, 4);
        BpmManager.beatEvent += OnBeat;*/
    }

    void Update()
    {
        if(observer.beatMask != 0)
        {
            Pulse();
            Advance();
        }
    }

    void OnBeat(int beat)
    {
        pulseMaterial.DOColor(Color.white, 0.1f).OnComplete(() => { pulseMaterial.DOColor(Color.gray, 0.1f); });
    }

    void Pulse()
    {
        pulseMaterial.DOColor(Color.white, 0.1f).OnComplete(() => { pulseMaterial.DOColor(Color.gray, 0.1f); });
    }

    void Advance()
    {
        for(int i = 0; i < obstacles.Count; i++)
        {
            obstacles[i].Advance();
        }
    }
}
