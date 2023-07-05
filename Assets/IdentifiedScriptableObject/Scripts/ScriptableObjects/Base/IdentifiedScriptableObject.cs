using System;
using UnityEngine;
using ModestTree;

namespace MyPack.IdentifiedSO.ScriptableObjects.Base
{
    public class ScriptableObjectIdAttribute : PropertyAttribute
    {
    }

    public class IdentifiedScriptableObject : ScriptableObject, ISingle
    {
        public Guid Id;

        [ScriptableObjectId]
        [SerializeField] private string _id = string.Empty;

        private void Awake()
        {
            Id = Guid.TryParse(_id, out var id) ? id : Guid.Empty;
        }

        public void OnValidate()
        {
            if (Id == Guid.Empty)
            {
                if (_id.IsEmpty())
                {
                    ResetId();
                }
                else
                {
                    Id = Guid.Parse(_id);
                }
            }
        }

        [ContextMenu("ResetId")]
        private void ResetId()
        {
            Id = Guid.NewGuid();
            _id = Id.ToString();
        }

        public void OnDuplicateDetected()
        {
            ResetId();
        }
    }
}