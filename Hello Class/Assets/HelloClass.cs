using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelloClass : MonoBehaviour {

	// Use this for initialization
	void Start () {

		Animal jack = new Animal();
		jack.name = "JACK";
		jack.sound = "Bark";
		jack.weight = 4.5f;

		Animal nate = new Animal();
		nate.name = "NATE";
		nate.sound = "Nyaa";
		nate.weight = 1.2f;

		Animal annie = new Animal();
		annie.name = "ANNIE";
		annie.sound = "Wee";
		annie.weight = 0.8f;

		nate = jack;

		nate.name = "JIMMY";
		nate.sound = "Cheeze";
		//이렇게하면 nate만 바뀔 것 같지만 jack도 jimmy,cheeze로 바껴버림.
		//Call by reference - 변수는 실존하는 변수를 가리키는 참고자일뿐. 
		//변수가 가리키는 오브젝트가 바뀌면 기존에 변수가 가리키고 있던 오브젝트는 사라짐. 
		//변수는 실제로 존재하는 게 아니라, 실제로 존재하는 오브젝트를 가리키는 화살표일뿐.
		//변수는 세개지만 실제 존재하는 오브젝트는 두개인 현상이 발생

		//Call by reference가 중요한 이유는 ‘가져와서 쓴다’는 개념을 위해. 
		//이걸 이해 못하면 유니티에서 가장 중요한 컴포넌트를 변수로 가져와서 쓴다는 걸 구현할 수가 없음.
		
			
		
		
	}

}
//public은 어떤 오브젝트밖에서 그 내부에 있는 게 보인다는 것. 
// 즉, 중괄호 밖에서도 쓰일 수 있게하려면 public 해줘야함.

public class Animal {
	public string name;
	public string sound;
	public float weight;

}