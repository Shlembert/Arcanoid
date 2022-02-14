using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class SaveLevel
    {
        public void  Save(GameLevel gameLevel)
        {
            gameLevel.Blocks = new List<BlockObject>();
            BaseBlocks[] baseBlocks = GameObject.FindObjectsOfType<BaseBlocks>();

            foreach (var item in baseBlocks)
            {
                BlockObject blockObject = new BlockObject
                {
                    Position = item.gameObject.transform.position,
                    Block = item.BlockData
                };
               
                gameLevel.Blocks.Add(blockObject);
            }
        }
    }
}
