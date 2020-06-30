using System;
using System.Text;
using Invector;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

namespace SK
{
    [vClassHeader("Free Envents ", false, iconName = "icon_ko")]
    public class skFreeEnvents : vMonoBehaviour
    {
        [SerializeField] Animator MonoActionEvents=null;
        public UnityEvent mFreeEvents=null;
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
           
        }
        public void FreeEventsInvoke()
        {
            mFreeEvents.Invoke();
        }
        public void OpenleftDoor()
        {
            MonoActionEvents.PlayInFixedTime("CarOpenDoor");
        }
        public void CloseleftDoor()
        {
            MonoActionEvents.PlayInFixedTime("CarCloseDoor");
        }
    }
}
