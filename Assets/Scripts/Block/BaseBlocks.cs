using UnityEngine;

namespace Game
{
    public class BaseBlocks : MonoBehaviour
    {
#if UNITY_EDITOR
        [HideInInspector]
        public BlockData BlockData;
#endif
    }
}

