using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    private Animator Animator;

    private void Start()
    {
        Animator = GetComponent<Animator>();
    }

    public void Play()
    {
        SceneManager.LoadScene("Game");
    }

    public void Settings()
    {
        Animator.SetBool("Settings", true);
    }

    public void Credits()
    {
        Animator.SetBool("Credits", true);
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void SettingsBack()
    {
        Animator.SetBool("Settings", false);
    }

    public void CreditsBack()
    {
        Animator.SetBool("Credits", false);
    }
}
