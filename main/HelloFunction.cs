using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelloFunction : MonoBehaviour {

	// Use this for initialization
	void Start () {

		float sizeOFCircle=30f;

		float radius = GetRadius(sizeOFCircle);

		Debug.Log("원의 사이즈: " + sizeOFCircle + " 원의 반지름: " + radius);
		
	}

	//원의 반지름 구하는 함수 정의
	float GetRadius(float size)
	{
		float pi = 3.14f;

		float tmp = size/pi;

		//Mathf는 유니티의 수학함수 라이브러리고 그 중 Sqrt로 제곱근 구할 수 있음

		//Mathf.Sqrt에서 .(온점)은 점 앞에 꺼의 내부의 요소, 즉 뒤에꺼를 갖고오겠다는 의미 

		float radius= Mathf.Sqrt(tmp);

		return radius;
	}

	// 이 때 start랑 GetRadius 두 함수 모두 float radius를 중복으로 갖고있는데도 오류 안남
	//그 이유는 함수 내부에 있는 함수는 외부에서 관측 안됨- 이게 return을 사용하는 이유
	//이걸 scope라 부름 어떤 scope 안에 있는 애는 밖에서 안보임. 중괄호 단위가 scope.
	//void 는 공허, 즉 아무것도 반환하지 않기 때문에 return이 있어도 되고 없어도 됨
	

}
