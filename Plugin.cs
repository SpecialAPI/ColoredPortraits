using BepInEx;
using DiskCardGame;
using HarmonyLib;
using InscryptionAPI.Card;
using System;
using UnityEngine;

namespace ColoredPortraits
{
    [BepInPlugin(GUID, NAME, VERSION)]
    public class Plugin : BaseUnityPlugin
    {
        public const string GUID = "spapi.inscryption.coloredportraits";
        public const string NAME = "Colored Portraits";
        public const string VERSION = "1.0.0";
        public static CardAppearanceBehaviour.Appearance coloredPortrait;

        public void Awake()
        {
            coloredPortrait = CardAppearanceBehaviourManager.Add(GUID, "ColoredPortrait", typeof(ColoredPortrait)).Id;
            new Harmony(GUID).PatchAll();
        }
    }

    [HarmonyPatch(typeof(CardDisplayer3D), nameof(CardDisplayer3D.DisplayInfo))]
    public class MakePortraitColored : MonoBehaviour
    {
        [HarmonyPrefix]
        public static void Prefix(CardDisplayer3D __instance, CardRenderInfo renderInfo)
        {
            var cacher = __instance.gameObject.GetComponent<MakePortraitColored>();
            if (cacher != null && cacher.matcache != null)
            {
                __instance.portraitRenderer.material = cacher.matcache;
            }
            if ((renderInfo?.baseInfo?.appearanceBehaviour?.Contains(Plugin.coloredPortrait)).GetValueOrDefault())
            {
                (cacher ?? __instance.gameObject.AddComponent<MakePortraitColored>()).matcache = __instance.portraitRenderer.material;
                __instance.portraitRenderer.material = __instance.decalRenderers[0].material;
            }
        }

        public Material matcache;
    }

    public class ColoredPortrait : CardAppearanceBehaviour
    {
        public override void ApplyAppearance()
        {
            Card.RenderInfo.portraitColor = Color.white;
        }
    }
}
