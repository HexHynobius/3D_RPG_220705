using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


namespace Hyno
{
    /// <summary>
    /// 對話系統
    /// </summary> 
    [RequireComponent(typeof(AudioSource))]//自動獲得元件
    public class DialogueSystem : MonoBehaviour
    {
        [SerializeField, Header("畫布對話系統")]
        private CanvasGroup groupDialogue;
        [SerializeField, Header("說話者名稱")]
        private TextMeshProUGUI textName;
        [SerializeField, Header("對話內容")]
        private TextMeshProUGUI textContent;

        private AudioSource aud;
        [SerializeField, Header("三角形")]
        private GameObject goTriangle;

        public DataNPC dataNpc;

        private void Awake()
        {
            aud = GetComponent<AudioSource>();

            StartCoroutine(FadeIn());

            textName.text =dataNpc.nameNPC;
            textContent.text = "";
        }

        /* 練習
        /// <summary>
        /// 協同程序
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        private IEnumerator test(float s)
        {
            print("第一行");
            yield return new WaitForSeconds(s);
            print("第二行");

        }
        */

        private IEnumerator FadeIn()
        {
            goTriangle.SetActive(false);

            for (int i = 0; i < 10; i++)
            {
                groupDialogue.alpha += 0.1f;
                yield return new WaitForSeconds(0.1f);
            }
            StartCoroutine(TypeEffext());
        }

        private IEnumerator TypeEffext()
        {
            aud.PlayOneShot(dataNpc.dataDialogue[0].sound);

            string content = dataNpc.dataDialogue[0].content;

            for (int i = 0; i < content.Length; i++)
            {
                textContent.text += content[i];
                yield return new WaitForSeconds(0.05f);
            }

            goTriangle.SetActive(true);
        }



    }

}
