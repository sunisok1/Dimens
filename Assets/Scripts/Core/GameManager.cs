using UnityEngine;

namespace Core
{
    public class GameManager : MonoBehaviour
    {
        private Map gameMap;
        private IMapGenerator mapGenerator;

        private void Start()
        {
            InitializeGame();
            mapGenerator = GetComponent<IMapGenerator>();
        }

        private void InitializeGame()
        {
            InitializeMap();
            InitializeTurnSystem();
        }

        private void InitializeMap()
        {
            gameMap = mapGenerator.GenerateMap();
            Debug.Log("Map Initialized");
        }

        private void InitializeTurnSystem()
        {
            // 这里设置回合系统的初始状态
            Debug.Log("Round System Initialized");
        }
    }
}