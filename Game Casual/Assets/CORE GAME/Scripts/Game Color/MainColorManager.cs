using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MainColorManager : MonoBehaviour
{
    //[SerializeField] private Button backMainMenuGame;
    [SerializeField] private TMP_Text _scoreText;
    [SerializeField] private TMP_Text _newBestText;
    [SerializeField] private TMP_Text _highScoreText;

    private void Awake()
    {
        _highScoreText.text = GameColorManager.Instance.HighScore.ToString();

        if(!GameColorManager.Instance.IsInitialized)
        {
            _scoreText.gameObject.SetActive(false);
            _newBestText.gameObject.SetActive(false);
        }
        else
        {
            StartCoroutine(ShowScore());
        }
    }

    [SerializeField] private float _animationTime;
    [SerializeField] private AnimationCurve _speedCurve;

    private IEnumerator ShowScore()
    {
        int tempScore = 0;
        _scoreText.text = tempScore.ToString();

        int currentScore = GameColorManager.Instance.CurrentScore;
        int highScore = GameColorManager.Instance.HighScore;

        if(highScore < currentScore)
        {
            _newBestText.gameObject.SetActive(true);
            GameColorManager.Instance.HighScore = currentScore;

        }
        else
        {
            _newBestText.gameObject.SetActive(false);
        }

        _highScoreText.text = GameColorManager.Instance.HighScore.ToString();

        float speed = 1 / _animationTime;
        float timeElapsed = 0f;
        while(timeElapsed < 1f)
        {
            timeElapsed += speed * Time.deltaTime;

            tempScore = (int)(_speedCurve.Evaluate(timeElapsed) * currentScore);
            _scoreText.text = tempScore.ToString();

            yield return null;
        }

        tempScore = currentScore;
        _scoreText.text = tempScore.ToString();

    }

    [SerializeField] private AudioClip _clickSound;

    public void ClickedPlay()
    {
        SoundManager.Instance.PlaySound(_clickSound);
        GameColorManager.Instance.GoToGameplay();
    }
    /*private void ClickBack()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenuGame");
    }*/
}
