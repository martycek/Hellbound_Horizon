using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverScreenController : MonoBehaviour
{
    public Canvas GameOverScreenCanvas;
    public Image deathImage;
    public Button reloadButton;
    public Button menuButton;
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
        // Control for preventing multiple game over starts
        gameOverStarted = true;

        // Show the cursor
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None; // Unlock the cursor

        // Activate the canvas after player death
        GameOverScreenCanvas.gameObject.SetActive(true);

        // Play the death music
        audioSource.clip = deathMusic;
        audioSource.Play();

        // Show the buttons after a delay
        Invoke(nameof(ShowButtons), 4f);
    }

    void ShowButtons()
    {
        // Show the buttons
        reloadButton.interactable = true;
        menuButton.interactable = true;
    }

    // Button click methods with original comments

    // Reload the current level
    public void ReloadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    // Load the menu scene
    public void LoadMenu()
    {
        SceneManager.LoadScene("MenuScene");
    }
}
