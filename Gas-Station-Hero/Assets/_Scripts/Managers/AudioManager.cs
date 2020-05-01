using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    public List<AudioClip> clips;

    private AudioSource[] sources;
    
    private void Start() 
    {
        instance = this;
        clips = new List<AudioClip>();
        int index = 0;
        
        // DirectoryInfo dir = new DirectoryInfo(Application.streamingAssetsPath + "/Audio/Resources");
        DirectoryInfo dir = new DirectoryInfo(Application.dataPath + "/Audio/Resources");
        FileInfo[] info = dir.GetFiles("*");
        foreach(FileInfo f in info) 
        {
            if (f.Name.EndsWith("wav") || f.Name.EndsWith("mp3")) 
            {
                clips.Add(Resources.Load<AudioClip>(Path.GetFileNameWithoutExtension(f.Name)));
                index++;
            }
        }

        sources = new AudioSource[clips.Count];
        for (int i = 0; i < clips.Count; i++) 
        {
            AudioSource audioSource = gameObject.AddComponent<AudioSource>();
            audioSource.clip = clips[i];
            sources[i] = audioSource;
        }
    }

    private int GetAudioClipIndex(string name) 
    {
        for (int i = 0; i < clips.Count; i++) 
        {
            if (clips[i].name.Equals(name)) 
            {
                return i;
            }
        }
        return -1;
    }

    public void PlaySound(string name, GameObject playFrom = null, float volume = 1f, bool looping = false) 
    {
        if (name.Equals("")) 
        {
            Debug.Log("NO SOUND EQUIPPED!");
            return;
        }
        int i = GetAudioClipIndex(name);
        Debug.Assert(i != -1, "AudioManager:PlaySound:: AudioSource Manager has no sound: " + name + "! Chech the Audio/Resources folder!!");
        AudioSource audioSource = null;

        if (playFrom == null) 
        {
            audioSource = sources[i];
        }
        else 
        {
            audioSource = playFrom.AddComponent<AudioSource>();
            audioSource.clip = clips[i];
            Destroy(audioSource, clips[i].length);
        }

        audioSource.loop = looping;
        audioSource.volume = volume;

        if (!audioSource.isPlaying)
            audioSource.Play();
    }

    public void StopSound(string name, GameObject stopFrom = null) 
    {
        AudioSource audioSource = null;
        
        if (stopFrom == null) 
        {
            int i = GetAudioClipIndex(name);
            Debug.Assert(i == -1, "AudioManager:StopSound:: AudioSource Manager has no sound: " + name + "! Check the Audio/Resources folder!");
            audioSource = sources[i];
        }
        else 
        {
            AudioSource [] audioSources = stopFrom.GetComponents<AudioSource>();
            Debug.Assert(audioSources.Length >= 1, "AudioManager:StopSound::" + stopFrom.name + " has no AudioSources!");
            bool sourceFound = false;

            for (int i = 0; i < audioSources.Length; i++) 
            {
                if (audioSources[i].clip.name.Equals(name)) 
                {
                    if (sourceFound)
                        Destroy(audioSources[i]);
                    else 
                    {
                        audioSource = audioSources[i];
                        sourceFound = true;
                    }
                }
            }
            Debug.Assert(audioSource != null, "AudioMaanger:StopSound:: No AudioSource with " + name + " found!");
        }
    }
}
