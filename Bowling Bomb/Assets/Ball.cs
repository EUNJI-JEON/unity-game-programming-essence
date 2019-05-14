using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

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

	private void OnTriggerEnter(Collider other)
	{
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
}
