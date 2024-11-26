using UnityEngine;

public class Stage : MonoBehaviour
{
	// 해당 객체들 구현 될 시 GameObject -> 해당 객체로 변경
	public GameObject player;
	public GameObject StageManager;
	//
	public Stage nextStage;
	public Transform playerStartPos;

	private void Start()
	{
		Init();
	}

	public virtual void Init()
	{
		playerStartPos = GameObject.Find("PlayerStartPosition").transform;
		if (player == true && playerStartPos == true)
			player.transform.position = playerStartPos.position;
	}
}
