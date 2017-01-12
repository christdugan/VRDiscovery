using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayMovie : MonoBehaviour {

	void Start () {
		((MovieTexture)GetComponent<Renderer>().material.mainTexture).Play();
	}
	
	void Update () {
		
	}
}
