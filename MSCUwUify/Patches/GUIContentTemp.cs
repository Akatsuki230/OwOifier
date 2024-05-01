using Harmony;
using JetBrains.Annotations;
using UnityEngine;

namespace MSCUwUify.Patches
{
    [HarmonyPatch(typeof(GUIContent))]
    [HarmonyPatch("Temp")]
    [HarmonyPatch(new[] { typeof(string) })]
    public class GUIContentTemp
    {
        [HarmonyPrefix]
        [UsedImplicitly]
        static void Prefix(ref string t)
        {
            t = Identity.ConvertIdentityInSentence(t);
            t = Uwuifier.Uwuify(t, UwUifierScript.Flags);
        }
    }
}