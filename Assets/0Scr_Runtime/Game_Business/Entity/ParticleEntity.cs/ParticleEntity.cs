using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace VR {



    public class ParticleEnity : MonoBehaviour {



        public ParticleSystem particleSys; //粒子系统

        public ParticleSystem.Particle[] particleArr; //粒子数组

        public CirlcePostion[] circle; //极坐标系

        public int count = 100; //粒子数量

        public float size = 0.03f; //粒子大小
        public float minRadius = 0.00000001f; //最小半径

        public float maxRadius = 0.00000002f; //最大半径

        public float speed = 0.1f; //速度

        public float pingPong = 0.002f; //游离范围


        void Start() {

            particleArr = new ParticleSystem.Particle[count];
            circle = new CirlcePostion[count];

            // 初始化粒子系统
            particleSys = this.GetComponent<ParticleSystem>();
            //粒子位置由程序控制
            var main = particleSys.main;
            main.startSpeed = 0;//设置粒子速度
            main.startSize = size;//设置粒子大小
            main.loop = false;//不循环
            main.maxParticles = count;//设置最大粒子量
            particleSys.Emit(count);//发射粒子
            particleSys.GetParticles(particleArr);//获取所有粒子

            RandomlySpread();//初始化各粒子位置






        }

        void RandomlySpread() {
            for (int i = 0; i < count; i++) {
                // 每个粒子距离中心点的半径 ， 
                float midRadius = (maxRadius + minRadius) / 2;
                float minRate = UnityEngine.Random.Range(1.0f, midRadius / minRadius);
                float maxRate = UnityEngine.Random.Range(midRadius / maxRadius, 1.0f);
                float radius = UnityEngine.Random.Range(minRadius * minRate, maxRadius * maxRate);
                // 随机每个粒子与中心点的角度
                float angle = UnityEngine.Random.Range(0.0f, 360.0f);
                float theta = angle / 180 * Mathf.PI;

                // 随机每个粒子的游离起始时间

                float time = UnityEngine.Random.Range(0.0f, 360.0f);

                circle[i] = new CirlcePostion(radius, angle, time);

                particleArr[i].position = new Vector3(radius * Mathf.Cos(theta), 0f, radius * Mathf.Sin(theta));

            }
            particleSys.SetParticles(particleArr, particleArr.Length);
        }

        public int tier = 10; //层数

        void Update() {

            for (int i = 0; i < count; i++) {

                circle[i].time += Time.deltaTime;
                circle[i].radius += Mathf.PingPong(circle[i].time / minRadius / maxRadius, pingPong) - pingPong / 2.0f;

                circle[i].angle += (i % tier + 1) * (i % 2 == 0 ? -1 : 1) * speed / circle[i].radius;

                //保证angle在0~360度 
                circle[i].angle = (circle[i].angle + 360) % 360;
                float theta = circle[i].angle / 180 * Mathf.PI;

                particleArr[i].position = new Vector3(circle[i].radius * Mathf.Cos(theta), 0f, circle[i].radius * Mathf.Sin(theta));

            }
            particleSys.SetParticles(particleArr, particleArr.Length);
        }
        public class CirlcePostion {
            public float radius;

            public float angle;

            public float time;
            public CirlcePostion(float radius, float angle, float time) {
                this.radius = radius;
                this.angle = angle;
                this.time = time;

            }
        }


    }


}