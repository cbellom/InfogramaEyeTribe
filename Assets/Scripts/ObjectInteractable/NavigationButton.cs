using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class NavigationButton : ObjectInteractable {
	public DirectionState directionState;
	[SerializeField]
	private float deltaMovementScroll;
	[SerializeField]
	private ScrollRect mScrollRect;
	private RectTransform mContent;

	void Awake(){
		ObjectSelected = HandleObjectSelected;
		mContent = mScrollRect.content;
	}

	private void HandleObjectSelected(){
		Vector3 difference = GetDifferenceDirection ();
		Vector3 newAnchoredPosition = mContent.anchoredPosition3D + difference;
		mContent.anchoredPosition3D = newAnchoredPosition;

		elapsedTime = timeToTriggerAction - 0.05f;
		isTriggerActivate = false;
		Debug.Log("Go to " + directionState.ToString());
	}

	private Vector3 GetDifferenceDirection(){
		if (directionState == DirectionState.Up)
			return new Vector3 (0, -deltaMovementScroll, 0);
		if (directionState == DirectionState.Down)
			return new Vector3 (0, deltaMovementScroll, 0);
		if (directionState == DirectionState.Rigth)
			return new Vector3 (-deltaMovementScroll, 0, 0);
		if (directionState == DirectionState.Left)
			return new Vector3 (deltaMovementScroll, 0, 0);

		return new Vector3 (0, 0, 0);
	}

}
