using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;

// ReSharper disable ClassNeverInstantiated.Local

namespace Common
{
    public static class LocalizationManager
    {
        private const string path = "Slay the Spire/localization/zhs/";
        private static readonly Dictionary<string, CardStrings> cardStringsMap;

        static LocalizationManager()
        {
            var config = Resources.Load<TextAsset>(path + "cards");
            cardStringsMap = JsonConvert.DeserializeObject<Dictionary<string, CardStrings>>(config.text);
        }

        public static CardStrings GetCardStrings(string cardId)
        {
            return cardStringsMap[cardId];
        }
    }

    public class CardStrings
    {
        public string NAME;
        public string DESCRIPTION;
        public string UPGRADE_DESCRIPTION;
    }
}