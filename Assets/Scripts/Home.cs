using UnityEngine;
using UnityEngine.SceneManagement;

public enum Difficulty
{
    Easy,
    Medium,
    Hard
}

public class Home : MonoBehaviour
{
    private int difficulty;

    public void Easy()
    {
        OnDifficultySelection(Difficulty.Easy.ToString());
    }

    public void Medium()
    {
        OnDifficultySelection(Difficulty.Medium.ToString());
    }

    public void Hard()
    {
        OnDifficultySelection(Difficulty.Hard.ToString());
    }

    private void OnDifficultySelection(string difficultyLevel)
    {
        PlayerPrefs.SetString("difficulty", difficultyLevel);
        SceneManager.LoadScene("Play");
    }
}
