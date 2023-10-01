using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
public class MainManager : MonoBehaviour
{
    public Brick BrickPrefab;
    public int LineCount = 6;
    public Rigidbody Ball;

    public Text ScoreText;
    public Text BestScore;
    public GameObject GameOverText;
    public string playerNameO;
    
    private bool m_Started = false;
    private int m_Points;
    private int bestScore;
    
    private bool m_GameOver = false;

    
    // Start is called before the first frame update
    void Start()
    {
        loadPlayer();
        const float step = 0.6f;
        int perLine = Mathf.FloorToInt(4.0f / step);
        
        int[] pointCountArray = new [] {1,1,2,2,5,5};
        for (int i = 0; i < LineCount; ++i)
        {
            for (int x = 0; x < perLine; ++x)
            {
                Vector3 position = new Vector3(-1.5f + step * x, 2.5f + i * 0.3f, 0);
                var brick = Instantiate(BrickPrefab, position, Quaternion.identity);
                brick.PointValue = pointCountArray[i];
                brick.onDestroyed.AddListener(AddPoint);
            }
        }
    }

    private void Update()
    {
        if (!m_Started)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                m_Started = true;
                float randomDirection = Random.Range(-1.0f, 1.0f);
                Vector3 forceDir = new Vector3(randomDirection, 1, 0);
                forceDir.Normalize();

                Ball.transform.SetParent(null);
                Ball.AddForce(forceDir * 2.0f, ForceMode.VelocityChange);
            }
        }
        else if (m_GameOver)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
    }

    void AddPoint(int point)
    {
        m_Points += point;
        ScoreText.text = $"Score : {m_Points}";
        SetScore(); 
    }

    void SetScore()
    {
            // Verifica si el puntaje actual es mayor que el bestScore
        if (m_Points > bestScore && DataPersistence.Instance != null )
        {
            bestScore = m_Points; // Actualiza el bestScore con el nuevo puntaje
            string playerName = DataPersistence.Instance.namePlayer;
            Debug.Log("Estuve aqui:"+playerName);

            // Guarda los nuevos datos de puntaje más alto y nombre del jugador
            DataPersistence.Instance.namePlayerBestScore = playerName;
            DataPersistence.Instance.bestScore = bestScore;
            DataPersistence.Instance.SaveScore();

            // Actualiza el texto de BestScore en la interfaz
            BestScore.text = $"Best Score: {bestScore} Name: {playerName}";
        }
        // Verifica si DataPersistence.Instance es nulo (puede ser nulo en la primera carga)
        
    }

    public void GameOver()
    {
        m_GameOver = true;
        GameOverText.SetActive(true);

    }

    private void loadPlayer()
    {
        DataPersistence.Instance.LoadScore();
        if (DataPersistence.Instance.namePlayer==DataPersistence.Instance.namePlayerBestScore)
        {
            bestScore=DataPersistence.Instance.bestScore;
            string playerName = DataPersistence.Instance.namePlayerBestScore;
            // Actualiza el texto de BestScore en la interfaz
            BestScore.text = $"Best Score: {bestScore} Name: {playerName}";
        }
        else{
            bestScore=DataPersistence.Instance.bestScore;
            string playerName = DataPersistence.Instance.namePlayerBestScore;
            // Actualiza el texto de BestScore en la interfaz
            BestScore.text = $"Best Score: {bestScore} Name: {playerName}";
        }

    }
}
