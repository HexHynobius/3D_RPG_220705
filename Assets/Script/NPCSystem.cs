using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Hyno
{
    public class NPCSystem : MonoBehaviour
    {
        [SerializeField, Header("NPC 對話資料")]
        private DataNPC dataNPC;
        [SerializeField, Header("NPC 攝影機")]
        private GameObject goCamera;

        private Animator aniTip;

        private string parTipFade = "觸發淡入淡出";
        private bool isInTrigger;
        private ThirdPersonController thirdPersonController;
        private DialogueSystem dialogueSystem;

        private Animator ani;
        private string parDialogue = "對話";

        private void Awake()
        {
            aniTip = GameObject.Find("對話提示底圖").GetComponent<Animator>();

            thirdPersonController = FindObjectOfType<ThirdPersonController>();
            dialogueSystem = FindObjectOfType<DialogueSystem>();
            ani = GetComponent<Animator>();
        }

        private void OnTriggerEnter(Collider other)
        {
            CheckPlayerAndanimation(other.name, true);
        }

        private void OnTriggerExit(Collider other)
        {
            CheckPlayerAndanimation(other.name, false);
        }

        private void Update()
        {
            InputKeyAndStarDialogue();
        }

        private void CheckPlayerAndanimation(string nameHit, bool _isInTrigger)
        {
            if (nameHit == "Player")
            {
                isInTrigger = _isInTrigger;
                aniTip.SetTrigger(parTipFade);
            }
        }

        private void InputKeyAndStarDialogue()
        {
            if (dialogueSystem.isDialogue) return;

            if (isInTrigger && Input.GetKeyDown(KeyCode.E))
            {
                goCamera.SetActive(true);
                aniTip.SetTrigger(parTipFade);
                thirdPersonController.enabled = false;
                try
                {
                    ani.SetBool(parDialogue, true);
                }
                catch (System.Exception)
                {
                    print("缺動畫");
                    //throw;
                }
                //if (ani) ani.SetBool(parDialogue, true);
                StartCoroutine(dialogueSystem.StartDialogue(dataNPC, ResetControllerAndCloseCamera));
            }
        }

        private void ResetControllerAndCloseCamera()
        {
            goCamera.SetActive(false);
            thirdPersonController.enabled = true;
            try
            {
                aniTip.SetTrigger(parTipFade);
            }
            catch (System.Exception)
            {
                print("缺動畫");
                //throw;
            }
            //if (ani) aniTip.SetTrigger(parTipFade);
            //ani.SetBool(parDialogue, false);
        }
    }
}

