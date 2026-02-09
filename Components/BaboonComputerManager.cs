using BaboonComputer.Classes;
using BaboonComputer.Interfaces;
using BaboonComputer.Screens;
using GorillaNetworking;
using UnityEngine;

namespace BaboonComputer.Components
{
	public class BaboonComputerManager : MonoBehaviour
	{
#pragma warning disable CS8618
		// this will have a value if the mod loads correctly
		public static BaboonComputerManager Instance;
#pragma warning restore CS8618

		public Screen CurrentScreen
		{
			get
			{
				field ??= new Room();
				return field;
			}
			set => field = value;
		}

		public Action<string>? TransceiverSetText;

		public ConstrainedTextWriter ScreenWriter
		{
			get
			{
				field ??= new ConstrainedTextWriter(Constants.MonitorColumns);
				return field;
			}
		}

		public string ScreenText
		{
			get => ScreenWriter.GetText();
			set
			{
				var newText = "";
				ScreenWriter.SetText(value, ref newText);

				TransceiverSetText?.Invoke(newText);
			}
		}

		public void OnKeyPressed(ComputerKey key)
		{
			var letScreenProcess = (key != ComputerKey.Up) && (key != ComputerKey.Down);

			if (letScreenProcess)
			{
				try { Screen.OnKeyPressed(key); }
				catch (Exception ex)
				{
					Debug.LogError($"Error in screen: {ex}");
				}
			} else
			{
				// next / prev screen
			}
		}

		private void Start()
		{
			Instance = this;
		}
	}
}
