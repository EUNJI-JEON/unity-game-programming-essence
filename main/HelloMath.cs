using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelloMath : MonoBehaviour {

	// Use this for initialization
	void Start () {

		/* 
				int a =5;
		int b =7;
		int sum=a+b;
		Debug.Log(sum);

		sum=a-b;
		Debug.Log(sum);

		//중간자 안거치고 바로 연산해도 됨

		Debug.Log(a*b);
		Debug.Log(a/b);
		Debug.Log(b/a);
		Debug.Log(a%b);
		Debug.Log(b%a);

		*/

		/*

				int i = 0;

		i = i+1;

		Debug.Log(i);

		// 위처럼 어떤 값에 하나만 더해주는 경우 굉장히 많기 때문에 i++로 아예 코드 내장되어있음
		//i++;는 i=i+1;과 같음

		i++;

		Debug.Log(i);

		i=i-1;

		Debug.Log(i);
		// i-1;의 축약형은 i--;
		i--;

		Debug.Log(i);



		 */


		// i++;랑 ++i;랑 모두 한개 더해주는 건 같은데 i++는 다른 연산한 다음에 연산하고
		// ++i는 해당 연산부터 실행함

		int i = 0;

		//0
		Debug.Log(i++);

		//1
		Debug.Log(i);

		//2
		Debug.Log(++i);

		//2
		Debug.Log(i);


		//자기 자신에게 연산할 때 축약 가능(short cut)
		//j = j+5; 랑 j+=5; 랑 같음
		//j = j-5; 랑 j-=5;랑 같음
		//j = j*5;랑 j*=5;랑 같음
		// j = j/5;랑 j/=5; 랑 같음
		// j = j % 5; 랑 j%=5;랑 같음









		
	}
	
	
		
	
}
