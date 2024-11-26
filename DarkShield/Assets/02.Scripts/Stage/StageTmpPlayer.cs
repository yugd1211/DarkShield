using UnityEngine;

public class StageTmpPlayer : MonoBehaviour
{
	public float speed = 5.0f;
	private void Update()
	{
		float moveHorizontal = Input.GetAxis("Horizontal");
		float moveVertical = Input.GetAxis("Vertical");

		Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

		transform.Translate(movement * speed * Time.deltaTime, Space.World);
	}


	private void OnCollisionEnter(Collision other)
	{
		if (other.gameObject.CompareTag("Portal"))
		{
			StageManager.Instance.ChangeStage(StageManager.Instance.currStage.nextStage);
		}
	}

}
