using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


namespace Hyno
{
    public delegate void DelegateFinishDialogue();

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

        [SerializeField, Header("�H�J���j")]
        private float intervalFadeIn = 0.1f;
        [SerializeField, Header("���r���j")]
        private float intervalType = 0.1f;



        private DataNPC dataNpc;

        private void Awake()
        {
            aud = GetComponent<AudioSource>();

            //StartCoroutine(Fade());

            //StartCoroutine(StartDialogue());
        }

        #region ���}���
        /// <summary>
        /// �O�_�b��ܤ�
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
