using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PortalScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        SceneManager.LoadScene("Level2");
    }
    /*private void OnTriggerEnter2D(Collider2D collision)
    {
        SceneManager.LoadScene("Menu");
    }*/
}
