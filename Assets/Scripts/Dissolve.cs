using UnityEngine;
using System.Collections;

public class Dissolve : MonoBehaviour {

	public GameObject resizableObject;

	public float minSize = 0.1f;
	public float maxSize = 0.1f;

	public float shrinkRate = 0.1f;
	public float growRate = 0.1f;

	public bool canShrink = true;
	public bool canGrow = true;

	private float minOpacity = 0.0f;
	private float maxOpacity = 1.0f;

	public bool canTransparent = true;
	public bool canOpaque = true;

	void Update() {
		Resize();
		Opacity();
		Debug.Log(resizableObject.GetComponent<Renderer>().material.color.a);
	}

	void Resize() {
		if (Input.GetButtonDown("Shrink")) {
			canGrow = true;
			if (resizableObject.transform.localScale.y <= minSize)
				canShrink = false;
			else if (canShrink)
				resizableObject.transform.localScale -= new Vector3(1, 1, 0)*shrinkRate;
		}			
		else if (Input.GetButtonDown("Grow")) {
			canShrink = true;
			if (resizableObject.transform.localScale.y >= maxSize)
				canGrow = false;
			else if (canGrow)
				resizableObject.transform.localScale += new Vector3(1, 1, 0)*growRate;
		}
	}

	void Opacity() {
		if (Input.GetButtonDown("Transparent")) {
			canOpaque = true;
			if (resizableObject.GetComponent<Renderer>().material.color.a <= minOpacity)
				canTransparent = false;
			else if (canTransparent)
				resizableObject.GetComponent<Renderer>().material.color -= new Color(1.0f, 1.0f, 1.0f, 0.1f);
		}
		else if (Input.GetButtonDown("Opaque")) {
			canTransparent = true;
			if (resizableObject.GetComponent<Renderer>().material.color.a >= maxOpacity)
				canOpaque = false;
			else if (canOpaque)
				resizableObject.GetComponent<Renderer>().material.color += new Color(1.0f, 1.0f, 1.0f, 0.1f);
		}
			
	}

}