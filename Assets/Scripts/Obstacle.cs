using UnityEngine;
using DG.Tweening;
using System.Collections;

public class Obstacle : MonoBehaviour {
    public enum Direction { Horizontal, Vertical };
    public enum Motion { Block, Slash };
    Direction _direction;
    Motion _motion;

    int stepsAway;

    void Initialize(int totalSteps, Direction direction, Motion motion)
    {
        stepsAway = totalSteps;
    }

	// Use this for initialization
	public void Advance () {
        Debug.Log("Move forward");
        transform.DOLocalMoveZ(transform.localPosition.z - 2.0f, 0.1f);
        transform.DOScale(1.05f, 0.5f).OnComplete(() => { transform.DOScale(1.2f, 0.5f); });
        stepsAway--;
	}

    IEnumerator CheckMovement(float window)
    {
        yield return new WaitForSeconds(window);
    }
	
	public void Die()
    {

    }
}
