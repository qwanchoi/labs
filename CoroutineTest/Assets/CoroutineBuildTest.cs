using UnityEngine;
using UnityEngine.UI;

using System.Collections;

public class CoroutineBuildTest : MonoBehaviour {
    public Text txtField;
    int i = 0;

	// Use this for initialization
	void Start () {
        
	}

    private void OnEnable()
    {
        StartCoroutine(myRoutine());
    }

    IEnumerator myRoutine()
    {
        while(true)
        {
            txtField.text = txtField.text + " " + i;
            i++;
            yield return new WaitForSeconds(2f);
            txtField.text = txtField.text + " stop!";
        }
    }
}
