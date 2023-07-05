using MyPack.IdentifiedSO.ScriptableObjects.Base;
using UnityEngine;

namespace MyPack.IdentifiedSO.ScriptableObjects
{
    [CreateAssetMenu(menuName = "ScriptableObjects/IdentifiedSO/ExampleSO", order = 1)]
    public class ExampleScriptableObject : IdentifiedScriptableObject
    {
        [SerializeField] private string _testString;
    }
}