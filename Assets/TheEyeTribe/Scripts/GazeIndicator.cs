/*
 * Copyright (c) 2013-present, The Eye Tribe. 
 * All rights reserved.
 *
 * This source code is licensed under the BSD-style license found in the LICENSE file in the root directory of this source tree. 
 *
 */

using UnityEngine;
using System.Collections;
using TETCSharpClient;
using TETCSharpClient.Data;
using System;
using System.Collections.Generic;

namespace CompleteProject
{

	public class GazeIndicator : MonoBehaviour, IGazeListener
	{
		private Camera _Camera;
				
		private double _EyesDistance;
		private double _DepthMod;

		
		private GameObject _GazeIndicator;
				
		public delegate void Callback();
		private Queue<Callback> _CallbackQueue;

		private int _ResampleCount;
		
		void Start()
		{
			//Stay in landscape
			Screen.autorotateToPortrait = false;
			
			//fetches scene object handles
			_Camera = GetComponent<Camera>();
			
			_GazeIndicator = GameObject.FindGameObjectWithTag("gazeIndicator");
			
			//init call back queue
			_CallbackQueue = new Queue<Callback>();
			
			//activate C# TET client, default port
			GazeManager.Instance.Activate
				(
					GazeManager.ApiVersion.VERSION_1_0,
					GazeManager.ClientMode.Push
					);
			
			//register for gaze updates
			GazeManager.Instance.AddGazeListener(this);
		}
		
		public void OnGazeUpdate(GazeData gazeData)
		{
			//Add frame to GazeData cache handler
			GazeDataValidator.Instance.Update(gazeData);
		}
		
		void Update()
		{
			if (GazeManager.Instance.IsCalibrated)
			{
				if (!_GazeIndicator.renderer.enabled)
					_GazeIndicator.renderer.enabled = true;
				
				Point2D gazeCoords = GazeDataValidator.Instance.GetLastValidSmoothedGazeCoordinates();
				if (null != gazeCoords)
				{
					// Map gaze indicator
					Point2D gp = UnityGazeUtils.getGazeCoordsToUnityWindowCoords(gazeCoords);
					
					Vector3 screenPoint = new Vector3((float)gp.X, (float)gp.Y, _Camera.nearClipPlane + .1f);
					
					Vector3 planeCoord = _Camera.ScreenToWorldPoint(screenPoint);
					_GazeIndicator.transform.position = planeCoord;
				}
			}
			else
			{
				if (_GazeIndicator.renderer.enabled)
					_GazeIndicator.renderer.enabled = false;
			}
						
			//handle keypress
			if (Input.GetKey(KeyCode.Escape))
			{
				Application.Quit();
			}
		}

		void OnApplicationQuit()
		{
			GazeManager.Instance.CalibrationAbort();
			GazeManager.Instance.RemoveGazeListener(this);
			GazeManager.Instance.Deactivate();
		}

		private void PositionGOFromScreenCoords(GameObject go, Point2D gp)
		{
			//convert to Unity bottom right origo
			Vector3 clone = new Vector3((float)gp.X, (float)(Screen.height - gp.Y), 0);
			
			//center align calib asset on point
			clone.x = clone.x - (go.transform.localScale.x / 2);
			clone.y = clone.y - (go.transform.localScale.y / 2);
			
			//map screen to world coords
			Vector3 cpWorld = _Camera.ScreenToWorldPoint(clone);
			
			//retain depth info
			cpWorld.z = go.transform.position.z;
			
			go.transform.position = cpWorld;
		}
		
		private void SetRendererEnabled(GameObject go, bool isEnabled)
		{
			var renderers = go.GetComponentsInChildren<Renderer>();
			foreach (var r in renderers)
			{
				r.enabled = isEnabled;
			}
			go.renderer.enabled = isEnabled;
		}
		
		public void QueueCallback(Callback newTask)
		{
			lock (_CallbackQueue)
			{
				_CallbackQueue.Enqueue(newTask);
			}
		}
	}
}