using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollow : MonoBehaviour {

	public enum State{
		//Idle:라운드대기/ready:발사준비/tracking:포탄 발사후 포탄 트래킹하는 상태
		Idle,Ready,Tracking
	}

	private State state {
		//property:사용할 땐 변수처럼 사용하는데 내부에서는 함수처럼 동작. 
		// state=State.Idle; 바깥에선 변수처럼 사용하지만 내부에선 set이라는 처리를 끼워넣음
		//함수 대신에 property 사용하는 이유는 변수처럼 사용하게 해서 처리를 간결하게 보이기 위함. 
		set{
			switch(value)
			{
				case State.Idle:
					targetZoomSize = roundReadyZoomSize;
					break;
				case State.Ready:
					targetZoomSize = readyShotZoomSize;
					break;
				case State.Tracking:
					targetZoomSize = trackingZoomSize;
					break;
			}
		}
	}

	private Transform target;

	//값이 원하는 값으로 도달할 때까지의 지연 시간. 내 위치에서 내가 원하는 위치로까지 0.2초 걸려서 스무스하게 이동.
	public float smoothTime = 0.2f;

	//마지막 순간에 얼마의 속도로 원하는 위치로 이동중이었는지 나타냄
	private Vector3 lastMovingVelocity;

	//타겟으로부터 타겟포지션 가져옴
	private Vector3 targetPosition;

	//줌인-줌아웃
	private Camera cam;
	private float targetZoomSize = 5f;
	//값 지정후 변경 안할 것이므로 const 붙이기. const 처리 해두면 나중에 실수로 다른 값으로 덮어씌우려고할 때 에러가 나서 안 덮어씌워짐. 
	//라운드 대기중일 때 줌 사이즈
	private const float roundReadyZoomSize = 14.5f;
	//포탄 발사 준비중일 때 줌 사이즈
	private const float readyShotZoomSize = 5f;
	private const float trackingZoomSize = 10f;

	//줌인 줌아웃 스무스하게 되도록 처리
	//스무스 기능은 마지막으로 값이 얼마였는지 알아야 동작함. 위에서 lastMovingVelocity해준 것과 같은 원리
	private float lastZoomSpeed;

	void Awake()
	{
		//GetComponent는 나 자신에게 붙어있는 컴포넌트를 검색해서 가져오는 거고 GetComponentInChildren은 자식들한테 있는 컴포넌트 가져옴
		cam = GetComponentInChildren<Camera>();
		state= State.Idle;
	}

	//카메라가 타겟 위치에 맞춰 움직임
	private void Move()
	{
		targetPosition = target.transform.position;

		//smoothdamp는 물체를 스무스하게 이동시키는데 괄호에 들어가는 값(현재위치,옮기려는위치,마지막 순간의 속도,이동에 걸리는 지연속도)
		//ref lastMovingVelocity에서 ref는 매번 값을 갱신해줌
		Vector3 smoothPosition = Vector3.SmoothDamp(transform.position,targetPosition,ref lastMovingVelocity,smoothTime);

		transform.position = targetPosition;
	}

	private void Zoom()
	{
		//smoothdamp는 현재값과 원하는 값이 있을 때 값을 바로 변화시키는 게 아니라 지연시간을 둬서 부드럽게 이어줌.
		//cam.orthographicSize는 현재 카메라의 줌 사이즈
		float smoothZoomSize = Mathf.SmoothDamp(cam.orthographicSize,targetZoomSize,ref lastZoomSpeed,smoothTime);

		cam.orthographicSize = smoothZoomSize;
	}

	//update는 화면 깜빡일 때마다 실행, fixedUpdate는 정해진 간격으로 실행
	private void FixedUpdate()
	{
		//추적할 대상이 존재할 때(추적할 대상이 null이 아닐 때)
		if(target!=null)
		{
			Move();
			Zoom();
		}

	}

	//라운드 시작할 때마다 다시 대기상태(idle)로 돌려줌
	public void Reset()
	{
		state = State.Idle;
	}

    //외부에서 카메라에게 카메라가 추적할 대상이랑 상태 지정하기 위함
	public void SetTarget(Transform newTarget, State newState)
	{
		target = newTarget;
		state = newState;
	}

}
