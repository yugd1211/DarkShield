using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using Context = UnityEngine.InputSystem.InputAction.CallbackContext;

public class PlayerInputManager : MonoBehaviour
{
	public Vector2 InputMoveDir { get; private set; }
	public bool isDash { get; set; }
	public bool isSlash { get; set; }
	public bool isSkill { get; set; }

	public void OnMove(Context context)
	{
		InputMoveDir = context.ReadValue<Vector2>();
	}

	public void OnDash(Context context)
	{
		if (context.performed && !isDash)
		{
			isDash = true;
		}
	}

	public void OnSlash(Context context)
	{
		if (context.performed && !isSlash)
		{
			isSlash = true;
		}
	}

	public void OnSkill(Context context)
	{
		if (context.performed && !isSkill)
		{
			isSkill = true;
		}
	}
}