using UnityEngine;
using System.Collections;

public class ExplosionParts : MonoBehaviour {

    public GameObject[] activeParts;
    public GameObject[] explosionParts;

    private Vector3[] partsDefaultPos;
    private Quaternion[] partsDefaultQua;

    public Texture texture;

    public float burnDuration = 4f;

    private Coroutine co;

	void Start () {

        partsDefaultPos = new Vector3[explosionParts.Length];
        partsDefaultQua = new Quaternion[explosionParts.Length];
        for (int i = 0; i < explosionParts.Length; i++)
        {
            partsDefaultPos[i] = explosionParts[i].transform.localPosition;
            partsDefaultQua[i] = explosionParts[i].transform.localRotation;
        }

    }
	
	// Update is called once per frame
	void Update () {
        if ( Input.GetKeyDown( KeyCode.Space ) )
        {
            for (int i=0; i < activeParts.Length; i++)
            {
                activeParts[i].SetActive(false);
            }

            for(int i=0; i < explosionParts.Length; i++)
            {
                explosionParts[i].GetComponent<MeshRenderer>().material.SetFloat(Shader.PropertyToID("_BurnOut"), 0f);
                explosionParts[i].SetActive(true);
            }
            if (co != null )StopCoroutine(co);
            co = StartCoroutine(BurnOut());
        }

        if ( Input.GetKeyDown(KeyCode.R) )
        {
            for (int i = 0; i < activeParts.Length; i++)
            {
                activeParts[i].SetActive(true);
            }
            if(co != null)
                StopCoroutine(co);

            for (int i = 0; i < explosionParts.Length; i++)
            {
                explosionParts[i].SetActive(false);
                explosionParts[i].transform.localPosition = partsDefaultPos[i];
                explosionParts[i].transform.localRotation = partsDefaultQua[i];
                explosionParts[i].GetComponent<MeshRenderer>().material.SetFloat( Shader.PropertyToID("_BurnOut"), 0f );
                //StartCoroutine(BurnOut());
            }

        }
	}

    IEnumerator BurnOut()
    {
        print("startBurn!");
        float startTime = Time.time;

        while(Time.time - startTime < burnDuration )
        {
            foreach(var value in explosionParts)
            {
                //mat.SetFloat(Shader.PropertyToID("_BurnOut"), Mathf.Lerp(0, 1f, (Time.time - startTime) / burnDuration) );
                value.GetComponent<MeshRenderer>().material.SetTexture("_Diffuse", texture);
                value.GetComponent<MeshRenderer>().material.SetFloat( Shader.PropertyToID("_BurnOut"), Mathf.Lerp(0, 1.25f, (Time.time - startTime) / burnDuration) );
                //Shader.PropertyToID("_BurnOut")
            }
            yield return null;
        }

        yield return null;
    }
}
