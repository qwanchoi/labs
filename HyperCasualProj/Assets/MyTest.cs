using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MyTest : MonoBehaviour {

    private float pow;
    private Rigidbody rigid;
    bool flag = false;

	void Start () {
        rigid = GetComponent<Rigidbody>();
    }
	
	void Update () {
        if(Input.GetMouseButton(0))
        {
            pow += 0.05f;
            print(pow);
        }

        if (Input.GetMouseButtonUp(0) && !flag)
        {
            flag = true;
            rigid.isKinematic = false;
            rigid.AddForce(transform.forward*pow, ForceMode.Impulse);
        }

    }
}
