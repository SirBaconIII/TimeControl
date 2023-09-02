using MelonLoader;
using System;
using TimeControl;
using UnityEngine;
using static ModSettings.ModSettingsMain;
using static ModSettings.ControlStructs;

[assembly: MelonInfo(typeof(TimeControlMain), "Time Control", "1.0.0", "SirBaconIII")]
namespace TimeControl
{
    public class TimeControlMain : MelonMod
    {
        public float timeScale = 1;
        public string timeScaleString = "1.0";
        public string timeScaleText = "Time scale: ";

        public override void OnInitializeMelon()
        {
            Type modType = typeof(TimeControlMain);

            object[] controls = new object[]
            {
                new Label(modType.GetField("timeScaleText")),
                new HorizontalSlider(modType.GetField("timeScale"), 0, 10),

                new TextField(modType.GetField("timeScaleString")),
                new Button("Set Time Scale", modType.GetMethod("SetTimeScaleFromString"))
            };

            RegisterMod("TimeControl", this, controls);
        }

        public override void OnLateUpdate()
        {
            Time.timeScale = timeScale;
        }

        public override void OnGUI()
        {
            if (renderGui)
            {
                timeScale = (float)Math.Round(timeScale, 2);
                timeScaleText = $"Time Scale: {timeScale}";
            }
        }

        public void SetTimeScaleFromString()
        {
            if (float.TryParse(timeScaleString, out float floatValue))
            {
                timeScale = floatValue;
            }
        }
    }
}
