using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScoreManager : MonoBehaviour {
    private static HighScoreManager instance;
    private const int HighScoreSize = 8;

    public static HighScoreManager _instance {
        get {
            if (instance == null) {
                instance = new GameObject("HighScoreManager").AddComponent<HighScoreManager>();
            }
            return instance;
        }
    }

    void Awake() {
        if (instance == null) instance = this; 
        else if (instance != this) Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
    }

    public void SaveHighScore(string name, int score) {
        Debug.Log("Saving scores...");
        List<Scores> HighScores = new List<Scores>();

        for (int i = 1; i <= HighScoreSize && PlayerPrefs.HasKey("HighScore" + i + "score"); i++) {
            Scores temp = new Scores();
            temp.name = PlayerPrefs.GetString("HighScore" + i + "name");
            temp.score = PlayerPrefs.GetInt("HighScore" + i + "score");
            HighScores.Add(temp);
        }

        if (HighScores.Count == 0) { // Adding first score
            Scores _temp = new Scores();
            _temp.name = name;
            _temp.score = score;
            HighScores.Add(_temp);
        } else {
            for (int i = 1; i <= HighScores.Count && i <= HighScoreSize; i++) {
                if (score > HighScores[i - 1].score) { // Insert score in an descending ordered HighScores
                    Scores _temp = new Scores();
                    _temp.name = name;
                    _temp.score = score;
                    HighScores.Insert(i - 1, _temp);
                    Debug.Log("Scored successfully added!");
                    break;
                }
                if (i == HighScores.Count && i < HighScoreSize) { // Add score if it is the lowest score and HighScores is not full
                    Scores _temp = new Scores();
                    _temp.name = name;
                    _temp.score = score;
                    HighScores.Add(_temp);
                    Debug.Log("Scored successfully added!");
                    break;
                }
            }
        }
        
        // Saving it into PlayerPrefs for permanent storage
        for (int i = 1;  i <= HighScoreSize && i <= HighScores.Count; i++) {
            PlayerPrefs.SetString("HighScore" + i + "name", HighScores[i - 1].name);
            PlayerPrefs.SetInt("HighScore" + i + "score", HighScores[i - 1].score);
        }
        return;
    }

    // Clear all high scores
    public void ClearHighScore() {
        List<Scores> HighScores = GetHighScore();

        for (int i = 1; i <= HighScores.Count; i++) {
            PlayerPrefs.DeleteKey("HighScore" + i + "name");
            PlayerPrefs.DeleteKey("HighScore" + i + "score");
        }
    }

    public List<Scores> GetHighScore() {
        List<Scores> HighScores = new List<Scores>();

        for (int i = 1;  i <= HighScoreSize && PlayerPrefs.HasKey("HighScore" + i + "score"); i++) {
            Scores temp = new Scores();
            temp.name = PlayerPrefs.GetString("HighScore" + i + "name");
            temp.score = PlayerPrefs.GetInt("HighScore" + i + "score");
            HighScores.Add(temp);
        }

        return HighScores;
    }
}

public class Scores {
    public string name;
    public int score;
}