using UnityEngine;

public class PlayerSound : MonoBehaviour
{
    public AudioClip punchSound;
    private AudioSource audioSource;
    private float lastPunchTime = 0f;
    public float punchCooldown = 1.5f;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && Time.time - lastPunchTime > punchCooldown)
        {
            PlayPunchSound();
            lastPunchTime = Time.time;
        }
    }

    void PlayPunchSound()
    {
        audioSource.PlayOneShot(punchSound);
    }
}
