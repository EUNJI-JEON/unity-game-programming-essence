using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelloCSharp : MonoBehaviour {

	// Use this for initialization
	void Start () {
		//형변환(캐스팅):서로 다른 데이터들끼리 변환을 통해 값을 주고받을 수 있다는 것
		//자동으로 될 때도 있고 명시적으로 지정해줘야할 때도 있음

		int height=170;
		float heightDetail = 170.3f;

		

		//heightDetail = height ;하면 height=170이 170.3f보다 작으니까 오류 안남
		//근데 height = heightDetail;하면 작은거에 큰거 할당하니까 오류남.즉, 잃어버리는 정보가 생기는 것.
		//자동 형변환(잃어버리는 정보가 없으면)
		heightDetail = height;

		//직접 명시해야 하는 경우(잃어버리는 정보가 있을 때)
		//잃어버리는 정보를 감수하고 넣겠다는 뜻에서 앞에다가 타겟이 되는 타입을 추가해줘야함
		// 이 경우는 (int)를 추가. 이걸 캐스팅이라고함
		height = (int)heightDetail;


		// 조건문 if문
		// if의 ()안에는 조건문이 들어가는데 true나 false가 명확하게 지정이 되는 문장이 들어가야함

		// ==는 왼쪽값과 오른쪽값이 같은지 다른지 비교. 조건문이 참이면 if문의 {} 바디가 실행됨.
		//if 조건문이 거짓이면 else의 바디가 실행됨.

		bool isBoy = true;

		if(isBoy == true){

			Debug.Log("나는 남자다");
		}
		else
		{
			Debug.Log("나는 여자다");
		}

		isBoy = false;

		if(isBoy == true){

			Debug.Log("나는 남자다");
		}
		else
		{
			Debug.Log("나는 여자다");
		}

		//isBoy 자체가 조건문이라서 isBoy==true 이런식으로 안써주고 그냥 isBoy만 써줘도 됨

		if(isBoy)
		{
			Debug.Log("나는 남자다");

		}
		
		//앞에 !느낌표 붙이면 해당 조건문이 false일 때라는 의미. 즉 isBoy가 아닐때.
		if(!isBoy)
		{
			Debug.Log("나는 여자다");
		}

		//!=는 왼쪽값과 오른쪽값이 다른지 비교. 

		
		if(isBoy != true)
		{
			Debug.Log("나는 여자다");
		}

		if(isBoy != false)
		{
			Debug.Log("나는 남자다");
		}

		// 이런 애들을 관계 연산자라 부름. == != < > >= <=

		int love =40;

		if(love<50)
		{
			Debug.Log("베드엔딩");
		}
		else
		{
			Debug.Log("해피엔딩");
		}

		int age=17;

		// or || 혹은
		// A || B , A 나 B 둘 중 하나라도 참이면 참

		if(age>=60 || age<=17)
		{
			Debug.Log("일을 하면 안된다");

		
		}

		// &&는 And

		if(age>=60 && age < 60)
		{
			Debug.Log("일할 나이");
		}

		if(age<=7)
		{
			Debug.Log("유치원에 간다");
		}
		else if(age<12) //age가 7보다 크고 12보다 작을 때.
		{
			Debug.Log("초등학교로 간다");

		}
		else if(age<15) //age >=12 그리고 age<15
		{
			Debug.Log("중학교로 간다");
		}
		else if(age<18)
		{
			Debug.Log("고등학교로 간다");
		}
		else
		{
			Debug.Log("성인");
		}

		Debug.Log(" !true =" + (!true));

		//조건이 많아질 때마다 else if 문을 끝없이 덧붙여야 한다는 단점 존재 
		// 좀 더 간편하게 하기 위한게 switch(변수)
		//case가 끝날 땐 꼭 break; 해줘야함
		//case에 year가 해당하지 않을 때를 위해 default 지정

		int year = 2017;
		switch(year)
		{
			case 2012:
				Debug.Log("레미제라블");
				break;

			case 2015:
				Debug.Log("러브라이브");
				break;

			case 2016:
				Debug.Log("곡성");
				break;

			case 2017:
				Debug.Log("트랜스포머5");
				break;

			default:
				Debug.Log("연도가 해당사항 없음");
				break;
		}

		// 루프문 loop 반복문들
		// for 문 순번을 매기면서 반복하는 데 최적화되어있음.
		// for문은 괄호안에 세가지가 들어가는데 초기화; 조건; 업데이트
		//i - 0,1,2,3,4,5,6,7,8,9까지만 실행되고 i = 10이 되면 루프탈출

		for(int i =0; i<10; i++)
		{
			Debug.Log("현재 순번: " + i);

		}
		Debug.Log("루프 끝");

		//while은 괄호안에 들어오는 조건이 참인 동안엔 영원히 돌아감

		bool isShot = false;
		int index=0;
		int luckyNumber = 4;
		while(isShot == false)
		{
			index = index + 1;
			Debug.Log("현재 시도: " + index);
			if(index == luckyNumber)
			{
				Debug.Log("총알에 맞았다");
				isShot = true;
			}
			else
			{
				Debug.Log("총알에 맞지 않았다");
			}

		}

		//while은 조건이 만족해야 돌지만 do while 은 조건이 만족하지 않아도 무조건 첫 번째 루프는 실행함. 즉, 한 번은 돌아감

		do
		{
			Debug.Log("do-while");

		}while(isShot == false);




	}
	

}
