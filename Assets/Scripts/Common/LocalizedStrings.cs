using System;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;

// ReSharper disable InconsistentNaming

// ReSharper disable ClassNeverInstantiated.Local

namespace Common
{
    public static class LocalizedStrings
    {
        private const string path = "Slay the Spire/localization/zhs/";
        private static readonly Dictionary<string, CardStrings> cardStringsMap;
        private static readonly Dictionary<string, PowerStrings> powerStringsMap;

        static LocalizedStrings()
        {
            var config = Resources.Load<TextAsset>(path + "cards");
            cardStringsMap = JsonConvert.DeserializeObject<Dictionary<string, CardStrings>>(config.text);
        }

        public static CardStrings GetCardStrings(string cardId)
        {
            return cardStringsMap[cardId];
        }

        public static PowerStrings GetPowerStrings(string powerId)
        {
            return powerStringsMap.TryGetValue(powerId, out var strings) ? strings : PowerStrings.GetMockPowerString();
        }

        internal static string[] CreateMockStringArray(int size)
        {
            var retVal = new string[size];
            for (int i = 0; i < retVal.Length; i++)
                retVal[i] = "[MISSING_" + i + "]";
            return retVal;
        }
    }

    [Serializable]
    public class CardStrings
    {
        public string NAME;
        public string DESCRIPTION;
        public string UPGRADE_DESCRIPTION;
    }

    [Serializable]
    public class PowerStrings
    {
        public string NAME;

        public string[] DESCRIPTIONS;

        public static PowerStrings GetMockPowerString()
        {
            return new PowerStrings
            {
                NAME = "[MISSING_NAME]",
                DESCRIPTIONS = LocalizedStrings.CreateMockStringArray(6)
            };
        }
    }
}