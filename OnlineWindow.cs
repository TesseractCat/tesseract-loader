using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Runtime.Serialization.Json;
using System.Web;
using System.IO;
using System.Text;
using System.Xml;

namespace TesseractModLoader.Window
{
	public class Mod
	{
		public string Name { get; set; }
		public string Author { get; set; }
		public string Description { get; set; }
		public string Link { get; set; }
	}

	public class RootObject
	{
		public List<Mod> Mods { get; set; }
	}

	public class Online : MonoBehaviour {
		public Rect onlineWindowRect = new Rect(20,20,375,600);
		public bool onlineWindow = false;
		public List<Mod> Mods;
		public string modListUrl = "https://raw.githubusercontent.com/TesseractCat/tesseract-loader/master/ModList.json";

		public void Start() {
			var client = new WebClient ();
			var json = client.DownloadString (modListUrl);
			UnityEngine.Debug.Log (json);
		}

		public void OnGUI() {
			GUI.skin = TesseractModLoader.Window.UI.UISkin;
			if (onlineWindow) {
				onlineWindowRect = GUI.Window (3, onlineWindowRect, OnlineWindow, "Online Mod Browser",GUI.skin.GetStyle("window"));
			}
		}

		public void OnlineWindow(int windowID) {
			GUILayout.Label ("Online mod database");
			GUILayout.Label ("---");
			/*foreach (Mod m in Mods) {
				GUILayout.Button (m.Name);
			}*/
			GUI.DragWindow ();
		}

		public void Update() {
			if (Input.GetKey (KeyCode.LeftControl) && Input.GetKeyDown (KeyCode.U) || Input.GetKey (KeyCode.RightControl) && Input.GetKeyDown (KeyCode.U)) {
				onlineWindow = !onlineWindow;
			}
		}
	}
}

