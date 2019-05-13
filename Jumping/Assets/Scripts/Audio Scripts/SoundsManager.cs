using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SoundsManager : MonoBehaviour
{

    public AudioClip jump1, jump2,jump4,jump3, highscore, hitscore1, hitscore2, hitscore3,no0,no1,bonusscore;
    public AudioSource audiosrc;
    public static float jumpvolume = 0.5f,passedvolume = 0.5f, highscorevolume = 0.5f, gameovervolume = 0.5f, bonusscorevolume = 0.5f;
    public Slider[] volume;
    void Start()
    {
        Defaulevalue();
    }

    #region Xu ly Sound Volume
    public void Defaulevalue()
    {
        volume[0].value = jumpvolume;
        volume[1].value = passedvolume;
        volume[2].value = highscorevolume;
        volume[3].value = gameovervolume;
        volume[4].value = bonusscorevolume;
    }
    public void JumpVolumeChange()
    {
        jumpvolume = volume[0].value;
    }
    public void PassedVolumeChange()
    {
        passedvolume = volume[1].value;
    }
    public void HighscoreVolumeChange()
    {
        highscorevolume = volume[2].value;
    }
    public void GameoverVolumeChange()
    {
        gameovervolume = volume[3].value;
    }
    public void StarVolumeChange()
    {
        bonusscorevolume = volume[4].value;
    }
    #endregion
    public void Playsound(string namesound)
    {
        switch (namesound)
        {
            case "jump":
                
                int ran = Random.Range(0, 4);
                /*if (ran == 0)
                {
                    audiosrc.clip = jump1;
                    audiosrc.PlayOneShot(jump1, 1f);   
                }
                else if (ran == 1)
                {
                    audiosrc.clip = jump2;
                    audiosrc.PlayOneShot(jump2, 1f);
                    
                }
                else if (ran ==2)
                {
                    audiosrc.clip = jump3;
                    audiosrc.PlayOneShot(jump3, 1f);
                   
                }
                else if (ran == 3)
                {
                    audiosrc.clip = jump4;
                    audiosrc.PlayOneShot(jump4, 1f);
                   
                }*/
                switch (ran)
                {
                    case 0:
                        {
                            audiosrc.clip = jump1;
                            audiosrc.PlayOneShot(jump1, jumpvolume);
                            break;
                        }
                    case 1:
                        {
                            audiosrc.clip = jump2;
                            audiosrc.PlayOneShot(jump2, jumpvolume);
                            break;
                        }
                    case 2:
                        {
                            audiosrc.clip = jump3;
                            audiosrc.PlayOneShot(jump3, jumpvolume);
                            break;
                        }
                    case 3:
                        {
                            audiosrc.clip = jump4;
                            audiosrc.PlayOneShot(jump4, jumpvolume);
                            break;
                        }
                }
                break;
            case "highscore":
                audiosrc.clip = highscore;
                audiosrc.PlayOneShot(highscore, highscorevolume);
                break;
            case "hitscore":
                int rand = Random.Range(0, 3);
                switch (rand)
                {
                    case 0:
                        audiosrc.clip = hitscore1;
                        audiosrc.PlayOneShot(hitscore1, passedvolume);
                        break;
                    case 1:
                        audiosrc.clip = hitscore2;
                        audiosrc.PlayOneShot(hitscore2, passedvolume);
                        break;
                    case 2:
                        audiosrc.clip = hitscore3;
                        audiosrc.PlayOneShot(hitscore3, passedvolume);
                        break;
                }
                    
                /* (rand == 0)
                {
                    audiosrc.clip = hitscore1;
                    audiosrc.PlayOneShot(hitscore1, 1f);
                }
                else if (rand == 1)
                {
                    audiosrc.clip = hitscore2;
                    audiosrc.PlayOneShot(hitscore2, 1f);

                }
                else if (rand == 2)
                {
                    audiosrc.clip = hitscore3;
                    audiosrc.PlayOneShot(hitscore3, 1f);

                }
                */
                break;
            case "gameover":
                int random = Random.Range(0,100);
                if (random == 0)
                {
                    audiosrc.clip = no0;
                    audiosrc.PlayOneShot(no0, gameovervolume);
                }
                else
                {
                    audiosrc.clip = no1;
                    audiosrc.PlayOneShot(no1, gameovervolume);

                }
                break;
            case "bonusscore":
                audiosrc.clip = bonusscore;
                audiosrc.PlayOneShot(bonusscore, bonusscorevolume);
                break;
        }
    }
}
