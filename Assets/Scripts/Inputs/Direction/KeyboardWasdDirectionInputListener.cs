﻿using UnityEngine;
using System.Collections;

public class KeyboardWasdDirectionInputListener : IDirectionInputListener
{
	private float _direction;
	
	public void Initialize()
	{
		_direction = 0f;
	}
	
	public void Update()
	{
		_direction = 0f;
		_direction += Input.GetButton ("_Keyboard_Left") ? -1f : 0f;
		_direction += Input.GetButton ("_Keyboard_Right") ? +1f : 0f;
	}
	
	public float GetDirection()
	{
		return _direction;
	}
}
