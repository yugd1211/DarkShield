using UnityEngine;

public class StageTmpFollowCamera : MonoBehaviour
{
	public Transform target;
	public float smoothTime = 0.3f;
	private Vector3 velocity = Vector3.zero;

	private void Start()
	{
		target = GameObject.Find("Player").transform;
	}

	private void Update()
	{
		Vector3 targetPosition = target.TransformPoint(new Vector3(0, 15, 0));
		transform.position = targetPosition;
	}
}
