using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using UnityEngine;

// ReSharper disable InconsistentNaming

// ReSharper disable ClassNeverInstantiated.Local

namespace Core.Localization
{
    public class LocalizedStrings
    {
        private const string path = "Slay the Spire/localization/zhs/";
        private readonly Dictionary<string, CardStrings> cardStringsMap;
        private readonly Dictionary<string, PowerStrings> powerStringsMap;

        public LocalizedStrings()
        {
            cardStringsMap = JsonConvert.DeserializeObject<Dictionary<string, CardStrings>>(Resources.Load<TextAsset>(path + "cards").text);
            powerStringsMap = JsonConvert.DeserializeObject<Dictionary<string, PowerStrings>>(Resources.Load<TextAsset>(path + "powers").text);
        }

        public CardStrings GetCardStrings(string cardId)
        {
            return cardStringsMap[cardId];
        }

        public PowerStrings GetPowerStrings(string powerId)
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