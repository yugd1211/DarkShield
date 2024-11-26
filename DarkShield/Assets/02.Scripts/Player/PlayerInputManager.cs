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
    public bool DashPressed { get; private set; }
    public bool NormalAttackPressed { get; private set; }

    public void OnMove(Context context)
    {
        InputMoveDir = context.ReadValue<Vector2>();
    }

    public void OnDash(Context context)
    {
        if (context.performed && !DashPressed)
        {
            DashPressed = true;
            print($"Dash pressed {DashPressed}");

            // 일정 시간 후 다시 활성화
            Invoke(nameof(ResetDash), 0.5f);
        }
    }

    public void OnNormalAttack(Context context)
    {
        if (context.performed && !NormalAttackPressed)
        {
            NormalAttackPressed = true;
            print($"Dash pressed {DashPressed}");

            // 일정 시간 후 다시 활성화
            Invoke(nameof(ResetNormalAttack), 0.5f);
        }
    }

    private void ResetDash()
    {
        DashPressed = false;
        print($"Dash pressed {DashPressed}");
    }

    private void ResetNormalAttack()
    {
        NormalAttackPressed = false;
        print($"Normal Attack pressed {NormalAttackPressed}");
    }
}