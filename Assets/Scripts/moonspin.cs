using UnityEngine;
using System.Collections;

public class moonspin : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(new Vector3 (0, 10, 0) * Time.deltaTime);
    }
}
