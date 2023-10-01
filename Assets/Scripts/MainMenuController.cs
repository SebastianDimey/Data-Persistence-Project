using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;


public class MainMenuController : MonoBehaviour
{
    public NamePicker NamePicker;
    public TextMeshProUGUI BestScore;

    public void NewName(string name)
    {
        // add code here to handle when a color is selected
        //  DataPersistence.Instance.namePlayer = name;
    }
    // Start is called before the first frame update
    void Start()
    {
        loadPlayer();
         // Asigna un método como listener para el evento onEndEdit del InputField
        //NamePicker.inputField.onEndEdit.AddListener(HandleNameEndEdit);
    }

    // Update is called once per frame
    void Update()
    {

    }

     // Método que maneja el evento onEndEdit del InputField
    private void HandleNameEndEdit(string name)
    {
        Debug.Log(name);
        // Llama a NewName con el nombre ingresado
        NewName(name);
    }

    public void StartGame()
    {
            // Obtén el nombre ingresado por el jugador
        string playerName = NamePicker.inputField.text;
        Debug.Log(playerName);
        // Asigna el nombre del jugador en DataPersistence
        DataPersistence.Instance.namePlayer = playerName;
        // Guarda el puntaje inicial en DataPersistence
        DataPersistence.Instance.score = 0;

        DataPersistence.Instance.SaveScore();
        SceneManager.LoadScene(1);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    private void loadPlayer()
    {
        DataPersistence.Instance.LoadScore();
        int score = DataPersistence.Instance.bestScore;
        string playerName = DataPersistence.Instance.namePlayerBestScore;
        NamePicker.inputField.text=playerName;
        Debug.Log($"score: {score}, name: {playerName}");
        // Actualiza el texto de BestScore en la interfaz
        BestScore.text = $"Best Score: {score} Name: {playerName}";
    }
}
