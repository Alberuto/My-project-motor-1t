using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour {

    public static AudioManager Instance;
    public AudioSource audioSource;

    private void Awake() {

        if (Instance == null) {

            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else {

            Destroy(gameObject);
        }
    }
    public void PlaySound(AudioClip clip) {

        if (clip != null) {

            audioSource.PlayOneShot(clip);
        }
    }
}