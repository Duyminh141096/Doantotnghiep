using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
public class ManagerShop : MonoBehaviour
{

    [System.Serializable]
    public class Charator
    {
        //public int id;
        public GameObject charater;
        public SpriteRenderer backImage;
        public SpriteRenderer normalImage;
        public float cost;
        public float status;
        public Text textStatus;
    }
    // public GameObject[] player;

    public List<Charator> charators;

    public Player player;

    int CountPressed = 0;
    public GameObject[] cha;

    public GameObject effect;

    public Text Diamondtext;
    //  public Text costOrSelect;

    //  public GameObject shop;
    // Use this for initialization
    [Header("_______________________")]
    public bool reset;
    public float resetDiamond;
    void Start()
    {
        if (reset)
        {
            //PlayerPrefs.DeleteAll();
            PlayerPrefs.SetFloat("diamond", resetDiamond);
            Debug.Log("reset completed");
        }
        CheckStatusCharacter();
        //CheckStatus();
        //Debug.Log(PlayerPrefs.GetFloat("character"));
        if (PlayerPrefs.GetFloat("character") != 0)
            SelectedCharacter((int)(PlayerPrefs.GetFloat("character")));
    }

    void CheckStatusCharacter()
    {
        for (int i = 0; i < charators.Count; i++)
        {
            if(i == 0)
            {
                charators[i].status = 1;
                PlayerPrefs.SetFloat("" + i, charators[i].status);
            }
            charators[i].status = PlayerPrefs.GetFloat("" + i);
            //PlayerPrefs.SetFloat("" + i, 0);
        }
        
    }

    public void CheckStatus()
    {
        Diamondtext.text = PlayerPrefs.GetFloat("diamond").ToString();
        PlayerPrefs.SetFloat("diamond", PlayerPrefs.GetFloat("diamond"));
        for (int i = 0; i < charators.Count; i++)
        {
            //chua mua
            if (charators[i].status == 0)
            {
                charators[i].backImage.enabled = true;
                charators[i].normalImage.enabled = false;
                charators[i].textStatus.text = charators[i].cost.ToString();
                //costOrSelect.text = charators[i].cost.ToString();
            }
            //da mua roi
            else
            {
                charators[i].backImage.enabled = false;
                charators[i].normalImage.enabled = true;
                charators[i].textStatus.text = "SELECT";
                // costOrSelect.text = "SELECT";
            }
        }
    }

    public void checkBuyorSelect(int i)
    {
        if (charators[i].textStatus.text == "SELECT")
        {
            SelectedCharacter(i);
        }
        else
        {
            BuyCharacter(i);
        }
    }
    void BuyCharacter(int i)
    {
        if (PlayerPrefs.GetFloat("diamond") >= charators[i].cost)
        {
            PlayerPrefs.SetFloat("diamond", PlayerPrefs.GetFloat("diamond") - charators[i].cost);
            Debug.Log(PlayerPrefs.GetFloat("diamond"));
            charators[i].status = 1;
            PlayerPrefs.SetFloat("" + i, charators[i].status);
            GameObject Effect = Instantiate(effect, cha[i].transform);
            Destroy(Effect, 1.5f);
            CheckStatus();
        }
        else
        {
            // k du tien
            Debug.Log("Not enough money");
        }
    }
    // 1 bien luu character nao da duoc select. de khi vao game thi gameobject cua character do active
    void SelectedCharacter(int i)
    {
        for (int j = 0; j < charators.Count; j++)
        {
            if (j == i)
            {
                charators[j].charater.SetActive(true);
                PlayerPrefs.SetFloat("character", j);
            }
            else
            {
                charators[j].charater.SetActive(false);
            }

        }
    }
    // Update is called once per frame
    void Update()
    {

    }


    public void NextButton()
    {
        //cha[CountPressed].transform.DOScale(Vector3.zero,0.5f);
        cha[CountPressed].SetActive(false);
        CountPressed++;
        if (CountPressed >= cha.Length)
        {
            cha[CountPressed - 1].SetActive(false);
            CountPressed = 0;
        }
        cha[CountPressed].SetActive(true);

    }
    
    public void BackButton()
    {
        
        cha[CountPressed].SetActive(false);
        CountPressed--;
        if (CountPressed < 0)
        {
            cha[0].SetActive(false);
            CountPressed = cha.Length - 1;
        }
        cha[CountPressed].SetActive(true);
    }

    //public void PlayerSelected(int STTPlayer)
    //{

    //    for (int i = 0; i < player.Length ; i++)
    //    {
    //        if(i == STTPlayer)
    //        {
    //            player[STTPlayer].SetActive(true);
    //        }
    //        else
    //        {
    //            player[i].SetActive(false);
    //        }
    //    }
    //}

}
