using UnityEngine;
using System.Collections;

public class GrandParentFind : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    if( Input.GetKeyDown(KeyCode.F) )
        {
            if ( transform.GetComponentInParent<Joint2D>() != null )
            {
                transform.GetComponentInParent<GetKeyObject>().PublicFunction(10);
            } else
            {
                print("this null!");
            }
        }
	}
}
