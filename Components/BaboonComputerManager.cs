using BaboonComputer.Classes;
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
            set => ScreenWriter.SetText(value, ref GorillaComputer.instance.screenText.currentText);
        }

        private void Start()
        {
            Instance = this;

            // go find gorillacomputer
        }
    }
}
