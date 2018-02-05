using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class ParticleToolBox : EditorWindow {

	public ParticleSystem copyPs;
	int gridIndex = 0;
	bool displayFlag;
	bool toggleRandomSeed;
	bool toggleScalingMode;
	GameObject sceneAtlasObj;
	Texture tex;
	int atlasNum;
	//string[] guids;
	//Texture[] textures = new Texture[64];

	[MenuItem("Window/FT/ParticleToolBox")]
	static void Open (){
		GetWindow<ParticleToolBox> ();
	}

	void OnGUI(){	
		
		#region CopyTool
		/*
		EditorGUILayout.BeginVertical (GUI.skin.box);
		{
			EditorGUILayout.LabelField ("Copy from...");

			EditorGUILayout.BeginHorizontal (GUI.skin.box);
			{
				copyPs = EditorGUILayout.ObjectField (copyPs, typeof(ParticleSystem), true)as ParticleSystem;

				if (GUILayout.Button ("Set")) {
					SetParticle ();		
				}
			}
			EditorGUILayout.EndHorizontal ();
		}
		EditorGUILayout.EndVertical ();

		EditorGUILayout.BeginVertical (GUI.skin.box);
		{
			EditorGUILayout.LabelField ("Paste to...");

			EditorGUILayout.BeginHorizontal (GUI.skin.box);
			{				
				if (GUILayout.Button ("ALL")) {
					PasteCustomData ();	
					PasteMaterial ();	
					PasteTexAnim ();

				}
				if (GUILayout.Button ("Custom Data")) {
					PasteCustomData ();		
				}
				if (GUILayout.Button ("TexAnim")) {
					PasteTexAnim ();		
				}
				if (GUILayout.Button ("Material")) {
					PasteMaterial ();		
				}
			}
			EditorGUILayout.EndHorizontal ();
		}
		EditorGUILayout.EndVertical ();
		*/
		#endregion

		#region SetLoop
		EditorGUILayout.BeginHorizontal (GUI.skin.box);
		{
			if (GUILayout.Button ("Loop")) {
				SetLoop ();		
			}

			if (GUILayout.Button ("UnLoop")) {
				SetUnLoop ();		
			}
		}
		EditorGUILayout.EndHorizontal ();

		if (GUILayout.Button ("Set Custom Data")) {
			SetData();		
		}	
		#endregion

		#region Random Seed
		/*
		EditorGUILayout.BeginHorizontal (GUI.skin.box);
		{
			if (GUILayout.Button ("Set Auto Random Seed")) {
				if (toggleRandomSeed == false) {
					RandomSeed ();
				} else {
					RandomSeedWithChild ();
				}
			}
			toggleRandomSeed = EditorGUILayout.ToggleLeft ("WithChildren", toggleRandomSeed);

		}
		EditorGUILayout.EndHorizontal ();
		*/
		#endregion

		#region Scaling Mode
		/*
		EditorGUILayout.BeginHorizontal (GUI.skin.box);
		{
			if (GUILayout.Button ("Set Scaling Mode")) {
				ScalingMode ();
			}


		}
		EditorGUILayout.EndHorizontal ();
		*/
		#endregion

		#region Parent Particle
		/*
		EditorGUILayout.BeginHorizontal (GUI.skin.box);
		{
			if (GUILayout.Button ("Set ParentParticle")) {
				SetParentParticle ();
			}
		}
		EditorGUILayout.EndHorizontal ();
		*/
		#endregion

		#region AtlasTexture
		/*
		EditorGUILayout.BeginVertical (GUI.skin.box);
		{
			EditorGUILayout.LabelField ("View AtlasTexture");
			atlasNum = GUILayout.Toolbar(atlasNum, new string[]{"None","Atlas1","Atlas2","Fire1"});
		}
		EditorGUILayout.EndVertical ();
		*/
		#endregion

		ViewCustomDataTex();

		GUILayout.Box (tex, GUILayout.Width (320), GUILayout.Height (320));

	}

	#region ViewCustomDataTex()
	void ViewCustomDataTex(){
		if (Selection.activeTransform != null) {
			var obj = Selection.activeTransform;
			if (obj.GetComponent<Renderer> () == null) {
				tex = AssetDatabase.LoadAssetAtPath ("Assets/FT_Infinity/Editor/Data/icon_none.png", typeof(Texture))as Texture;
				return;
			}
			if (obj.GetComponent<Renderer> ().sharedMaterial != null) {			
				if (obj.GetComponent<Renderer> ().sharedMaterial.shader.name == "FT/DoubleDistortion") {
					tex = AssetDatabase.LoadAssetAtPath ("Assets/FT_Infinity/Editor/Data/icon_doubleDistortion.png", typeof(Texture))as Texture;
				} else if (obj.GetComponent<Renderer> ().sharedMaterial.shader.name == "FT/Dissolve") {
					tex = AssetDatabase.LoadAssetAtPath ("Assets/FT_Infinity/Editor/Data/icon_dissolve.png", typeof(Texture))as Texture;
				} else if (obj.GetComponent<Renderer> ().sharedMaterial.shader.name == "FT/DissolveSimple") {
					tex = AssetDatabase.LoadAssetAtPath ("Assets/FT_Infinity/Editor/Data/icon_dissolveSimple.png", typeof(Texture))as Texture;
				} else if (obj.GetComponent<Renderer> ().sharedMaterial.shader.name == "FT/Shockwave") {
					tex = AssetDatabase.LoadAssetAtPath ("Assets/FT_Infinity/Editor/Data/icon_shockwave.png", typeof(Texture))as Texture;
				} else if (obj.GetComponent<Renderer> ().sharedMaterial.shader.name == "FT/Slash") {
					tex = AssetDatabase.LoadAssetAtPath ("Assets/FT_Infinity/Editor/Data/icon_slash.png", typeof(Texture))as Texture;
				} else if (obj.GetComponent<Renderer> ().sharedMaterial.shader.name == "FT/Simple") {
					tex = AssetDatabase.LoadAssetAtPath ("Assets/FT_Infinity/Editor/Data/icon_simple.png", typeof(Texture))as Texture;
				} else if (obj.GetComponent<Renderer> ().sharedMaterial.shader.name == "FT/UVscroll") {
					tex = AssetDatabase.LoadAssetAtPath ("Assets/FT_Infinity/Editor/Data/icon_uvScroll.png", typeof(Texture))as Texture;
				} else if (obj.GetComponent<Renderer> ().sharedMaterial.shader.name == "FT/UVscroll_Fresnel") {
					tex = AssetDatabase.LoadAssetAtPath ("Assets/FT_Infinity/Editor/Data/icon_uvScrollFresnel.png", typeof(Texture))as Texture;
				} else if (obj.GetComponent<Renderer> ().sharedMaterial.shader.name == "FT/HeatDistortion") {
					tex = AssetDatabase.LoadAssetAtPath ("Assets/FT_Infinity/Editor/Data/icon_heatDistortion.png", typeof(Texture))as Texture;
				} else {
					tex = AssetDatabase.LoadAssetAtPath ("Assets/FT_Infinity/Editor/Data/icon_none.png", typeof(Texture))as Texture;
				}
			} else {
				tex = AssetDatabase.LoadAssetAtPath ("Assets/FT_Infinity/Editor/Data/icon_none.png", typeof(Texture))as Texture;
			}
		} else {
			tex = AssetDatabase.LoadAssetAtPath ("Assets/FT_Infinity/Editor/Data/icon_none.png", typeof(Texture))as Texture;
		} 
	}
	#endregion

	void SetParticle(){
		var obj = Selection.activeGameObject;
		copyPs = obj.GetComponent<ParticleSystem> ();

	}

	void PasteCustomData(){
		if (copyPs != null) {
			if (copyPs.customData.enabled == false) {
				Debug.Log("Not Active Source Particle Custom Data Module...");
				return;
			}
			if (Selection.activeGameObject.GetComponent<ParticleSystem> ().customData.enabled == false){	
				SetData ();
				GetSetCustomData ();
			} else {
				GetSetCustomData ();
			}
		
		}
	}

	void GetSetCustomData(){
		var obj = Selection.activeGameObject;
		ParticleSystem ps = obj.GetComponent<ParticleSystem> ();

		var customData = copyPs.customData.GetVector (ParticleSystemCustomData.Custom1, 0);
		ps.customData.SetVector (ParticleSystemCustomData.Custom1, 0, customData);
		customData = copyPs.customData.GetVector (ParticleSystemCustomData.Custom1, 1);
		ps.customData.SetVector (ParticleSystemCustomData.Custom1, 1, customData);
		customData = copyPs.customData.GetVector (ParticleSystemCustomData.Custom1, 2);
		ps.customData.SetVector (ParticleSystemCustomData.Custom1, 2, customData);
		customData = copyPs.customData.GetVector (ParticleSystemCustomData.Custom1, 3);
		ps.customData.SetVector (ParticleSystemCustomData.Custom1, 3, customData);
		customData = copyPs.customData.GetVector (ParticleSystemCustomData.Custom2, 0);
		ps.customData.SetVector (ParticleSystemCustomData.Custom2, 0, customData);
		customData = copyPs.customData.GetVector (ParticleSystemCustomData.Custom2, 1);
		ps.customData.SetVector (ParticleSystemCustomData.Custom2, 1, customData);
		customData = copyPs.customData.GetVector (ParticleSystemCustomData.Custom2, 2);
		ps.customData.SetVector (ParticleSystemCustomData.Custom2, 2, customData);
		customData = copyPs.customData.GetVector (ParticleSystemCustomData.Custom2, 3);
		ps.customData.SetVector (ParticleSystemCustomData.Custom2, 3, customData);
	}

	void PasteTexAnim(){
		if (copyPs != null) {
			if (copyPs.textureSheetAnimation.enabled == false) {
				Debug.Log("Not Active Source Particle Texture Animation Module...");
				return;
			}
			var obj = Selection.activeGameObject;
			ParticleSystem ps = obj.GetComponent<ParticleSystem> ();
			var ts = ps.textureSheetAnimation;
			ts.enabled = true;
			ts.numTilesX = copyPs.textureSheetAnimation.numTilesX;
			ts.numTilesY = copyPs.textureSheetAnimation.numTilesY;
			ts.animation = copyPs.textureSheetAnimation.animation;
			ts.cycleCount = copyPs.textureSheetAnimation.cycleCount;
			ts.frameOverTime = copyPs.textureSheetAnimation.frameOverTime;
			ts.frameOverTimeMultiplier = copyPs.textureSheetAnimation.frameOverTimeMultiplier;
			ts.startFrame = copyPs.textureSheetAnimation.startFrame;
			ts.startFrameMultiplier = copyPs.textureSheetAnimation.startFrameMultiplier;
			ts.uvChannelMask = copyPs.textureSheetAnimation.uvChannelMask;
		}
	}

	void PasteMaterial(){
		if (copyPs != null) {
			var obj = Selection.activeGameObject;
			if (copyPs.GetComponent<Renderer> ().sharedMaterials != null) {
				obj.GetComponent<Renderer> ().sharedMaterials = copyPs.GetComponent<Renderer> ().sharedMaterials;
			}
		}

	}

	void SetLoop(){
		var obj = Selection.activeGameObject;
		ParticleSystem[] ps = obj.GetComponentsInChildren<ParticleSystem> ();
		for (int i = 0; i < ps.Length; i++) {
			var main = ps [i].main;
			main.loop = true;
		}
	}

	void SetUnLoop(){
		var obj = Selection.activeGameObject;
		ParticleSystem[] ps = obj.GetComponentsInChildren<ParticleSystem> ();
		for (int i = 0; i < ps.Length; i++) {
			var main = ps [i].main;
			main.loop = false;
		}
	}

	void SetData(){
		var obj = Selection.activeGameObject;
		ParticleSystem ps = obj.GetComponent<ParticleSystem> ();
		ParticleSystemRenderer psr = obj.GetComponent<ParticleSystemRenderer> ();

		psr.SetActiveVertexStreams(new List<ParticleSystemVertexStream>(new ParticleSystemVertexStream[] {
			ParticleSystemVertexStream.Position,
			ParticleSystemVertexStream.Normal,
			ParticleSystemVertexStream.Color,
			ParticleSystemVertexStream.UV,
			ParticleSystemVertexStream.UV2,
			ParticleSystemVertexStream.Custom1XYZW,
			ParticleSystemVertexStream.Custom2XYZW,
			ParticleSystemVertexStream.StableRandomXY
		}));	

		var customData = ps.customData;
		customData.enabled = true;
		customData.SetMode (ParticleSystemCustomData.Custom1, ParticleSystemCustomDataMode.Vector);
		customData.SetVectorComponentCount (ParticleSystemCustomData.Custom1, 4);
		customData.SetMode (ParticleSystemCustomData.Custom2, ParticleSystemCustomDataMode.Vector);
		customData.SetVectorComponentCount (ParticleSystemCustomData.Custom2, 4);

	}

	void CleanUp(){
	
	}

	void RandomSeed(){
		var obj = Selection.activeGameObject;
		obj.GetComponent<ParticleSystem> ().useAutoRandomSeed = true;
	}

	void RandomSeedWithChild(){
		var obj = Selection.activeGameObject;
		ParticleSystem[] ps = obj.GetComponentsInChildren<ParticleSystem> ();
		for (int i = 0; i < ps.Length; i++) {
			ps [i].useAutoRandomSeed = true;
		}
	}

	void ScalingMode(){
		var obj = Selection.activeGameObject;
		var ps = obj.GetComponent<ParticleSystem> ().main;
		ParticleSystem[] pss = obj.GetComponentsInChildren<ParticleSystem> ();
		for (int i = 0; i < pss.Length; i++) {
			var main = pss [i].main;
			main.scalingMode = (ParticleSystemScalingMode)0;
		}
		ps.scalingMode = (ParticleSystemScalingMode)1;
	}

	void SetParentParticle(){
		var obj = Selection.activeGameObject;
		if (obj.GetComponent<ParticleSystem> () == null) {
			obj.AddComponent<ParticleSystem> ();
		}
		ParticleSystem ps = obj.GetComponent<ParticleSystem> ();
		ParticleSystemRenderer psr = obj.GetComponent<ParticleSystemRenderer> ();
		var emission = ps.emission;
		var shape = ps.shape;
		emission.enabled = false;
		shape.enabled = false;
		psr.enabled = false;
	}

	void AtlasDisplay(){
		if (displayFlag == false) {
			if (sceneAtlasObj == null) {
				GameObject atlasObj = AssetDatabase.LoadAssetAtPath ("Assets/_Library/Editor/Data/EditorTempObj.prefab", typeof(GameObject)) as GameObject;
				sceneAtlasObj = PrefabUtility.InstantiatePrefab (atlasObj) as GameObject;
				displayFlag = true;
				SetAtlasID ();
			} else {
				displayFlag = true;
				sceneAtlasObj.SetActive(true);
			}

		} else {
			if (sceneAtlasObj == null) {
				GameObject atlasObj = AssetDatabase.LoadAssetAtPath ("Assets/_Library/Editor/Data/EditorTempObj.prefab", typeof(GameObject)) as GameObject;
				sceneAtlasObj = PrefabUtility.InstantiatePrefab (atlasObj) as GameObject;
				displayFlag = true;
				SetAtlasID ();
			} else {
				displayFlag = false;
				sceneAtlasObj.SetActive(false);
			}
		}
	}

	void SetAtlasID(){
	
	
	}
}
