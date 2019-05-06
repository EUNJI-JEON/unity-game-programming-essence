using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBox : MonoBehaviour {

	private Renderer myRenderer;

	public Color touchColor;
	private Color originalColor;

	// Use this for initialization
	void Start () {
		myRenderer = GetComponent<Renderer>();
		originalColor = myRenderer.material.color;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	//OnTriggerEnter는 트리거인 콜라이더와 충돌할 때 자동으로 실행
	//Enter는 충돌을 한 그 순간
	
	void OnTriggerEnter(Collider other){
		if(other.tag=="EndPoint"){
			myRenderer.material.color=touchColor;

		}
	}

	//OnTriggerExit는 충돌했다가 떼어질 때
	void OnTriggerExit(Collider other){
		if(other.tag=="EndPoint"){
			myRenderer.material.color=originalColor;

		}
	}

	//OnTriggerStay는 충돌하고 있는 동안. 즉 붙어있는 동안.
	void OnTriggerStay(Collider other){
		if(other.tag=="EndPoint"){
			myRenderer.material.color=touchColor;

		}
	}
}
