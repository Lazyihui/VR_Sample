using System;
using System.Collections.Generic;


namespace VR {

    public class HandRepo {

        Dictionary<int, HandEntity> all;

        HandEntity[] temArray;

        public HandRepo() {
            all = new Dictionary<int, HandEntity>();
            temArray = new HandEntity[5];
        }

        public void Add(HandEntity entity) {
            all.Add(entity.id, entity);
        }

        public void Remove(HandEntity entity) {
            all.Remove(entity.id);
        }

        public int TakeAll(out HandEntity[] array) {
            if (all.Count > temArray.Length) {
                temArray = new HandEntity[all.Count * 2];
            }
            all.Values.CopyTo(temArray, 0);

            array = temArray;
            return all.Count;

        }

        public bool TryGet(int id, out HandEntity entity) {
            return all.TryGetValue(id, out entity);
        }

        public void Foreach(Action<HandEntity> action) {
            foreach (var item in all.Values) {
                action(item);
            }
        }
        public HandEntity Find(Predicate<HandEntity> predicate) {
            foreach (HandEntity Hand in all.Values) {
                bool isMatch = predicate(Hand);

                if (isMatch) {
                    return Hand;
                }
            }
            return null;
        }

    }
}