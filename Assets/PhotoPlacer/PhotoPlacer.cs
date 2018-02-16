using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleARCore;

public class PhotoPlacer : MonoBehaviour {

	//reference to the prefab that we'll be instantiating
	public Object PhotoObject;
	
	// Update is called once per frame
	void Update () {
		//on screen tap...
		if(Input.GetMouseButtonDown(0)) {
			//we create a new texture with size = screen resolution, read the screen pixels to it, and apply
			Texture2D NewTex = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, true);
			NewTex.ReadPixels(new Rect(0, 0, Screen.width, Screen.height), 0, 0);
			NewTex.Apply();

			//create a new floating photo prefab, and give it our new texture
			GameObject NewObj = Instantiate(PhotoObject) as GameObject;
			NewObj.GetComponent<FloatingPhoto>().Initialise(NewTex);

			//create an ARCore anchor at the current position and rotation
			Anchor NewAnchor = Session.CreateAnchor(Frame.Pose.position, Frame.Pose.rotation);
			//set our new object to be a child of it, at the same position and rotation
			//(so it will move as the anchor moves)
			NewObj.transform.parent = NewAnchor.gameObject.transform;
			NewObj.transform.localPosition = Vector3.zero;
			NewObj.transform.localRotation = Quaternion.identity;
		}
	}
}
