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

        public static string GetCardName(string cardId)
        {
            return cardStringsMap[cardId].NAME;
        }

        public static string GetCardDescription(string cardId)
        {
            return cardStringsMap[cardId].DESCRIPTION;
        }

        private class CardStrings
        {
            public string NAME;
            public string DESCRIPTION;
        }
    }
}