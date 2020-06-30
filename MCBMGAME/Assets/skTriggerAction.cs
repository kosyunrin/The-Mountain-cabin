using Invector;
using Invector.vCharacterController;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

namespace SK
{
    [vClassHeader("OpenCloseEnvents", openClose = false, iconName = "icon_ko")]
    public class skTriggerAction : vMonoBehaviour
    {
        [Tooltip("Start Events")]
        public UnityEvent SEvents;
        [Tooltip("End Events")]
        public UnityEvent EEvents;
        private bool EnventsSwtich;
        [SerializeField] Animator xx=null;
        void Start()
        {
            EnventsSwtich = false;
        }
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                OpenCloseEnvents();
            }
            if (Input.GetKeyDown(KeyCode.W))
            {
                xx.SetBool("IsPushPose", false);
                xx.SetFloat("IsPushing", 1.0f);
            }
            if (Input.GetKeyUp(KeyCode.W))
            {
                xx.SetBool("IsPushPose", true);
                xx.SetFloat("IsPushing", 0.0f);
            }
        }
        public void StartEvent()
        {
            SEvents.Invoke();
        }
        public void EndtEvent()
        {
            EEvents.Invoke();
        }
        //public void OpenCloseEnvents()
        //{
        //    EnventsSwtich = !EnventsSwtich;
        //    if(EnventsSwtich) 
        //        SEvents.Invoke();
        //    else EEvents.Invoke();
        //}
        public void AnimatorSetBool(Animator a)
        {
            a.SetBool("IsPushStop", true);
        }
        public void OpenCloseEnvents()
        {
            EnventsSwtich = !EnventsSwtich;
            if (EnventsSwtich)
            {
                xx.SetBool("IsPushPose", true);
                xx.SetBool("IsPushStop", false);
            }
            else
            {
                xx.SetBool("IsPushPose", false);
                xx.SetBool("IsPushStop", true);
            }
        }
    }
}
