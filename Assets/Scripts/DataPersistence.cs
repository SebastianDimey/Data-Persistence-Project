using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;


public class DataPersistence : MonoBehaviour
{
    public static DataPersistence Instance;

    public string namePlayer;
    public int score;

    public string namePlayerBestScore;
    public int bestScore;

    // Start is called before the first frame update
    private void Awake()
    {
            // start of new code
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        // end of new code

        Instance = this;
        DontDestroyOnLoad(gameObject);

    }

[System.Serializable]
class SaveData
{
    public string namePlayer;
    public int score;

    public string namePlayerBestScore;
    public int bestScore;
}

public void SaveScore()
{
    SaveData data= new SaveData();
    data.namePlayer=namePlayer;
    data.score=score;

    data.namePlayerBestScore=namePlayerBestScore;
    data.bestScore=bestScore;
    Debug.Log("Save:" + namePlayer);
    string json = JsonUtility.ToJson(data);
    File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);

}

public void LoadScore()
{
    string path = Application.persistentDataPath + "/savefile.json";
            if (File.Exists(path))
            {
                string json = File.ReadAllText(path);
                SaveData data = JsonUtility.FromJson<SaveData>(json);

                // Asigna los valores de data a las variables de DataPersistence
                namePlayer = data.namePlayer;
                score = data.score;

                namePlayerBestScore=data.namePlayerBestScore;
                bestScore=data.bestScore;

            }
}
}
