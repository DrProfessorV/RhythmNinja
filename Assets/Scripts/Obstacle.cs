using UnityEngine;
using DG.Tweening;
using System.Collections;

public class Obstacle : MonoBehaviour {
    public enum Direction { Horizontal, Vertical };
    public enum Motion { Block, Slash };
    Direction _direction;
    Motion _motion;
    Jukebox juke;

    int stepsAway;

   public void Initialize(int totalSteps, Direction direction, Motion motion, Jukebox _juke)
    {
        stepsAway = totalSteps;
        juke = _juke;
    }

	// Use this for initialization
	public void Advance () {
        Debug.Log("Move forward");
        if (stepsAway > 1)
        {
            transform.DOLocalMoveZ(transform.localPosition.z - 2.0f, 0.1f);
        }
        else if(stepsAway == 1)
        {
            Action();
        }
        else
        {
            juke.Remove(this);
            Destroy(gameObject);
        }
        transform.DOScale(1.05f, 0.5f).OnComplete(() => { transform.DOScale(1.2f, 0.5f); });
        stepsAway--;
	}

    void Action()
    {

    }

    IEnumerator CheckMovement(float window)
    {
        yield return new WaitForSeconds(window);
    }
	
	public void Die()
    {

    }
}
