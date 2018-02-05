using UnityEngine;
using UnityEditor;

public class CreateStateScriptableObjectAssets : Editor
{
	[MenuItem("Impulse/Finite State Machine/Create New States From Selected", false)]
	public static void CreateNewState()
	{
		var scripts = Selection.objects;

		Debug.Log(string.Format("Trying to create {0} new ScriptableObjects...", scripts.Length));

		foreach(var script in scripts)
		{
			var monoscript = script as MonoScript;

			if(monoscript != null)
			{
				if(monoscript.GetClass() != null && monoscript.GetClass().IsSubclassOf(typeof(ScriptableObject)) && !monoscript.GetClass().IsAbstract)
				{
					var asset = CreateInstance (monoscript.name);
					var path = string.Format ("Assets/{0}.asset", monoscript.name);
					AssetDatabase.CreateAsset (asset, path);
					EditorUtility.FocusProjectWindow ();
					Selection.activeObject = asset;

					Debug.Log("Created " + path);
				}
				else
				{
					Debug.LogError(string.Format("Script {0} does not inherit from ScriptableObject or is not Creatable (maybe abstract class?)", monoscript.name));
				}
			}
			else
			{
				Debug.LogError(string.Format("Object of type {0} is not a MonoScript", script.GetType()));
			}
		}
	}

	[MenuItem("Impulse/Finite State Machine/Create New States From Selected", true)]
	public static bool CreateNewStateValidate()
	{
		var scripts = Selection.objects;

		foreach(var script in scripts)
		{
			var monoscript = script as MonoScript;

			if (monoscript != null)
			{
				if(monoscript.GetClass() != null && monoscript.GetClass().IsSubclassOf(typeof(ScriptableObject))  && !monoscript.GetClass().IsAbstract)
				{
					return true;
				}
			}
		}
		return false;
	}
}