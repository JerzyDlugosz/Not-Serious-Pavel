using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class Leaderboard : MonoBehaviour
{
    const string privateKey= "3OcYB48wtUugrEF5elrNow-mmY5uahHkadbjDsSXnjyg";
    const string  publicKey= "5eaee6220cf2aa0c28ecae0a";
    const string webURL= "http://dreamlo.com/lb/";
    static Leaderboard instance;
    public  List<LeaderBoardData> leadearboard = new List<LeaderBoardData>();
    DisplayLeaderboard displayLeaderboard;
    public static List<string> DontDestroyStrings = new List<string>();
    void Awake()
    {
        if (instance == null) 
        { 
            instance = this; 
        } 
        else 
        {
            Destroy(transform.gameObject);
        }
        DontDestroyOnLoad(transform.gameObject);
        displayLeaderboard = GetComponent<DisplayLeaderboard>();
    }


   public static void AddNewRow(string username, int score,int time, string rank)
    {
        instance.StartCoroutine(instance.UploadLeaderboard(username, score,time, rank));
    }

    void errorr()
    {
        AddNewHighscore d = gameObject.GetComponent<AddNewHighscore>();
        d.ErrorSend();
    }
    void SUCCESSFUL()
    {
        AddNewHighscore d = gameObject.GetComponent<AddNewHighscore>();
        d.Success();
    }

    IEnumerator UploadLeaderboard(string username, int score,int time, string rank)
    {
        UnityWebRequest www = UnityWebRequest.Post(webURL + privateKey + "/add/" + UnityWebRequest.EscapeURL(username) + "/" + score + "/" + time + "/" + rank,"");
        yield return www.SendWebRequest();
        if (string.IsNullOrEmpty(www.error))
        {
            SUCCESSFUL();
            //Debug.Log("Upload succesful");
        }
        else
        {
            errorr();
        }
    }

   public  void GetLeaderboard()
    {
        StartCoroutine("GetLeaderboardFromDB");
    }

  
    IEnumerator GetLeaderboardFromDB()
    {
        UnityWebRequest www =  UnityWebRequest.Get(webURL + publicKey + "/pipe/" );
        yield return www.SendWebRequest();

        if (string.IsNullOrEmpty(www.error))
        {
            ChangeDataFormat(www.downloadHandler.text);
            displayLeaderboard.OnDownloaded(leadearboard);
            leadearboard.Clear();
        }
        else
        {
            //Debug.LogError("Błąd przy pobieraniu" + www.error);
        }
    }

       void ChangeDataFormat(string textStream)
       {
            string username, rank;
            int score;
            string time;
            string dateTime;
            string[] entries = textStream.Split(new char[] { '\n' }, System.StringSplitOptions.RemoveEmptyEntries);
          
               foreach(var entry in entries)
               {
                    string[] entryInfo = entry.Split(new char[] { '|' });
                    username = entryInfo[0];
                    username = username.Replace("+", " ");
                    score =int.Parse(entryInfo[1]);
                    time = entryInfo[2];
                    time = ChangeTime(time);
                    rank = entryInfo[3];
                    dateTime = entryInfo[4];
                    leadearboard.Add(new LeaderBoardData(username, score, time, rank,dateTime));
              
               }
    }

    public static string ChangeTime(string time)
    {
        char min = '0';
        string returnTime;
        int seconds = int.Parse(time);
        int loss = seconds;
        string lossstring;

        if (seconds >= 60)
        {
            seconds /= 60;
            loss = loss - (60* seconds);

            if (loss == 0)
            {
                lossstring = loss.ToString()+"0";
            }
            else if(loss<10 && loss!=0)
            {
                lossstring = "0"+loss.ToString();
            }
            else 
            {
                lossstring =  loss.ToString();
            }

        }
        else
        {
            if (seconds < 10)
            {
                return _ = "0:0" + time + " s";
            }
            else
            {
                return _ = "0:" + time + " s";
            }
        }

        if (seconds < 10)
        {
            returnTime = min + seconds.ToString() + ":" + lossstring;
        }
        else
        {
            returnTime = seconds.ToString() + ":" + lossstring;
        }

        return returnTime +" min";
    }



    public struct LeaderBoardData
    {
        public string username;
        public int score;
        public string time;
        public string rank;
        public string date;

        public LeaderBoardData(string _username, int _score, string _time,string _rank, string _date)
        {
            username = _username;
            score = _score;
            time = _time;
            rank = _rank;
            date = _date;
        }
    }
}
