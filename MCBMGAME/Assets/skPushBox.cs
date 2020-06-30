using System.Collections;
using System.Collections.Generic;
using Invector;
using UnityEngine;

namespace SK
{
    [vClassHeader("Move Target", openClose = false, iconName = "icon_ko")]

    public class skPushBox : vMonoBehaviour
    {
        [SerializeField] float MAxDistance=0.0f;
        [SerializeField] Transform PlayerPos=null;
        [SerializeField] Vector3 asd=Vector3.zero;
        [SerializeField] Vector3 cha=Vector3.zero;

        //private void OnCollisionEnter(Collision collision)
        //{
        //    if (collision.gameObject.tag == "PushBox")
        //    {
        //        //this.transform.position = Vector3.zero;
        //        this.transform.SetParent(collision.gameObject.transform);
        //    }
        //}
        private void Update()
        {
            //if (PlayerPos != null)
            //{
            //    Ray ray = new Ray(new Vector3 (PlayerPos.position.x,1.0f,PlayerPos.position.z), PlayerPos.forward);
            //    RaycastHit hit;
            //    if (Physics.Raycast(ray, out hit))
            //    {
            //        Debug.DrawLine(ray.origin, hit.point, Color.red);
            //        MAxDistance = hit.distance;
            //    }
            //}
            
        }
        public void AdjustDistanceFromTarget(Transform ColliderPos)
        {
            //playerpos.LookAt(-this.transform.forward);
            //float angle = Vector3.Angle(PlayerPos.transform.forward, ColliderPos.transform.forward);

            PlayerPos.transform.localEulerAngles = ColliderPos.transform.forward;
            //PlayerPos.transform.position -= PlayerPos.transform.forward.normalized * MAxDistance;

            if (PlayerPos != null)
            {
                Ray ray = new Ray(new Vector3(PlayerPos.position.x, 1.0f, PlayerPos.position.z), PlayerPos.forward);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit))
                {
                    asd = hit.point;
                    cha = PlayerPos.transform.forward * MAxDistance;
                     Vector3 Pos = hit.point -(PlayerPos.transform.forward * MAxDistance);

                    PlayerPos.transform.position = new Vector3(Pos.x, PlayerPos.transform.position.y, Pos.z);
                    return;

                }
            }

            //var dir = -Vector3.Normalize( this.transform.forward);
            //Vector3 Diffrece = Distance * dir;
            //playerpos.position = playerpos.position - Diffrece;
        }
        //public void AdjustDistanceFromTarget(Transform PlayerPos)
        //{
        //    Ray ray = new Ray(PlayerPos.position, PlayerPos.forward);
        //    RaycastHit hit;
        //    if(Physics.Raycast(ray,out hit))
        //    {
        //        Debug.DrawLine(ray.origin, hit.point, Color.red);
        //    }
        //}
    }
   
}
