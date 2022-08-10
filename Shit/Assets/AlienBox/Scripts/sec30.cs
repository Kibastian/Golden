using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ToDyToScAnO // <-- This is a namespace
{
    public class sec30 : MonoBehaviour
    {
        private float startTime = 0f;
        private float progressTime = 0f;//normal
        GameObject time1;
        GameObject time12;
        public bool bEnable = false;
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            // time2.SetActive(bEnable);
            if (bEnable)
            {
                progressTime = (Time.time - startTime);
                if (progressTime >= 30)
                {
                    //time.text = (30 - progressTime).ToString();
                    progressTime -= 30;
                    startTime = Time.time;
                }
            }
        }
    }
}
