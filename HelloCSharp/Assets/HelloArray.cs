using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelloArray : MonoBehaviour {

	// Use this for initialization
	void Start () {

		//여러개의 값을 하나의 변수로 다루게 해주는게 배열.
		int[] scores = new int[10];

		//scores[0][1][2][3][4][5][6][7][8][9]
		//값이 많아져도 변수를 일일이 만들어줄 필요가 없음. score1 score2 이런식으로 할 필요가 없는 거
		//scores라는 변수로 10개 값을 다루게 된 것.

		scores[0] = 90;
		scores[1] = 45;
		scores[2] = 60;
		scores[3] = 70;
		scores[4] = 56;
		scores[5] = 80;
		scores[6] = 90;
		scores[7] = 100;
		scores[8] = 45;
		scores[9] = 14;

		//out of index
		// scores[10] = 30;	

		//배열은 for문이랑 궁합이 좋음
		for(int i = 0; i <10; i++)
		{
			Debug.Log("학생" + i + "번째의 점수 "  + scores[i]);
		}	
		// 배열에서 한번 방의 갯수가 정해지면 방의 갯수를 벗어날 수 없음
		//만약 방의 갯수를 새로 늘리고 싶으면 scores = new int[20];
		//근데 이렇게하면 기존에 있던것들 다 날아가고 새로 생김
	}

}
