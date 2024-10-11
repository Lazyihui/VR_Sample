using System;
using UnityEngine;


namespace VR {

    public static class ParticleDomain {

        public static ParticleEnity Spawn(GameContext ctx) {
            GameObject prefab = ctx.assetsCore.Entity_Particle();
            if (prefab == null) {
                Debug.LogError("ParticleEnity prefab is null");
                return null;
            }

            GameObject go = GameObject.Instantiate(prefab);
            ParticleEnity entity = go.GetComponentInChildren<ParticleEnity>();

            entity.Ctor();
            entity.id = ctx.gameEntity.particleRecoredID++;
            ctx.particleRepo.Add(entity);

            return entity;
        }


        public static void UnSpawn(GameContext ctx, ParticleEnity particle) {
            Debug.Assert(particle != null, "particle is null");
            Debug.Assert(ctx.particleRepo != null, "ctx.particleRepo is null");
            ctx.particleRepo.Remove(particle);
            particle.TearDown();
        }

        public static void ParticleTick(GameContext ctx, ParticleEnity particle, float dt) {

            particle.time += dt;

            if (particle.time < 8) {
                if (particle.time < 4) {
                    particle.roatte_way = false;
                    particle.rotate_speed += 0.2f;
                } else {
                    particle.roatte_way = true;
                    particle.rotate_speed -= 0.2f;
                }
            } else {
                particle.time = 0;
                particle.rotate_speed = -1f;
            }

            int level = 10;
            for (int i = 0; i < particle.count; i++) {
                SingleParticle circle = particle.circles[i];

                float speed = particle.speed;

                if (i % level < 3 || i % level > 6) {
                    circle.angel -= particle.rotate_speed * (i * level + 1) * speed;
                } else {
                    circle.angel += particle.rotate_speed * (i * level + 1) * speed;
                }
                circle.angel = (circle.angel + 360) % 360;
                circle.CalPosition();

                float value = Time.realtimeSinceStartup % 1;
                value -= particle.rotate_speed * circle.radius / 360.0f;

                while (value > 1) {
                    value -= 1;
                }
                while (value < 0) {
                    value += 1;
                }

                // particleArr[i].startColor = grad.Evaluate(value);

                particle.particleArr[i].position = new Vector3(circle.getX(), circle.getY(), 0);


                if (i % level > 5) {
                    float tmp = particle.roatte_way ? 1 : -1;
                    circle.radius += tmp * 0.05f;
                }
                if (i % level <= 6) {
                    float tem = particle.roatte_way ? 1 : -1;
                    circle.radius += tem * 0.053f;
                }

            }

            particle.particleSys.SetParticles(particle.particleArr, particle.particleArr.Length);

        }
    }
}