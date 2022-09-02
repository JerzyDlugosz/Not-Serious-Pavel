using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class DisplayLeaderboard : MonoBehaviour
{
    public Text text,_name,score,data,time,rank;
   private Leaderboard leaderboard;

 
    public ListView list;



    private void Awake()
    {

            leaderboard = this.GetComponent<Leaderboard>();
          
            text.text = "Proszę czekać..";
        

        StartCoroutine("Refresh");
    }
    public void OnDownloaded(List<Leaderboard.LeaderBoardData> list)
    {
        text.text = "";
        _name.text = "";
        score.text = "";
        data.text = "";
        time.text = "";
        rank.text = "";
        int i = 1;
        char dot = '.';

        list.Sort((a, b) => b.score - a.score);
  
        foreach (var item in list)
        {
            _name.text +=i.ToString()+dot+item.username +"\n";
            score.text += item.score + "\n";
            time.text += item.time + "\n";
            rank.text += item.rank + "\n";
            data.text += item.date + "\n";
            i++;
        }
    }
    IEnumerator Refresh()
    {
        while (true)
        {
            leaderboard.GetLeaderboard();
            yield return new WaitForSeconds(30);
        }
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene(0);
        SceneManager.MoveGameObjectToScene(GameObject.Find("UI"), SceneManager.GetActiveScene());
    }
}
