using UnityEngine;



public class TemporaryAudio : MonoBehaviour
{
    private AudioSource audioSource;

    private void OnEnable()
    {
        audioSource = GetComponent<AudioSource>();
    }



    private void Update()
    {
        if (!audioSource.isPlaying) Destroy(gameObject);
    }
}
