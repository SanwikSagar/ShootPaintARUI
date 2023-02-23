using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace OnefallGames
{
    public class ReviveViewController : MonoBehaviour
    {
        [SerializeField] private RectTransform countDownImageTrans = null;
        [SerializeField] private RectTransform skipBtnTrans = null;
        [SerializeField] private Image countDownImg = null;
        [SerializeField] private Text countDownTxt = null;

        public void OnShow()
        {
            ViewManager.Instance.ScaleRect(countDownImageTrans, Vector2.zero, Vector2.one, 0.75f);
            countDownTxt.text = IngameManager.Instance.ReviveCountDownTime.ToString();
            skipBtnTrans.gameObject.SetActive(false);
            StartCoroutine(CRWaitAndShowSkipButton());
            StartCoroutine(CRCountingDown());
            StartCoroutine(CRScalingCountDownText());
        }

        private void OnDisable()
        {
            countDownImageTrans.localScale = Vector2.zero;
            skipBtnTrans.localScale = Vector2.zero;
            countDownImg.fillAmount = 1f;
        }



        private IEnumerator CRWaitAndShowSkipButton()
        {
            yield return new WaitForSeconds(2f);
            skipBtnTrans.localScale = Vector2.zero;
            skipBtnTrans.gameObject.SetActive(true);
            ViewManager.Instance.ScaleRect(skipBtnTrans, Vector2.zero, Vector2.one, 0.5f);
        }


        private IEnumerator CRCountingDown()
        {
            yield return new WaitForSeconds(1f);
            float countingTime = IngameManager.Instance.ReviveCountDownTime;
            float t = 0;
            while (t < countingTime)
            {
                t += Time.deltaTime;
                float factor = t / countingTime;
                countDownImg.fillAmount = Mathf.Lerp(1f, 0f, factor);
                countDownTxt.text = Mathf.RoundToInt(Mathf.Lerp(countingTime, 0f, factor)).ToString();
                yield return null;
            }

            IngameManager.Instance.GameOver();
        }


        private IEnumerator CRScalingCountDownText()
        {
            float fadingTime = 0.25f;
            float t = 0;
            while (gameObject.activeInHierarchy)
            {
                t = 0;
                while (t < fadingTime)
                {
                    t += Time.deltaTime;
                    float factor = t / fadingTime;
                    countDownTxt.rectTransform.localScale = Vector3.Lerp(Vector3.one, Vector3.one * 0.8f, factor);
                    yield return null;
                }

                t = 0;
                while (t < fadingTime)
                {
                    t += Time.deltaTime;
                    float factor = t / fadingTime;
                    countDownTxt.rectTransform.localScale = Vector3.Lerp(Vector3.one * 0.8f, Vector3.one, factor);
                    yield return null;
                }
            }
        }




        public void ReviveBtn()
        {
            ViewManager.Instance.PlayClickButtonSound();
            StopAllCoroutines();
            ServicesManager.Instance.AdManager.ShowRewardedVideoAd();
            gameObject.SetActive(false);
        }

        public void SkipBtn()
        {
            ViewManager.Instance.PlayClickButtonSound();
            StopAllCoroutines();
            IngameManager.Instance.GameOver();
            gameObject.SetActive(false);
        }
    }
}
