using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectCharacter : MonoBehaviour
{
    public CharacterChoice character;
    SpriteRenderer sr;
    public SelectCharacter[] chars;
    public GameObject[] textchars;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        if (DataManager.instance.currentCharacter == character)
        {
            OnSelect();
        }
        else OnDeSelect();
    }

    private void OnMouseUpAsButton()
    {
        DataManager.instance.currentCharacter = character;
        OnSelect();
        for (int i = 0; i < chars.Length; i++)
        {
            if (chars[i] == this)
            {
                textchars[i].SetActive(true);
                print("툴팁");
            }

            if (chars[i] != this)
            {
                chars[i].OnDeSelect();
                textchars[i].SetActive(false);
                print("이동");
            }
        }
    }
    void OnDeSelect()
    {
        sr.color = new Color(0.5f, 0.5f, 0.5f);
    }

    void OnSelect()
    {
        sr.color = new Color(1f, 1f, 1f);
    }
}
