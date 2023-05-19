using UnityEngine;


    public class GameColorManager : MonoBehaviour
    {
        public static GameColorManager Instance;

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
                Init();
                return;
            }
            else
            {
                Destroy(gameObject);
            }
        }

        private string highScoreKey = "HighScore";

        public int HighScore
        {
            get
            {
                return PlayerPrefs.GetInt(highScoreKey, 0);
            }
            set
            {
                PlayerPrefs.SetInt(highScoreKey, value);
            }
        }

        public int CurrentScore { get; set; }

        public bool IsInitialized { get; set; }

        private void Init()
        {
            CurrentScore = 0;
            IsInitialized = false;
        }

        public const string MainMenu = "MainColor";
        public const string Gameplay = "GamePlayColor";

        public void GoToMainMenu()
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(MainMenu);
        }

        public void GoToGameplay()
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(Gameplay);
        }
    }
