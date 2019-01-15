using UnityEngine;
using System.Collections;

public class GetKeyObject : MonoBehaviour {

    public GameObject child;

    void Start() {

    }

    // Update is called once per frame
    void Update() {
        if (Input.GetKeyDown(KeyCode.P))
        {
            child.SetActive(!child.activeSelf);
        }
    }

    public void PublicFunction(int _value) {
        print("get : " + _value);
    }
}
