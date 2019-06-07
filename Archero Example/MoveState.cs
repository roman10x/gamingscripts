﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveState : StateMachineBehaviour
{
    public const string IDLE_STATE = "Idle";
    public float  m_playerSpeed = 2;


    WidgetController m_widgetController;

    private void Awake()
    {
        m_widgetController = WidgetController.GetInstance();
    }

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger(IDLE_STATE);
        if (m_widgetController.GetDirection() == Vector3.zero) { animator.SetTrigger(IDLE_STATE); }
    }

    public override void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Vector3 direction = m_widgetController.GetDirection();

        Vector3 lookatPos = animator.transform.position + direction;
        lookatPos.y = animator.transform.position.y;

        animator.transform.LookAt(lookatPos);
        animator.transform.position = animator.transform.position + (direction * m_playerSpeed * Time.deltaTime);
    }
}






