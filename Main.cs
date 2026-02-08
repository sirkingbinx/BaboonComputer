using BaboonComputer.Components;
using BaboonComputer.Patches;
using BepInEx;
using UnityEngine;

namespace BaboonComputer;

[BepInPlugin(Constants.Guid, Constants.Name, Constants.Version)]
public class Main : BaseUnityPlugin
{
    public static Main? Instance;

    private void Start()
    {
        Instance ??= this;
        HarmonyPatches.Patch();
        
        GorillaTagger.OnPlayerSpawned(OnPlayerSpawned);
    }

    private static void OnPlayerSpawned()
    {
        new GameObject("BaboonComputer").AddComponent<BaboonComputerManager>();
    }
}
