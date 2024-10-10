using System;
using System.Collections.Generic;


namespace VR {

    public class ParticleRepo {

        Dictionary<int, ParticleEnity> all;

        ParticleEnity[] temArray;

        public ParticleRepo() {
            all = new Dictionary<int, ParticleEnity>();
            temArray = new ParticleEnity[5];
        }

        public void Add(ParticleEnity entity) {
            all.Add(entity.id, entity);
        }

        public void Remove(ParticleEnity entity) {
            all.Remove(entity.id);
        }

        public int TakeAll(out ParticleEnity[] array) {
            if (all.Count > temArray.Length) {
                temArray = new ParticleEnity[all.Count * 2];
            }
            all.Values.CopyTo(temArray, 0);

            array = temArray;
            return all.Count;

        }

        public bool TryGet(int id, out ParticleEnity entity) {
            return all.TryGetValue(id, out entity);
        }

        public void Foreach(Action<ParticleEnity> action) {
            foreach (var item in all.Values) {
                action(item);
            }
        }
        public ParticleEnity Find(Predicate<ParticleEnity> predicate) {
            foreach (ParticleEnity Particle in all.Values) {
                bool isMatch = predicate(Particle);

                if (isMatch) {
                    return Particle;
                }
            }
            return null;
        }

    }
}