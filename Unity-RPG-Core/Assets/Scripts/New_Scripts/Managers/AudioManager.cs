using UnityEngine;

public class AudioManager : SingletonBehaviour<AudioManager>
{
    private AudioSource source;
    protected override void Awake()
    {
        base.Awake();
        source = gameObject.AddComponent<AudioSource>();
        source.loop = true;
    }
    public void PlayMusic(AudioClip clip)
    {
        source.clip = clip;
        source.Play();
    }
}