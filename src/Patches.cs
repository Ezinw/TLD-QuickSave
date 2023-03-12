using HarmonyLib;
using Il2Cpp;
using UnityEngine;

namespace QuickSave
{
    [HarmonyPatch(typeof(GameManager), "Update")]
    internal class QuickSave
    {
        private static readonly KeyCode saveKey = KeyCode.F5;

        static void Postfix(GameManager __instance)
        {
            if (Input.GetKeyDown(saveKey))
            {
                GameManager.SaveGameAndDisplayHUDMessage();
            }
        }
    }

    [HarmonyPatch(typeof(GameAudioManager), "PlayGUIError")]
    class GameAudioManager_PlayGUIError_Patch
    {
        static bool Prefix(GameAudioManager __instance)
        {
            if (Input.GetKeyDown(KeyCode.F5))
            {
                AudioSource audioSource = __instance.gameObject.GetComponent<AudioSource>();

                if (audioSource.clip != null && audioSource.clip.name == "PlayGUIError")
                {
                    audioSource.Stop();

                    return false;
                }
            }

            return true;
        }
    }
}
