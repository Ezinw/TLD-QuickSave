using HarmonyLib;
using Il2Cpp;
using MelonLoader;
using UnityEngine;

namespace QuickSave;

//Implementation
internal sealed class Implementation : MelonMod
{
    public override void OnInitializeMelon()
    {

    }
}

//Patches
[HarmonyPatch(typeof(GameManager), "Update")]
internal class QuickSave
{
    private static KeyCode saveKey = KeyCode.F5;

    static void Postfix(GameManager __instance)
    {
        if (Input.GetKeyDown(saveKey))
        {
            GameManager.SaveGameAndDisplayHUDMessage();
        }
    }
}