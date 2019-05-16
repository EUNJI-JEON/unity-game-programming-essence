using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

	public LayerMask whatIsProp;

	public ParticleSystem explosionParticle;

	public AudioSource explosionAudio;

	public float maxDamage = 100f;
	public float explosionForce = 1000f;

	//맵 바깥으로 나가서 파괴되지 않는 경우, 버그가 있어서 볼 파괴 안되는 경우 스스로 폭발하도록 제한 시간 설정
	public float lifeTime = 10f;

	//폭발반경
	public float explosionRadius = 20f;

	void Start()
	{
		Destroy(gameObject,lifeTime);
	}

	private void OnDestroy()
	{
		GameManager.instance.OnBallDestroy();
	}

	private void OnTriggerEnter(Collider other)
	{
		// 모든 게임 오브젝트를 다 가져오면 성능낭비. 그러므로 whatIsProp으로 레이어마스크 옵션 줘서 prop인 애들만 가상 구에 걸리도록. 
		//overlapSphere는 구의 중심과 반지름 지정하면 거기 겹치는 모든 collider를 배열로 다 가져옴.
		Collider[] colliders = Physics.OverlapSphere(transform.position,explosionRadius,whatIsProp);

		// collider에 prop있으면 damage받도록 해주기. 거리에 따라 데미지 차등 적용
		for(int i=0; i<colliders.Length; i++)
		{
			Rigidbody targetRigidbody = colliders[i].GetComponent<Rigidbody>();

			//AddExplosionForce는 나 자신의 위치가 그 폭발지점으로부터 얼마나 떨어져있는지 계산해서 스스로 튕겨나가는 효과를 재생
			targetRigidbody.AddExplosionForce(explosionForce,transform.position,explosionRadius);

			Prop targetProp = colliders[i].GetComponent<Prop>();

			//calculateDamage에 상대방의 위치를 넣어주면 얼만큼 데미지를 차등으로 받아야되는지 알 수 있음. 
			float damage = CalculateDamage(colliders[i].transform.position);

			//TakeDamage 발동시켜서 계산한 damage 주기
			targetProp.TakeDamage(damage);
		}


		explosionParticle.transform.parent = null;

		//파티클과 오디오 재생
		explosionParticle.Play();
		explosionAudio.Play();

		
		//파티클도 재생되고 난 후에 지연시간 이후 파괴
		//explosionParticle.duration은 해당효과의 running time(지연시간)
		Destroy(explosionParticle.gameObject, explosionParticle.duration);
		//어딘가에 닿자마자 자기자신 파괴
		Destroy(gameObject);
	}

	//prop에 damage차등으로 주기. 폭발의 중심지에 가까울수록 데미지 크고 멀수록 데미지 적게 주기.
	private float CalculateDamage(Vector3 targetPosition)
	{
		// 나의 위치에서 상대방까지의 거리를 Vector3로 구함
		Vector3 explosionToTarget = targetPosition - transform.position;

		//나의 위치와 목표물 사이의 거리
		float distance = explosionToTarget.magnitude;

		//원의 바깥에서 얼마나 안쪽으로 들어가있는지
		float edgeToCenterDistance = explosionRadius - distance;

		//안쪽으로 들어간 거리/원의 반지름(폭발반경)
		float percentage = edgeToCenterDistance/explosionRadius;

		float damage = maxDamage * percentage;

		//원에서 약간 벗어난 애들 데미지 -입어서 체력이 회복되는 경우가 있으므로 데미지가 음수가 되면 0이 되도록 설정해줘야함.
		//0과 damage중 큰 값이 반환되도록 설정. damage가 0보다 크면 데미지 반환, 그렇지 않으면 0으로.
		damage = Mathf.Max(0,damage);
		return damage;
	}
}
