using UnityEngine;

namespace Game
{
    [CreateAssetMenu(fileName = "BlockData", menuName = "GameData/Create/BlockData")]
    public class BlockData : ScriptableObject
    {
        public GameObject Prefab;
    }
}


