using System.Collections.Generic;

namespace Game
{
    [System.Serializable]
    public class LevelProgress
    {
        public List<Progress> Levels = new List<Progress>();
    }

    [System.Serializable]
    public class Progress 
    {
        public bool IsOpened;
        public int MaxScore;
        public int StarsCount;
    }
}
