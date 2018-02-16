using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingPhoto : MonoBehaviour {

	public Renderer PhotoFront;

	public void Initialise(Texture2D photo) {
		PhotoFront.material.mainTexture = photo;
	}
}
