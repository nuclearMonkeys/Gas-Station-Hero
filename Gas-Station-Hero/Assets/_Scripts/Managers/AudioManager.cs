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
        
        DirectoryInfo dir = new DirectoryInfo(Application.streamingAssetsPath + "/Audio/Resources");
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
    }
}
