using System;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using Object = UnityEngine.Object;

namespace UI
{
    public static class UIManager
    {
        private static readonly Dictionary<Type, BaseUI> uiDictionary = new();

        public static void Open<T>(params object[] objs) where T : BaseUI
        {
            Type type = typeof(T);
            if (uiDictionary.ContainsKey(type))
            {
                Debug.LogWarning($"UIManager: {type.Name} 已经打开，无需重复打开。");
                return;
            }

            var attribute = type.GetCustomAttribute<UIPrefabAttribute>();
            if (attribute == null)
            {
                Debug.LogError($"UIManager: {type.Name} UIPrefab属性未找到。");
                return;
            }

            var prefab = Resources.Load<T>(attribute.Path);
            if (prefab == null)
            {
                Debug.LogError($"UIManager: 无法加载 {type.Name} 的预制体。请确保路径正确且资源存在。");
                return;
            }

            T instance = Object.Instantiate(prefab);
            instance.OnCreated(objs);
            uiDictionary.Add(type, instance);
            Debug.Log($"UIManager: 成功打开 {type.Name}。");
        }

        public static void Close<T>() where T : BaseUI
        {
            Type type = typeof(T);
            if (!uiDictionary.TryGetValue(type, out BaseUI ui))
            {
                Debug.LogWarning($"UIManager: 尝试关闭 {type.Name}，但找不到它。可能它未曾被打开或已经关闭。");
                return;
            }

            Object.Destroy(ui.gameObject);
            uiDictionary.Remove(type);
            Debug.Log($"UIManager: 成功关闭 {type.Name}。");
        }
    }


    [AttributeUsage(AttributeTargets.Class, Inherited = false)]
    public class UIPrefabAttribute : Attribute
    {
        public string Path { get; }

        public UIPrefabAttribute(string path)
        {
            Path = path;
        }
    }

    public abstract class BaseUI : MonoBehaviour
    {
        public virtual void OnCreated(params object[] objs)
        {
            Debug.Log($"{GetType().Name} 已创建。附带参数数量: {objs?.Length ?? 0}");
        }
    }
}