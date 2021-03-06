
using System;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using Wovencode;
using Wovencode.Network;
using Wovencode.DebugManager;

namespace Wovencode
{
	
	// ===================================================================================
	// ProjectConfigTemplate
	// ===================================================================================
	[CreateAssetMenu(fileName = "New Project Configuration", menuName = "Configuration/New Project Configuration", order = 999)]
	public partial class ProjectConfigTemplate : ScriptableObject
	{

		[Header("Project Configuration")]
		[SerializeField]protected NetworkType networkType;
		public bool globalDebugMode;
		
		[Header("Servers")]
		public ServerInfoTemplate[] serverList;
		
		[Header("Spawnable Prefabs Folders")]
		[Tooltip("Adding spawnable prefabs to network manager will only search in the folders below")]
		public string[] spawnablePrefabFolders;		
		
		static ProjectConfigTemplate _instance;
		
		protected const string isServer = "_SERVER";
    	protected const string isClient = "_CLIENT";
		
		// -------------------------------------------------------------------------------
		// singleton
		// -------------------------------------------------------------------------------
		public static ProjectConfigTemplate singleton
		{
			get
			{
				if (!_instance)
					_instance = Resources.FindObjectsOfTypeAll<ProjectConfigTemplate>().FirstOrDefault();
				return _instance;
			}
		}
		
		// -----------------------------------------------------------------------------------
		// OnValidate
		// -----------------------------------------------------------------------------------
		public void OnValidate()
		{
#if UNITY_EDITOR
			if (networkType == NetworkType.Server)
			{
				EditorTools.RemoveScriptingDefine(isClient);
				EditorTools.AddScriptingDefine(isServer);
				debug.Log("[ProjectConfig] Switched to SERVER mode.");
			}
			else if (networkType == NetworkType.HostAndPlay)
			{
				EditorTools.AddScriptingDefine(isServer);
				EditorTools.AddScriptingDefine(isClient);
				debug.Log("[ProjectConfig] Switched to HOST & PLAY mode.");
			}
			else if (networkType == NetworkType.Development)
			{
				EditorTools.AddScriptingDefine(isServer);
				EditorTools.AddScriptingDefine(isClient);
				debug.Log("[ProjectConfig] Switched to DEVELOPMENT mode.");
			}
			else
			{
				EditorTools.AddScriptingDefine(isClient);
				EditorTools.RemoveScriptingDefine(isServer);
				debug.Log("[ProjectConfig] Switched to CLIENT mode.");
			}
#endif
		}
	
		// -------------------------------------------------------------------------------
	}

}

// =======================================================================================
