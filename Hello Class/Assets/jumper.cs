using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jumper : MonoBehaviour {

//여기서 rb는 진짜 오브젝트가 아니라 진짜 오브젝트를 가리키는 참조자, 화살표, 즉 변수임.
//만약 rb가 가리키는 실제 오브젝트가 없으면 명령을 구현할 수 없음
//여기서 rb가 가리키는 오브젝트는 Rigidbody.
	public Rigidbody rb;

	// Use this for initialization
	void Start () {

		rb.AddForce(0,1000,0);
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
