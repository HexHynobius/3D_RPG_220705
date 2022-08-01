using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


namespace Hyno
{
    /// <summary>
    /// ��ܨt��
    /// </summary> 
    [RequireComponent(typeof(AudioSource))]//�۰���o����
    public class DialogueSystem : MonoBehaviour
    {
        [SerializeField, Header("�e����ܨt��")]
        private CanvasGroup groupDialogue;
        [SerializeField, Header("���ܪ̦W��")]
        private TextMeshProUGUI textName;
        [SerializeField, Header("��ܤ��e")]
        private TextMeshProUGUI textContent;

        private AudioSource aud;
        [SerializeField, Header("�T����")]
        private GameObject goTriangle;

        public DataNPC dataNpc;

        private void Awake()
        {
            aud = GetComponent<AudioSource>();

            StartCoroutine(FadeIn());

            textName.text =dataNpc.nameNPC;
            textContent.text = "";
        }

        /* �m��
        /// <summary>
        /// ��P�{��
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        private IEnumerator test(float s)
        {
            print("�Ĥ@��");
            yield return new WaitForSeconds(s);
            print("�ĤG��");

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
