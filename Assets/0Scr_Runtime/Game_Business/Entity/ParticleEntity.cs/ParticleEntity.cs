using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace VR {



    public class ParticleEnity : MonoBehaviour {



        public ParticleSystem particleSys; //粒子系统

        public ParticleSystem.Particle[] particleArr; //粒子数组

        public SingleParticle[] circle; //极坐标系

        public Gradient grad; //颜色渐变

        public int count = 100000; //粒子数量

        public float size = 0.1f; //粒子大小
        public float minRadius = 0.1f; //最小半径

        public float maxRadius = 0.15f; //最大半径

        public float speed = 0.1f; //速度

        public float pingPong = 0.02f; //游离范围

        public float rotate_speed = -1f; //旋转速度(正负代表方向)

        public bool roatte_way = false;

        public float time = 0;


        void Start() {

            particleArr = new ParticleSystem.Particle[count];
            circle = new SingleParticle[count];
            // 初始化粒子系统
            particleSys = this.GetComponent<ParticleSystem>();

            //粒子位置由程序控制
            var m = particleSys.main;

            m.startSpeed = 0;//设置粒子速度
            m.startSize = size;//设置粒子大小
            m.loop = false;//不循环
            m.maxParticles = count;//设置最大粒子量
            particleSys.Emit(count);//发射粒子
            particleSys.GetParticles(particleArr);//获取所有粒子

            Init();//初始化各粒子位置


        }

        void Init() {
            for (int i = 0; i < count; i++) {
                // 每个粒子距离中心点的半径 ， 
                float midRadius = (maxRadius + minRadius) / 2;//中间半径
                float minRate = UnityEngine.Random.Range(1.0f, midRadius / minRadius);//随机每个粒子与中心点的半径比例
                float maxRate = UnityEngine.Random.Range(midRadius / maxRadius, 1.0f);//随机每个粒子与中心点的半径比例
                float radius = UnityEngine.Random.Range(minRadius * minRate, maxRadius * maxRate);//随机每个粒子与中心点的半径
                // 随机每个粒子与中心点的角度
                float angle = UnityEngine.Random.Range(0.0f, 360.0f);

                circle[i] = new SingleParticle(angle, radius);

                circle[i].CalPosition();

                // 随机每个粒子的游离起始时间

                particleArr[i].position = new Vector3(circle[i].getX(), circle[i].getY(), 0);

            }
            particleSys.SetParticles(particleArr, particleArr.Length);
        }

        public int tier = 10; //层数

        void Update() {

            time += Time.deltaTime;
            if (time < 10) {
                if (time < 5) {
                    roatte_way = false;
                    rotate_speed += 0.1f;
                } else {
                    roatte_way = true;
                    rotate_speed -= 0.1f;
                }
            } else {
                time = 0;
                rotate_speed = -1f;
            }




            int level = 10;

            for (int i = 0; i < count; i++) {



                if (i % level < 3 || i % level > 6) {
                    circle[i].angel -= rotate_speed * (i * level + 1) * speed;
                } else {
                    circle[i].angel += rotate_speed * (i * level + 1) * speed;
                }

                circle[i].angel = (circle[i].angel + 360) % 360;
                circle[i].CalPosition();

                float value = Time.realtimeSinceStartup % 1;
                value -= rotate_speed * circle[i].radius / 360.0f;

                while (value > 1) {
                    value -= 1;
                }
                while (value < 0) {
                    value += 1;
                }

                // particleArr[i].startColor = grad.Evaluate(value);

                particleArr[i].position = new Vector3(circle[i].getX(), circle[i].getY(), 0);


                if (i % level > 5) {
                    float tmp = roatte_way ? 1 : -1;
                    circle[i].radius += tmp * 0.05f;
                }
                if (i % level <= 6) {
                    float tem = roatte_way ? 1 : -1;
                    circle[i].radius += tem * 0.053f;
                }

            }
            particleSys.SetParticles(particleArr, particleArr.Length);
        }


        // public class CirlcePostion {
        //     public float radius;

        //     public float angle;

        //     public float time;
        //     public CirlcePostion(float radius, float angle, float time) {
        //         this.radius = radius;
        //         this.angle = angle;
        //         this.time = time;

        //     }
        // }


    }


}