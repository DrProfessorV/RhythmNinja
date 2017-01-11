using UnityEngine;
using DG.Tweening;
using System.Collections;

public class Obstacle : MonoBehaviour {
    public enum Direction { Horizontal, Vertical };
    public enum Motion { Block, Slash };
    Direction _direction;
    Motion _motion;
    Jukebox juke;
    Animator anim;

    int stepsAway;
    private bool checking;

   public void Initialize(int totalSteps, Direction direction, Motion motion, Jukebox _juke)
    {
        stepsAway = totalSteps;
        juke = _juke;
        anim = GetComponent<Animator>();
    }

	// Use this for initialization
	public void Advance () {
        //Debug.Log("Move forward");
        if (stepsAway > 2)
        {
            transform.DOLocalMoveZ(transform.localPosition.z - 2.0f, 0.1f);
        }
        else if (stepsAway == 2)
        {
            Windup();
            transform.DOLocalMoveZ(transform.localPosition.z - 2.0f, 0.1f);
        }
        else if (stepsAway == 1)
        {
            Action();
        }
        else if (stepsAway == 0)
        {
            //Destroy(gameObject);
            //juke.Remove(this);
        }
        transform.DOScale(1.05f, 0.5f).OnComplete(() => { transform.DOScale(1.2f, 0.5f); });
        stepsAway--;
	}

    void Windup()
    {
        if (_motion == Motion.Block)
        {
            if (_direction == Direction.Horizontal)
            {
                anim.SetInteger("motion", 1);
            }
            else if (_direction == Direction.Vertical)
            {
                anim.SetInteger("motion", 2);
            }
        }
    }

    void Action()
    {
        {
            if (_motion == Motion.Block)
            {
                anim.SetTrigger("attack");
            }
        }
        StartCoroutine(CheckMovement(0.5f));
    }

    void Update()
    {
        if(checking)
        {
            if(_motion == Motion.Block)
            {
                if (_direction == Direction.Horizontal)
                {
                    if(WeaponChecker.orientation == "Horizontal")
                    {
                        BlockConfirm();
                    }
                }
                else if (_direction == Direction.Vertical)
                {
                    if(WeaponChecker.orientation == "Vertical")
                    {
                        BlockConfirm();
                    }
                }
            }
        }
    }

    void BlockConfirm()
    {
        Debug.Log("Block Successful!");
        anim.SetInteger("motion", 0);
        anim.SetTrigger("die");
        checking = false;
    }

    IEnumerator CheckMovement(float window)
    {
        checking = true;
        yield return new WaitForSeconds(window);
        checking = false;
    }
}
