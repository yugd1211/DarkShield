using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTmpPlayer : MonoBehaviour
{
    public float speed = 6.0f;
    public float gravity = -9.1f;
    public float jumpHeight = 2.0f;
    public float turnSmoothTime = 0.1f; // 회전 속도 조절을 위한 시간

    private CharacterController controller;
    private Vector3 velocity;
    private bool isGrounded;
    private float turnSmoothVelocity; // 회전 속도 값을 저장하는 변수

    private void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    private void Update()
    {
        isGrounded = controller.isGrounded;

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        // 이동 입력
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");
        Vector3 move = new Vector3(moveX, 0, moveZ).normalized;

        if (move.magnitude >= 0.1f)
        {
            // 이동 방향을 따라 캐릭터가 회전하도록 설정
            float targetAngle = Mathf.Atan2(move.x, move.z) * Mathf.Rad2Deg; // 목표 각도 계산
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0, angle, 0); // 캐릭터 회전

            controller.Move(move * speed * Time.deltaTime);
        }

        // 점프 처리
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        // 중력 처리
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }

}
