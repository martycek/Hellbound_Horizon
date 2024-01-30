using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;


public class GameOverScreenController : MonoBehaviour
{
    public Canvas GameOverScreenCanvas;
    public Image deathImage;
    
    public AudioSource audioSource;
    public AudioClip deathMusic;
    public Player player;

    private bool gameOverStarted = false;

    void Update()
    {
        // Check if the player's health is zero and the game over is not yet started
        if (player != null && player.currentHealth <= 0 && !gameOverStarted)
        {
            // Start the game over sequence
            StartGameOver();
        }
    }

    void StartGameOver()
    {
        Debug.Log("StartGameOver!!!!!!!!!!!!");
        //kontrola spamstartu hry
        gameOverStarted = true;

        // ukaž KURZOR
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None; // Unlockos

        // aktivace kanvasu po smrti
        GameOverScreenCanvas.gameObject.SetActive(true);

        // ZAHRAJ the death music
        audioSource.clip = deathMusic;
        audioSource.Play();

        // UKAŽ BUTTONS ZA...
        Invoke(nameof(LoadMenu), 5f);
        Debug.Log("AAAAAAAAAAAAAAAAAAAAAAAAAAA");
    }



    public void LoadMenu()
    {
        Debug.Log("MENUUUUU");
        // nacte menu
        UnityEngine.SceneManagement.SceneManager.LoadScene("Menuscene");
    }
    
}   
