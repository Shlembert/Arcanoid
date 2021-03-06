using UnityEngine;
using UnityEngine.Events;

namespace Game
{
    public class LevelGenerator : MonoBehaviour
    {
        private readonly LevelIndex _levelIndex = new LevelIndex();
        private readonly BlocksGenerator _blocksGenerator = new BlocksGenerator();
        [SerializeField] private Transform _parentBlocks;
        [SerializeField] private ClearLevel _clearLevel;
        [SerializeField] private GameState _gameState;
        [SerializeField] private UnityEvent OnGenegated;
        [Space]
        [SerializeField] private SpriteRenderer _background;

        private void Start()
        {
            _gameState.SetState(State.StopGame);
            Init();
        }

        private void Init()
        {
            _clearLevel.Clear();

            GameLevel gameLevel = Resources.Load<GameLevel>($"Levels/Level {_levelIndex.GetIndex()}");

            if(gameLevel != null)
            {
                _blocksGenerator.Generate(gameLevel, _parentBlocks);
                _background.sprite = gameLevel.Background;
            }
            
            LoadingScreen.Screen.Enable(false);
            OnGenegated.Invoke();
            _gameState.SetState(State.Gameplay); 
        }

        public void Generate()
        {
            LoadingScreen.Screen.Enable(true);
            Init();
        }

        public void GenerateNext()
        {
            LevelsData levelsData = new LevelsData();
            int tempIndex = _levelIndex.GetIndex();

            if(tempIndex < levelsData.GetLevelProgress().Levels.Count - 1)
            {
                _levelIndex.SetIndex(tempIndex + 1);
                Generate();
            }
            else
            {
                Loader loader = new Loader();
                _gameState.SetState(State.Other);
                loader.LoadingMyScene(true);
            }
        }
    }
}

