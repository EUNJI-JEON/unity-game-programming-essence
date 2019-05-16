using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterRotator : MonoBehaviour {


	// enum은 한번에 한가지값 가짐
	private enum RotateState {
		Idle,Vertical,Horizontal,Ready
	}

	private RotateState state = RotateState.Idle;

	public float verticalRotateSpeed = 360f;

	public float horizontalRotateSpeed = 360f;

	public BallShooter ballShooter;

	void Update()
	{

		switch(state)
		{
			case RotateState.Idle:
				if(Input.GetButtonDown("Fire1")){
				state = RotateState.Horizontal;
				}
			break;

			case RotateState.Horizontal:
				if(Input.GetButton("Fire1"))
				{
					transform.Rotate(new Vector3(0,horizontalRotateSpeed*Time.deltaTime,0));
				} else if(Input.GetButtonUp("Fire1"))
				{
					state=RotateState.Vertical;
				}
			break;

			case RotateState.Vertical:
				if(Input.GetButton("Fire1"))
				{
					transform.Rotate(new Vector3(-verticalRotateSpeed*Time.deltaTime,0,0));
				}
				else if(Input.GetButtonUp("Fire1"))
				{
					state=RotateState.Ready;
					ballShooter.enabled = true;
				}
			break;

			case RotateState.Ready:
			break;
		}

	}

	private void OnEnable()
	{
		//이전 라운드 회전값 리셋(identity는 rotation값이 0,0,0)
		transform.rotation = Quaternion.identity;
		state=RotateState.Idle;
		//shooterRotator가 처음 켜지거나 껐다 켜지면서 리셋됐을 때 볼슈터 기능 꺼줌
		ballShooter.enabled = false;
	}
}
