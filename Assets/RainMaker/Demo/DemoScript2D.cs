using UnityEngine;
using System.Collections;

namespace DigitalRuby.RainMaker
{
    public class DemoScript2D : MonoBehaviour
    {
        // public UnityEngine.UI.Slider RainSlider;
        public RainScript2D RainScript;
        private float changewethe = 5;
        public float Intensity = -1;

        private void Start()
        {
            RainScript.RainIntensity  = 1f;
            RainScript.EnableWind = true;
        }

        private void Update()
        {
            if(changewethe <= 0 && RainScript.RainIntensity < 0.2f)
            {
                Intensity = Random.Range(0.2f,0.5f);
                changewethe = Random.Range(10,15);
            }
            if(RainScript.RainIntensity < Intensity && Intensity != -1)RainScript.RainIntensity+=Time.deltaTime/50;
            else if(RainScript.RainIntensity > Intensity && Intensity != -1)RainScript.RainIntensity-=Time.deltaTime/50;
            else RainScript.RainIntensity-=Time.deltaTime/1000;
            changewethe -= Time.deltaTime;
            Vector3 worldBottomLeft = Camera.main.ViewportToWorldPoint(Vector3.zero);
            Vector3 worldTopRight = Camera.main.ViewportToWorldPoint(Vector3.one);
            float visibleWorldWidth = worldTopRight.x - worldBottomLeft.x;

            if (Input.GetKey(KeyCode.LeftArrow))
            {
                Camera.main.transform.Translate(Time.deltaTime * -(visibleWorldWidth * 0.1f), 0.0f, 0.0f);
            }
            else if (Input.GetKey(KeyCode.RightArrow))
            {
                Camera.main.transform.Translate(Time.deltaTime * (visibleWorldWidth * 0.1f), 0.0f, 0.0f);
            }
        }

        public void RainSliderChanged(float val)
        {
            RainScript.RainIntensity = val;
        }

        public void CollisionToggleChanged(bool val)
        {
            RainScript.CollisionMask = (val ? -1 : 0);
        }
    }
}