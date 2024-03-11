using System;
using System.Reflection;
using UnityEngine;

[AttributeUsage(AttributeTargets.Class, Inherited = false)]
public class ObjectAttribute : Attribute
{
    public string Path { get; }

    public ObjectAttribute(string path)
    {
        Path = path;
    }
}

public abstract class BaseObject : MonoBehaviour
{
    public virtual void OnCreate(params object[] objs)
    {
        Debug.Log($"{GetType().Name} 已创建。附带参数数量: {objs?.Length ?? 0}");
    }
}

public static class ObjectManager
{
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
        instance.OnCreate(objs);
        return instance;
    }
}