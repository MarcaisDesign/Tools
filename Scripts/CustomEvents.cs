﻿// =======================================================================================
// Wovencore
// by Weaver (Fhiz)
// MIT licensed
// =======================================================================================

using wovencode;
using System;
using UnityEngine;
using UnityEngine.Events;
using Mirror;

namespace wovencode
{
	
	[System.Serializable]
	public class UnityEventString : UnityEvent<string> {}
	
	[System.Serializable]
	public class UnityEventLong : UnityEvent<long> {}
	
	[System.Serializable]
	public class UnityEventInt : UnityEvent<int> {}
	
	[System.Serializable]
	public class UnityEventBool : UnityEvent<bool> {}
	
	[System.Serializable]
	public class UnityEventGameObject : UnityEvent<GameObject> {}
	
	[System.Serializable]
	public class UnityEventConnection : UnityEvent<NetworkConnection> {}
	
}

// =======================================================================================