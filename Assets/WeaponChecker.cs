using UnityEngine;
using System.Collections;

public class WeaponChecker : MonoBehaviour {
    private Quaternion rotQuat;
    private Vector3 rotation;
    public Transform source;

    public static string side;
    public static string orientation;

    public bool IsBlockingHorizontal
    {
        get
        {
            bool isHorizontal = false;
            Vector3 currentRotation = Vector3.zero;

            return isHorizontal;
        }
    }


    void Update()
    {
        transform.rotation = source.rotation;
    }

    void OnCollisionEnter(Collision col)
    {
        string side = col.transform.name;
        Debug.Log(side);
        if(side == "Left" || side == "Right")
        {
            orientation = "Horizontal";
        }
        if(side == "Top" || side == "Bottom")
        {
            orientation = "Vertical";
        }
    }
}
