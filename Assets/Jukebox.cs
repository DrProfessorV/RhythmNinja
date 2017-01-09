using UnityEngine;
using DG.Tweening;
using System.Collections.Generic;
using System.Collections;

public class Jukebox : MonoBehaviour {
    BpmManager bpm;
    public Material pulseMaterial;
    private BeatObserver observer;
    public GameObject spawnPoint;
    public List<Obstacle> obstacles;

    void Start()
    {
        observer = GetComponent<BeatObserver>();

        Obstacle[] tempObs = spawnPoint.GetComponentsInChildren<Obstacle>();
        for (int i = 0; i < tempObs.Length; i++)
        {
            tempObs[i].Initialize(10, Obstacle.Direction.Horizontal, Obstacle.Motion.Block, this);
            obstacles[i] = tempObs[i];
        }
    }

    void Update()
    {
        if(observer.beatMask != 0)
        {
            Pulse();
            Advance();
        }
    }

    public void Remove(Obstacle obstacle)
    {
        obstacles.Remove(obstacle);
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
