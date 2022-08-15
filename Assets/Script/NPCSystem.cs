using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Hyno
{
    public class NPCSystem : MonoBehaviour
    {
        [SerializeField, Header("NPC ��ܸ��")]
        private DataNPC dataNPC;
        [SerializeField, Header("NPC ��v��")]
        private GameObject goCamera;

        private Animator aniTip;

        private string parTipFade = "Ĳ�o�H�J�H�X";
        private bool isInTrigger;
        private ThirdPersonController thirdPersonController;
        private DialogueSystem dialogueSystem;

        private Animator ani;
        private string parDialogue = "���";

        private void Awake()
        {
            aniTip = GameObject.Find("��ܴ��ܩ���").GetComponent<Animator>();

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
                    print("�ʰʵe");
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
                print("�ʰʵe");
                //throw;
            }
            //if (ani) aniTip.SetTrigger(parTipFade);
            //ani.SetBool(parDialogue, false);
        }
    }
}

