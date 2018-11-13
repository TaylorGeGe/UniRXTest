using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UniRx.Triggers;
using UnityEngine.UI;
public class UITrigger03 : MonoBehaviour {

	// Use this for initialization
	void Start () {
        var image = GameObject.Find("Image").GetComponent<Image>();

        //image.OnMouseDragAsObservable

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
