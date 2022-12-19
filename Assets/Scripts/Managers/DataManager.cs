using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CharacterChoice
{
    점성가, 잠금1, 잠금2
}

public class DataManager : MonoBehaviour
{
    public static DataManager instance;
    private void Awake()
    {
        if (instance == null) instance = this;
        else if (instance != null) return;
        DontDestroyOnLoad(gameObject);
    }

    public CharacterChoice currentCharacter;
}
