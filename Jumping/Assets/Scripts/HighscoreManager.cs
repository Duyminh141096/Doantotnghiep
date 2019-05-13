using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HighscoreManager : MonoBehaviour
{
    //public Text[] namesText;
    public List<Text> namesText;
    public List<Text> scoreText;
    public List<float> score;
    public List<string> names;
    public InputField textNames;
    public bool reset;
    void Start()
    {
        if (reset)
        {
            DefaultIndex();
        }
        AssignValue();
    }


    void Update()
    {

    }
    private void DefaultIndex()
    {
        for (int i = 0; i < namesText.Count; i++)
        {
            PlayerPrefs.SetString("name" + i.ToString(), names[i]);
            PlayerPrefs.SetString("score" + i.ToString(), score[i].ToString());
        }
    }
    private void AssignValue()
    {
        for (int i = 0; i < namesText.Count; i++)
        {
            namesText[i].text = PlayerPrefs.GetString("name" + i.ToString());
            scoreText[i].text = PlayerPrefs.GetString("score" + i.ToString());
        }
    }
    public bool detectHighScore()
    {
        for (int i = 0; i < names.Count; i++)
        {
            if (Player.score > score[i])
            {
                return true;
            }
        }
        return false;
    }
    public void SubmitScore()
    {
        for (int i = 0; i < names.Count; i++)
        {
            if (Player.score > score[i])
            {
                //neu diem lon hon diem hien tai 
                //thi chen diem hien tai
                score.Insert(i, Player.score);
                names.Insert(i, textNames.text);
                score.RemoveAt(6);
                names.RemoveAt(6);
                break;
            }

        }
        DefaultIndex();
        AssignValue();
    }
}
