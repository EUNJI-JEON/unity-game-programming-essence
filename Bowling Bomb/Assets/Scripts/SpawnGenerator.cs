using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnGenerator : MonoBehaviour {

	//small prop,big prop 두 개이므로 GameObject를 배열로 가져옴 []
	public GameObject[] propPrefabs;
	private BoxCollider area;

	//찍어낼 prop 갯수
	public int count = 100;

	//프롭을 매번 찍어내면 성능 낭비이므로 프롭이 파괴되어도 프롭을 파괴하지 않고 게임 오브젝트를 꺼버리는 걸로 파괴를 구현
	// 처음 만든 프롭을 파괴하지 않고 파괴될 때 껐다가 다음 라운드에 위치만 바꿔서 다시 켜주면 됨. 마치 랜덤하게 프롭이 다시 만들어지는 것처럼 보이도록.
	// 이를 위해 프롭들을 출력하기 위한 리스트 생성. 이 리스트 안에 prop들의 위치를 랜덤으로 재설정해주면 됨. 꺼진 오브젝트 켜주고.
	private List<GameObject> props = new List<GameObject>();
	

	// Use this for initialization
	void Start () {
		//유니티의 BoxCollider컴포넌트 가져와서 area(size)가져옴
		area=GetComponent<BoxCollider>();

		for(int i=0; i<count; i++)
		{
			//프롭 생성 함수
			//게임 시작했을 때 정해진 갯수의 애들 찍어내고 시작
			Spawn();
			
		}

		//처음 오브젝트를 찍어낼 땐 box collider가 찍어내는 범위 정해줘서 유용한데 이후에는 쓸데없이 물리적 충돌효과 일으킬 수 있음.
		// 그러므로 생성 이후에는 꺼줌
		area.enabled = false;
		
	}
	

	//스폰이 발동할 때마다 하나의 게임 오브젝트를 랜덤하게 찍어내는 함수
	//미리 만들어진 prefabs 중에서 랜덤하게 하나를 골라서 getrandomposition을 통해 가져온 위치에 찍어내는게 spawn 함수의 역할
	//prefab은 한 가지 이상 사용함. 
	private void Spawn()
	{
		int selection = Random.Range(0,propPrefabs.Length);

		GameObject selectedPrefab = propPrefabs[selection];

		Vector3 spawnPos = GetRandomPosition();

		GameObject instance = Instantiate(selectedPrefab,spawnPos,Quaternion.identity);

		//찍혀나온 애를 리스트에 등록. 이렇게하면 라운드 넘어갈 때마다 미리 만들어진 애들 전부 추적 가능
		props.Add(instance);
	}
	//찍어낼 때마다 랜덤한 좌표를 가져다줄 함수
	private Vector3 GetRandomPosition()
	{
		//나 자신의 위치를 중심으로 랜덤한 범위를 지정하므로 먼저 baseposition 필요
		Vector3 basePosition = transform.position;
		//랜덤한 위치를 지정할 범위-boxCollider area의 size
		Vector3 size =area.size;

		//Random.Range는 괄호안에 두 숫자 넣어주면 그 사이의 랜덤한 값을 반환
		//range min max 값에 나 자신의 위치에서 가로 길이의 절반만큼 왼/오른쪽으로.
		float posX = basePosition.x + Random.Range(-size.x/2f,size.x/2f);

		float posY = basePosition.y + Random.Range(-size.y/2f,size.y/2f);

		float posZ = basePosition.z + Random.Range(-size.z/2f,size.z/2f);

		Vector3 spawnPos = new Vector3(posX,posY,posZ);

		return spawnPos;
	}

	//게임 오브젝트들의 위치를 랜덤 포지션으로 다시 지정. 라운드 재생할 때마다 실행될 함수.
	public void Reset()
	{
		for(int i = 0; i<props.Count; i++)
		{
			props[i].transform.position = GetRandomPosition();
			//혹시 꺼져있는 프롭있을 수 있으니 켜줌
			props[i].SetActive(true);
		}
	}
}
