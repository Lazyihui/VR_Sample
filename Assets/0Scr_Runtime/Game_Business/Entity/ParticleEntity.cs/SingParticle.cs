using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VR {


    public class SingleParticle {
        public float angel;

        public float radius;


        public float x = 0.0f;

        public float y = 0.0f;

        public void CalPosition() {
            float temp = angel / 180.0f * Mathf.PI;
            y = radius * Mathf.Sin(temp);
            x = radius * Mathf.Cos(temp);
        }

        public SingleParticle(float angel, float radius) {
            this.angel = angel;
            this.radius = radius;
        }

        public float getX() {
            return x;

        }

        public float getY() {
            return y;
        }

    }
}