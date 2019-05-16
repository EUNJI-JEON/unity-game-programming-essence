using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class GameManager : MonoBehaviour {

	public UnityEvent onReset;

	//싱글톤 위한 static 변수 생성
	public static GameManager instance;

	public GameObject readyPannel;
	public Text scoreText;
	public Text bestScoreText;

	public Text messageText;

	//isRoundActive는 현재 라운드가 진행중인지 아닌지 표시. 게임 플레이중이면 true, 대기중이면 false
	public bool isRoundActive = false;

	private int score = 0;

	//라운드가 대기상태일 땐 슈팅용 스크립트 off.
	public ShooterRotator shooterRotator;
	public CamFollow cam;

	// Use this for initialization
	void Awake () {
		//자기자신을 싱글톤 자리에 넣어줌
		instance = this;
		UpdateUI();
	}

	void Start()
	{
		StartCoroutine("RoundRoutine");
	}

	public void AddScore(int newScore)
	{
		score += newScore;
		UpdateBestScore();
		UpdateUI();
	}

	//playerPreference는 베스트 스코어 저장해서 게임 껐다 켜도 점수 남도록 해줌. key,value 저장하면 게임이 끝난 뒤에도 키,밸류값이 파일로 저장돼서 가져올 수 있음.
	//키값만 기억하면 밸류를 찾아올 수 있음. 파이썬의 딕셔너리와 비슷. 값을 덮어씌울 수도 있음. 
	//해당키에 값이 있으면 가져오고 없으면 새로운 키-밸류 셋을 만들어줌. 키는 string.
	//단. playerPreference는 해킹당하기 쉬워서 플레이어가 임의로 조작할 수 있음 주의.
	void UpdateBestScore()
	{
		if(GetBestScore()<score)
		{
			PlayerPrefs.SetInt("BestScore",score);
		}
	}

	//저장되어있는 베스트 스코어 가져옴-키값만 입력
	int GetBestScore()
	{
		int bestScore = PlayerPrefs.GetInt("BestScore");
		return bestScore;
	}
	
	// 스코어텍스트 갱신
	void UpdateUI () 
	{
		scoreText.text="Score: "+score;
		bestScoreText.text="Best Score: " + GetBestScore();
	}

	//볼이 폭발할 때 play에서 end로 넘어가기 때문에 볼이 폭발하는 순간을 알고있어야함. 이를 위해 볼이 폭발할 때 자동으로 발동되는 함수
	public void OnBallDestroy()
	{
		UpdateUI();
		//라운드 끝났음 명시. play 상태를 탈출하기 위한 조건
		isRoundActive=false;
	}

	//라운드 넘어갈 때마다 리셋하는 함수
	public void Reset()
	{
		score=0;
		UpdateUI();

		//라운드를 다시 처음부터 시작
		StartCoroutine("RoundRoutine");

	}

	IEnumerator RoundRoutine()
	{

		//onReset 발동->등록된 함수도 발동됨.
		onReset.Invoke();
		//Ready
		readyPannel.SetActive(true);
		cam.SetTarget(shooterRotator.transform,CamFollow.State.Idle);
		//대기상태이므로 shooterRotator 꺼줌
		shooterRotator.enabled = false;

		isRoundActive = false;

		messageText.text="Ready";
		yield return new WaitForSeconds(3f);
	
		//Play
		//play는 볼이 바닥에 닿아서 폭발할 때까지 꺼지면 안되므로 무한루프
		isRoundActive = true;
		readyPannel.SetActive(false);

		shooterRotator.enabled = true;

		cam.SetTarget(shooterRotator.transform,CamFollow.State.Ready);
		while(isRoundActive == true)
		{
			yield return null;
		}
		
		//End
		readyPannel.SetActive(true);
		shooterRotator.enabled = false;

		messageText.text="Wait for Next Round";
		yield return new WaitForSeconds(3f);

		Reset();
	}
}
