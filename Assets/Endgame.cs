using TMPro;
using UnityEngine;

public class Endgame : MonoBehaviour
{
    public static Endgame Instance;
    [SerializeField] private TMP_Text Title;
    [SerializeField] private TMP_Text Desc;
    [SerializeField] private TMP_Text CurrentWave;
    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
        
        gameObject.SetActive(false);
    }

    public void Win()
    {
        gameObject.SetActive(true);    
        Title.SetText("Win");
        Desc.SetText("Congrats !");
        Time.timeScale = 0;
    }

    public void GameOver()
    {
        if (GameState.Instance.CurrentHealth <= 0)
        {
            gameObject.SetActive(true);
            Title.SetText("Lose");
            Desc.SetText("GameOver");
            CurrentWave.SetText(GameState.Instance.CurrentWave.ToString());
            Time.timeScale = 0;
        }
    }
}
