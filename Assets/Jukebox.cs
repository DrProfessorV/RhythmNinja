using UnityEngine;
using DG.Tweening;
using System.Collections;

public class Jukebox : MonoBehaviour {
    BpmManager bpm;
    public Material pulseMaterial;

    void Start()
    {
        bpm = GetComponent<BpmManager>();
        bpm.Play(100, 4);
        BpmManager.beatEvent += OnBeat;
    }

    void OnBeat(int beat)
    {
        pulseMaterial.DOColor(Color.white, 0.1f).OnComplete(() => { pulseMaterial.DOColor(Color.gray, 0.1f); });
    }
}
