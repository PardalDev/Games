using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishZoneScript : MonoBehaviour {
    public GameObject enableCamera;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (GameObject.FindGameObjectWithTag("Boss") == null) {
            StartCoroutine(TimerRoutine());
        }
    }
    private IEnumerator TimerRoutine()
    {
        yield return new WaitForSeconds(2);
        GameObject enableCamera = GameObject.FindGameObjectWithTag("MainCamera");
        enableCamera.GetComponent<ScrollingScript>().enabled = true;
    }
}
