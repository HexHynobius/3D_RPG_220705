using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


namespace Hyno
{
    public delegate void DelegateFinishDialogue();

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

        [SerializeField, Header("淡入間隔")]
        private float intervalFadeIn = 0.1f;
        [SerializeField, Header("打字間隔")]
        private float intervalType = 0.1f;



        private DataNPC dataNpc;

        private void Awake()
        {
            aud = GetComponent<AudioSource>();

            //StartCoroutine(Fade());

            //StartCoroutine(StartDialogue());
        }

        #region 公開資料
        /// <summary>
        /// 是否在對話中
        /// </summary>
        public bool isDialogue;

        public IEnumerator StartDialogue(DataNPC _dataNPC,DelegateFinishDialogue callback)
        {
            isDialogue = true;

            dataNpc = _dataNPC;

            textName.text = dataNpc.nameNPC;
            textContent.text = "";

            yield return StartCoroutine(Fade());

            for (int i = 0; i < dataNpc.dataDialogue.Length; i++)
            {
                yield return StartCoroutine(TypeEffext(i));

                while(!Input.GetKeyDown(KeyCode.E))
                {
                    yield return null;
                }
            }

            StartCoroutine(Fade(false)); ;

            isDialogue =false;

            callback();
        }
        #endregion 

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

        private IEnumerator Fade(bool fadeIn=true)
        {
            goTriangle.SetActive(false);

            float increase = fadeIn ? 0.1f : -0.1f;

            for (int i = 0; i < 10; i++)
            {
                groupDialogue.alpha += increase;
                yield return new WaitForSeconds(intervalFadeIn);
            }
        }

        private IEnumerator TypeEffext(int indexDialogue)
        {
            textContent.text = "";

            aud.PlayOneShot(dataNpc.dataDialogue[indexDialogue].sound);

            string content = dataNpc.dataDialogue[indexDialogue].content;

            for (int i = 0; i < content.Length; i++)
            {
                textContent.text += content[i];
                yield return new WaitForSeconds(intervalType);
            }

            goTriangle.SetActive(true);
        }



    }

}
