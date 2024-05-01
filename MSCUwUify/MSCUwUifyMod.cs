using Harmony;
using MSCLoader;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;

namespace MSCUwUify
{
    [UsedImplicitly]
    public class MscUwUifyMod : Mod
    {
        public override string Name => "My Summer Car UwUifier";
        public override string ID => "uwuify";
        public override string Description => "The best mod to be ever made";
        public override string Author => "アカツキ";
        public override string Version => "1.0";

        internal static SettingsCheckBox Uwuifier, Reidentifier, Smileys, Stutter, Yu;
        internal static SettingsDropDownList Identity;

        public override void ModSetup()
        {
            base.ModSetup();

            SetupFunction(Setup.Update, ApplyUwuification);
            SetupFunction(Setup.OnMenuLoad, ApplyUwuificationImmediate);
            SetupFunction(Setup.OnLoad, ApplyUwuificationImmediate);

            var harmonyInst = HarmonyInstance.Create("me.akatsuki.uwuify");
            harmonyInst.PatchAll();
        }

        public override void ModSettings()
        {
            base.ModSettings();

            Uwuifier = Settings.AddCheckBox(this, "uwuifier", "Enable uwuifier", true, ReapplyUwuification);
            Smileys = Settings.AddCheckBox(this, "Smileys", "smileys (˘ᵕ˘)", true, ReapplyUwuification);
            Stutter = Settings.AddCheckBox(this, "Stutter", "s- stuttering", true, ReapplyUwuification);
            Yu = Settings.AddCheckBox(this, "Yu", "Yu", true, ReapplyUwuification);

            Reidentifier = Settings.AddCheckBox(this, "reidentifier", "Enable reidentifier", true, ReapplyUwuification);
            Identity = Settings.AddDropDownList(this, "identity", "Idenitity", MSCUwUify.Identity.Identities);
        }

        private void ReapplyUwuification()
        {
            foreach (var item in Resources.FindObjectsOfTypeAll<UwUifierScript>()) item.Reapply();
        }

        private void ApplyUwuification()
        {
            _timer += Time.deltaTime;
            if (_timer <= 30) return;
            _timer = 0;
            foreach (var item in Resources.FindObjectsOfTypeAll<TextMesh>())
            {
                if (item.gameObject.GetComponent<UwUifierScript>() != null) continue;
                item.gameObject.AddComponent<UwUifierScript>();
            }

            foreach (var item in Resources.FindObjectsOfTypeAll<GUIText>())
            {
                if (item.gameObject.GetComponent<UwUifierScript>() != null) continue;
                item.gameObject.AddComponent<UwUifierScript>();
            }

            foreach (var item in Resources.FindObjectsOfTypeAll<Text>())
            {
                if (item.gameObject.GetComponent<UwUifierScript>() != null) continue;
                item.gameObject.AddComponent<UwUifierScript>();
            }
        }


        private static void ApplyUwuificationImmediate()
        {
            foreach (var item in Resources.FindObjectsOfTypeAll<TextMesh>())
            {
                if (item.gameObject.GetComponent<UwUifierScript>() != null) continue;
                item.gameObject.AddComponent<UwUifierScript>();
            }

            foreach (var item in Resources.FindObjectsOfTypeAll<GUIText>())
            {
                if (item.gameObject.GetComponent<UwUifierScript>() != null) continue;
                item.gameObject.AddComponent<UwUifierScript>();
            }

            foreach (var item in Resources.FindObjectsOfTypeAll<Text>())
            {
                if (item.gameObject.GetComponent<UwUifierScript>() != null) continue;
                item.gameObject.AddComponent<UwUifierScript>();
            }
        }

        private float _timer;
    }
}