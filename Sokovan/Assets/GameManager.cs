using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

	public GameObject winUI;

	public ItemBox[] itemBoxes;

	public bool isGameOver;

	// Use this for initialization
	void Start () {
		isGameOver = false;
	}
	
	// Update is called once per frame
	void Update () {

		

		if(Input.GetKeyDown(KeyCode.Space)){
			SceneManager.LoadScene(0);
		}

		//if the game is already over
		if(isGameOver == true)
		{
			// End this function->return;
			return;
		}

		int count = 0;
		for(int i =0; i<3; i++)
		{
			if(itemBoxes[i].isOverlaped == true)
			{
				// count=count+1;
				count++;
			}
		}
		if(count>=3)
		{
			isGameOver = true;
			winUI.SetActive(true);
		}
	}
}
