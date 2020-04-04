using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PrikazRezultata : MonoBehaviour {

    public static int rezultat = 0;
    private Text myText;


	// Use this for initialization
	void Start () {
        myText = GetComponent<Text>();
        Reset();
	}

    public void Rezultat(int points)
    {
        rezultat += points;
        myText.text = rezultat.ToString();
    }

    void Reset()
    {
        rezultat = 0;
    }


	// Update is called once per frame
	void Update () {
		
	}
}
