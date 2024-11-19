using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Geral : MonoBehaviour
{
    public int score, highScore;
    public GameObject ferramenta;
    public GameObject gameOver;
    [SerializeField] TextMeshProUGUI scoreText, highScoreText;
    [SerializeField] GameObject canvas;
    [SerializeField] AudioClip scorePoint;
    AudioSource audioSource;
    
    void Start()
    {
        audioSource = GameObject.Find("Audio").GetComponent<AudioSource>();
        highScore = PlayerPrefs.GetInt("highScore", 0);
    }

    void Update()
    {
        SetHighScore();
    }

    private void SetHighScore()
    {
        if (score > highScore) highScore = score;
        highScoreText.text = highScore.ToString();
    }
    public void ScoreOnePoint()
    {
        score++;
        scoreText.text = "Placar Player: " + score.ToString();
        audioSource.PlayOneShot(scorePoint);
    }

    public void GerarFerramenta()
    {
        GameObject ferramentaInstancia = Instantiate(ferramenta, new Vector3(-55, Random.Range(32,468), 0), Quaternion.identity);
        ferramentaInstancia.transform.SetParent(canvas.transform);
    }

    public void GameOver()
    {
        gameOver.SetActive(true);
        Time.timeScale = 0;
        PlayerPrefs.SetInt("highScore", highScore);
    }

    public void RestartGame()
    {
        Debug.Log("fabso");
        SceneManager.LoadScene("CenaPrincipal");
    }
}
