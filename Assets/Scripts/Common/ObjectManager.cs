using System;
using System.Reflection;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Common
{
    [AttributeUsage(AttributeTargets.Class, Inherited = false)]
    public class ObjectAttribute : Attribute
    {
        internal string Path { get; }

        public ObjectAttribute(string path)
        {
            Path = path;
        }
    }

    public abstract class BaseObject : MonoBehaviour
    {
        public virtual void OnCreated(params object[] objs)
        {
            Debug.Log($"{GetType().Name} 已创建。附带参数数量: {objs?.Length ?? 0}");
        }

        public void DestroySelf()
        {
            Destroy(gameObject);
        }
    }

    public static class ObjectManager
    {
        public static T CreateDerived<T>(string path, Transform parent, params object[] objs) where T : BaseObject
        {
            var prefab = Resources.Load<T>(path);
            if (prefab == null)
            {
                Debug.LogError($"ObjectManager: 无法加载 {typeof(T).Name} 的预制体。请确保路径正确且资源存在。");
                return null;
            }

            T instance = UnityEngine.Object.Instantiate(prefab, parent);
            instance.OnCreated(objs);
            return instance;
        }

        public static T Create<T>(Transform parent, params object[] objs) where T : BaseObject
        {
            Type type = typeof(T);

            var attribute = type.GetCustomAttribute<ObjectAttribute>();
            if (attribute == null)
            {
                Debug.LogError($"ObjectManager: {type.Name} Prefab属性未找到。");
                return null;
            }

            var prefab = Resources.Load<T>(attribute.Path);
            if (prefab == null)
            {
                Debug.LogError($"ObjectManager: 无法加载 {type.Name} 的预制体。请确保路径正确且资源存在。");
                return null;
            }

            T instance = UnityEngine.Object.Instantiate(prefab, parent);
            instance.OnCreated(objs);
            return instance;
        }
    }
}