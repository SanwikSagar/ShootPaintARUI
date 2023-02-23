using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace OnefallGames
{
    public class laodingmanager : MonoBehaviour
    {
        
        [SerializeField] private RectTransform gameNameTrans = null;
        

        private int settingButtonTurn = 1;
        public void OnShow()
        {
            //ViewManager.Instance.MoveRect(topBarTrans, topBarTrans.anchoredPosition, new Vector2(topBarTrans.anchoredPosition.x, 0f), 0.75f);
            //ViewManager.Instance.MoveRect(bottomBarTrans, bottomBarTrans.anchoredPosition, new Vector2(bottomBarTrans.anchoredPosition.x, 150f), 0.75f);
            ViewManager.Instance.ScaleRect(gameNameTrans, Vector2.zero, Vector2.one, 0.75f);
        }
        


        /// <summary>
        /// Handle the Home view when Dailyreward view or Environment view closes.
        /// </summary>
        public void OnSubViewClose()
        {
           
            ViewManager.Instance.ScaleRect(gameNameTrans, Vector2.zero, Vector2.one, 0.75f);
            
        }





        //public void LeaderboardBtn()
        //{
        //    ViewManager.Instance.PlayClickButtonSound();
        //    StartCoroutine(CRHandleLeaderboardBtn());
        //}
        //private IEnumerator CRHandleLeaderboardBtn()
        //{
        //    if (settingButtonTurn == -1)
        //        SettingBtn();
        //    ViewManager.Instance.ScaleRect(gameNameTrans, Vector2.one, Vector2.zero, 0.5f);
            
        //}

       
    }
}
