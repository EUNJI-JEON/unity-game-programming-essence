using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour {

	// Use this for initialization
	void Start () {

		// 콘솔 출력
		Debug.Log("Hello World!");
		

		//숫자형 변수

		// int는 소숫점이 없는 정수

		int age= 23;
		int money= -1000;

		Debug.Log(age);
		Debug.Log(money);

		// floating point : float은 소숫점을 갖고 있는 숫자이고 반드시 끝에 f가 붙어야함
		// 소숫점 아래 7자리까지만 정확함. f는 float이라 값이 부정확할 수도 있다는 의미
		// float은 32비트 사용

		float height = 169.12345f;

		// double 은 float의 두배의 메모리를 사용 64비트. 그래서 f 안붙임
		// 소숫점 아래 15자리까지만 정확하고 그 이상은 근삿값으로 처리. 게임에서는 성능때문에 double 많이는 사용 안함
		double pi = 3.14159265359;

		//bool은 true, false 둘 중 하나만 가짐

		bool isBoy=true;
		bool isGirl=false;

		//character : char는 한 문자 저장

		char grade = 'A';

		//string은 문장

		string movieTitle="러브라이브";

		//문장 뒤에 어떤 값을 붙이면 하나의 문장으로 만들어줌

		Debug.Log("내 나이는!: " + age);
		Debug.Log("내가 가진 돈은!: " + money);
		Debug.Log("내 키는! " + height);
		Debug.Log("원주율은! " + pi);
		Debug.Log("내 성저은! "+ grade);
		Debug.Log("명작 영화 " + movieTitle);

		// var는 할당하는 값을 기준으로 타입을 결정
		// 만약 문장이 오면 string, 숫자가 오면 int가 자동으로 되는 것.
		var myName = "I_eunji";
		//string myName = "I_eunji";와 같음
		var myAge=23;
		//int myAge = 23;과 같음
		//변수 타입명이 길 때 타이핑하기 싫으니까 var를 써줌.

		Debug.Log("은지의 닉네임: " + myName);

	}
	

}
