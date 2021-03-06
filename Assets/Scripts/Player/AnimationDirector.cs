﻿using UnityEngine;
using System.Collections;

public class AnimationDirector : MonoBehaviour
{
	private Animator _animator;

	public void Awake()
	{
		_animator = GetComponent<Animator>();
	}

	public void Update()
	{
		if (Game.Inst.m_collision_prober.HasHurtFeedback() || Game.Inst.m_health.current <= 0)
		{
			_animator.Play("hurt");
			_animator.speed = 1f;
			return;
		}

		if (Game.Inst.m_scoring.HasCancerFeedback())
		{
			_animator.Play("cancer");
			_animator.speed = 1f;
			return;
		}

		if (Game.Inst.m_scoring.HasCollectibleFeedback())
		{
			_animator.Play("loli");
			_animator.speed = 1f;
			return;
		}

		if (!Game.Inst.m_collision_prober.IsGrounded())
		{
			_animator.Play("jump");
			_animator.speed = 1f;
			return;
		}

		if (Game.Inst.m_collision_prober.IsGrounded())
		{
			if (Game.Inst.m_walker.IsMoving())
			{
				_animator.Play("walk");
				_animator.speed = Game.Inst.m_walker.running ? 1.75f : 1.5f;
				return;
			}
			else
			{
				_animator.Play("idle");
				_animator.speed = 2.25f;
				return;
			}
		}

		if (Game.Inst.m_collision_prober.IsGrounded())
		{
		}
		
		_animator.Play("walk");
	}
}
