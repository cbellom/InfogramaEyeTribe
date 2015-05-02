﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class NavigationButton : ObjectInteractable {
	public NavigationState navigationState;
	[SerializeField]
	private float deltaMovementScroll;
	[SerializeField]
	private ScrollRect mScrollRect;
	private RectTransform mContent;

	void Awake(){
		ObjectSelected = HanldeObjectSelected;
		mContent = mScrollRect.content;
	}

	private void HanldeObjectSelected(){
		Vector3 difference = GetDifferenceDirection ();
		//this is the wanted new position for the content
		Vector3 newAnchoredPosition = mContent.anchoredPosition3D + difference;
		mContent.anchoredPosition3D = newAnchoredPosition;

		elapsedTime = timeToTriggerAction - 0.05f;
		isTriggerActivate = false;
		Debug.Log("Go to " + navigationState.ToString());
	}

	private Vector3 GetDifferenceDirection(){
		if (navigationState == NavigationState.Up)
			return new Vector3 (0, deltaMovementScroll, 0);
		if (navigationState == NavigationState.Down)
			return new Vector3 (0, -deltaMovementScroll, 0);
		if (navigationState == NavigationState.Rigth)
			return new Vector3 (deltaMovementScroll, 0, 0);
		if (navigationState == NavigationState.Left)
			return new Vector3 (-deltaMovementScroll, 0, 0);

		return new Vector3 (0, 0, 0);
	}

}
