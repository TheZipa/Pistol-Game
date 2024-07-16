using System.Collections;
using UnityEngine;

namespace PistolGame.Code.Services.CoroutineRunner
{
    public interface ICoroutineRunner
    {
        Coroutine StartCoroutine(IEnumerator routine);
    }
}