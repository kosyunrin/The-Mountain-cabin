using System.Runtime.Remoting.Messaging;
using UnityEngine.Events;
using UnityEngine;
using System.Collections;

namespace SK
{
    public enum ActionID
    {
        nothing,
        pushing,
        Driving
    };
    public abstract class skStateMachine
    {
        protected UnityEvent mEnterEnvents;
        protected UnityEvent mExitEnvents;
        protected UnityEvent mStartActionEvents;
        protected UnityEvent mExitActionEvents;
        protected UnityEvent mEnterPoseEnvents;
        protected UnityEvent mExitPoseEvents;
        protected ActionID ID;
        protected bool IsStopUpdate;
        abstract public void SetPoseEnvents(UnityEvent Entervar, UnityEvent Exitvar);
        abstract public void SetIsStoppingUpdate(bool stop);
        abstract public  void SetUnityEvents( UnityEvent Entervar,  UnityEvent Exitvar);
        abstract public void SetActionEvents(UnityEvent Entervar, UnityEvent Exitvar);
        abstract public ActionID GetStateId { get; }
        abstract public void Enter();
        abstract public void Execute(Animator anim);
        abstract public void Exit();
    }
    //public class skStateMachineManager
    //{
    //    private skStateMachine currentState = null;
    //    private skStateMachine previousState = null;
    //    private bool isStop;

    //    public skStateMachine CurrentState
    //    {
    //        get
    //        {
    //            return currentState;
    //        }
    //    }
    //    public skStateMachine PreviousState
    //    {
    //        get
    //        {
    //            return previousState;
    //        }
    //    }
    //    public bool IsStop
    //    {
    //        get
    //        {
    //            return isStop;
    //        }

    //        set
    //        {
    //            isStop = value;
    //        }
    //    }
    //}
    public class skPushState : skStateMachine
    {
        const ActionID push = ActionID.pushing;
        bool pushingpose = false;
        public Transform mTargetPos;
        public Transform mHandPos;
        public float DelayTime = 0;
        public float RunTime = 0;
        public override ActionID GetStateId
        {
            get
            {
                return push;
            }
        }

        public override void Enter()
        {
            if (mEnterEnvents != null)
                mEnterEnvents.Invoke();
            RunTime = 0.0f;
        }

        public override void Execute(Animator anim)
        {
           // if (!IsStopUpdate) return;
            pushingpose = false;

            if (Input.GetKey(KeyCode.E))
            {
                anim.SetBool("IsPushPose", true);
                anim.SetBool("IsPushStop", false);
                pushingpose = true;
                if(!IsStopUpdate)
                RunTime += Time.deltaTime;
                if (RunTime >= DelayTime)
                {
                    IsStopUpdate = true;
                    RunTime = 0.0f;
                }
            }
            if (!pushingpose)
            {
                anim.SetBool("IsPushing", false);
                anim.SetBool("IsPulling", false);
                anim.SetBool("IsPushPose", false);
                anim.SetBool("IsPushStop", true);
                if(mExitActionEvents!=null)
                mExitActionEvents.Invoke();
            }
            if (!IsStopUpdate) return;
            if (pushingpose)
            {
                if (Input.GetKey(KeyCode.W))
                {
                    anim.SetBool("IsPushPose", false);
                    anim.SetBool("IsPulling", false);
                    anim.SetBool("IsPushing", true);
                    mTargetPos.position = mHandPos.position;
                    if (mStartActionEvents != null)
                        mStartActionEvents.Invoke();
                }
                else if (Input.GetKey(KeyCode.S))
                {
                    anim.SetBool("IsPushPose", false);
                    anim.SetBool("IsPushing", false);
                    anim.SetBool("IsPulling", true);
                    mTargetPos.position = mHandPos.position;
                    if (mStartActionEvents != null)
                        mStartActionEvents.Invoke();
                }
              
            }
        }

        public override void Exit()
        {
            if (mExitEnvents != null)
                mExitEnvents.Invoke();
        }

        public override void SetActionEvents(UnityEvent Entervar, UnityEvent Exitvar)
        {
            mStartActionEvents = Entervar;
            mExitActionEvents = Exitvar;
        }

        public override void SetUnityEvents( UnityEvent Entervar,  UnityEvent Exitvar)
        {
            mEnterEnvents = Entervar;
            mExitEnvents = Exitvar;
        }

        public override void SetIsStoppingUpdate(bool stop)
        {
            IsStopUpdate = stop;
        }

        public override void SetPoseEnvents(UnityEvent Entervar, UnityEvent Exitvar)
        {
            mEnterPoseEnvents = Entervar;
            mExitPoseEvents = Exitvar;
        }

    }
    public class skNoneState : skStateMachine
    {
        const ActionID none = ActionID.nothing;
        
        public override ActionID GetStateId
        {
            get
            {
                return none;
            }
        }

     

        public override void Enter()
        {
            if (mEnterEnvents != null)
                mEnterEnvents.Invoke();
        }

        public override void Execute(Animator anim)
        {
        }

        public override void Exit()
        {
            if(mExitEnvents!=null)
            mExitEnvents.Invoke();
        }

        public override void SetActionEvents(UnityEvent Entervar, UnityEvent Exitvar)
        {
            mStartActionEvents = Entervar;
            mExitActionEvents = Exitvar;
        }

        public override void SetIsStoppingUpdate(bool stop)
        {
            IsStopUpdate = stop;
        }

        public override void SetPoseEnvents(UnityEvent Entervar, UnityEvent Exitvar)
        {
            mEnterPoseEnvents = Entervar;
            mExitPoseEvents = Exitvar;
        }

        public override void  SetUnityEvents( UnityEvent Entervar,  UnityEvent Exitvar)
        {
            mEnterEnvents = Entervar;
            mExitEnvents = Exitvar;
        }
    }
    public class skDrivingState : skStateMachine
    {
        const ActionID driving = ActionID.Driving;

        public override ActionID GetStateId
        {
            get
            {
                return driving;
            }
        }

        public override void Enter()
        {

            if (mEnterEnvents != null)
                mEnterEnvents.Invoke();
        }

        public override void Execute(Animator anim)
        {
            if(Input.GetKeyDown(KeyCode.E))
            {
                anim.PlayInFixedTime("Exiting Car");
            }
        }

        public override void Exit()
        {
            if (mExitEnvents != null)
                mExitEnvents.Invoke();
        }

        public override void SetActionEvents(UnityEvent Entervar, UnityEvent Exitvar)
        {
        }

        public override void SetIsStoppingUpdate(bool stop)
        {
        }

        public override void SetPoseEnvents(UnityEvent Entervar, UnityEvent Exitvar)
        {
        }

        public override void SetUnityEvents(UnityEvent Entervar, UnityEvent Exitvar)
        {
        }
    }
}
