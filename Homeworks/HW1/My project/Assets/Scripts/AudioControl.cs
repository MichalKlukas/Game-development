using UnityEngine;

public class AudioControl : MonoBehaviour
{
    private AudioSource audioSource;
    private bool isPlaying = true;

    void Start()
    {
        // Get the Audio Source component attached to the GameObject
        audioSource = GetComponent<AudioSource>();
        audioSource.Play(); // Start playing the audio on start
    }

    void Update()
    {
        // Toggle play/pause when pressing the 'M' key
        if (Input.GetKeyDown(KeyCode.M))
        {
            if (isPlaying)
            {
                audioSource.Pause();
            }
            else
            {
                audioSource.Play();
            }
            isPlaying = !isPlaying;
        }
    }
}
