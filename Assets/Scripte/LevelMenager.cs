using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelMenager : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
    public void Loadlevel(string name) {
        Debug.Log("Ucitaj razine: " + name);
        SceneManager.LoadScene(name);
    }

    public void QuitRequest() {
        Debug.Log("Gašenje!");
        Application.Quit();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
