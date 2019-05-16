using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallShooter : MonoBehaviour {

	public CamFollow cam;
	public Rigidbody ball;

	public Transform firePos;

	public Slider powerSlider;

	public AudioSource shootingAudio;

	public AudioClip fireClip;
	public AudioClip chargingClip;

	public float minForce=15f;
	public float maxForce=30f;

	public float chargingTime = 0.75f;

	private float currentForce;

	//누르고 있는 동안 1초단위로 충전되는 힘(charging power per second while on click).
	private float chargeSpeed;

	//발사됐는지 체크. 발사됐는데 다음 라운드 되기 전에 또 발사되는 거 막기 위해(to avoid overlapping shooting in the round)
	private bool fired;

	//OnEnable은 컴포넌트가 꺼져있다가 켜질 때마다 발동됨. 한번만 실행되는 start와 달리 켜질 때마다 실행됨.
	private void OnEnable()
	{
		currentForce = minForce;

		powerSlider.value = minForce;
		fired = false;
	}

	private void Start()
	{
		//chargeSpeed는 누르고 있는 동안 1초 단위로 충전되는 힘의 크기(속도)
		chargeSpeed=(maxForce-minForce)/chargingTime;
	}

	private void Update()
	{
		//최초 발사 이후에 라운드 끝날 때까지 재발사나 사운드 다시 재생 등 다른 프롭들 실행 안되도록 해줌
		if(fired==true)
		{
			return;
		}


		powerSlider.value = minForce;
		//case1:힘이 maxForce 이상으로 충전됐는데도 발사되지 않은 경우 강제 발사처리
		if(currentForce >= maxForce && !fired)
		{
			currentForce = maxForce;
			//발사처리
			Fire();
		}
		//case2:발사버튼을 누른 순간(이 때부터 힘 충전)
		else if(Input.GetButtonDown("Fire1"))
		{
			//연사되도록 fired=false;설정
			fired = false;
			currentForce=minForce;
			shootingAudio.clip = chargingClip;
			shootingAudio.Play();
		}
		//case3:발사버튼을 누르고 있는 동안
		else if(Input.GetButton("Fire1"))
		{
			currentForce = currentForce + chargeSpeed * Time.deltaTime;

			powerSlider.value = currentForce;
		}
		//case4:버튼에서 손을 뗀 순간->발사해야됨
		else if(Input.GetButtonUp("Fire1")&& !fired)
		{
			//발사처리
			Fire();

		}

	}

	private void Fire()
	{
		fired=true;
		Rigidbody ballInstance = Instantiate(ball,firePos.position,firePos.rotation);

		//forward는 transform의 내장기능으로 firePos의 앞쪽 방향을 벡터3로 반환함.
		//속도=힘*방향
		ballInstance.velocity = currentForce * firePos.forward;

		shootingAudio.clip = fireClip;
		shootingAudio.Play();

		//발사했으니 힘 다시 줄여줌
		currentForce = minForce;

		cam.SetTarget(ballInstance.transform,CamFollow.State.Tracking);
	}

}
