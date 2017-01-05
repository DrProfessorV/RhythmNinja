using UnityEngine;
using System.Collections;

public class BpmManager : MonoBehaviour {

    private float startBPM = 140.0f;
    public static float currentBPM = 140.0f;
    private float beatsPerSecond;
    private int beatsPerBar;

    public static int beat = 0;
    public static int bar = 0;

    public delegate void OnBeat(int beatNum);
    public delegate void OnBar(int measure);
    public static OnBeat beatEvent;
    public static OnBar barEvent;

    AudioSource audioSource;
    float currentSample;
    float nextBeatSample;
    public float sampleOffset;

    private float lastBeatTime;

    public void Play(float bpm, int signature)
    {
        audioSource = GetComponent<AudioSource>();
        lastBeatTime = Time.time;
        beatsPerSecond = 60.0f / currentBPM;
        beatsPerBar = signature;
    }

    void FixedUpdate()
    {
        if (Time.time - lastBeatTime >= beatsPerSecond)
        {
            beat++;
            lastBeatTime = Time.time;
            if (beatEvent != null)
            {
                beatEvent(beat);
            }
            Debug.Log("Beat");

            if(beat % beatsPerBar == 0)
            {
                bar++;
                if (barEvent != null)
                {
                    barEvent(bar);
                }
                Debug.Log("Bar");
            }
        }
    }
}
