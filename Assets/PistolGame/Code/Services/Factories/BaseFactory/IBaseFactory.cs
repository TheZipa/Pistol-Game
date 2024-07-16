using Cysharp.Threading.Tasks;
using PistolGame.Code.Services.EntityContainer;
using UnityEngine;

namespace PistolGame.Code.Services.Factories.BaseFactory
{
    public interface IBaseFactory
    {
        UniTask<T> InstantiateAsRegistered<T>(Vector3 at, Quaternion rotation, Transform parent = null) where T : Object, IFactoryEntity;
        UniTask<T> InstantiateAsRegistered<T>(Transform parent = null) where T : Object, IFactoryEntity;
        UniTask<T> Instantiate<T>(Transform parent = null) where T : Object;
        UniTask<T> Instantiate<T>(string prefabName, Transform parent = null) where T : Object;
    }
}