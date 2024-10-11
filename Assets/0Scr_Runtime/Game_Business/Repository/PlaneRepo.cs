using System;
using System.Collections.Generic;


namespace VR {

    public class PlaneRepo {

        Dictionary<int, PlaneEntity> all;

        PlaneEntity[] temArray;

        public PlaneRepo() {
            all = new Dictionary<int, PlaneEntity>();
            temArray = new PlaneEntity[5];
        }

        public void Add(PlaneEntity entity) {
            all.Add(entity.id, entity);
        }

        public void Remove(PlaneEntity entity) {
            all.Remove(entity.id);
        }

        public int TakeAll(out PlaneEntity[] array) {
            if (all.Count > temArray.Length) {
                temArray = new PlaneEntity[all.Count * 2];
            }
            all.Values.CopyTo(temArray, 0);

            array = temArray;
            return all.Count;

        }

        public bool TryGet(int id, out PlaneEntity entity) {
            return all.TryGetValue(id, out entity);
        }

        public void Foreach(Action<PlaneEntity> action) {
            foreach (var item in all.Values) {
                action(item);
            }
        }
        public PlaneEntity Find(Predicate<PlaneEntity> predicate) {
            foreach (PlaneEntity Plane in all.Values) {
                bool isMatch = predicate(Plane);

                if (isMatch) {
                    return Plane;
                }
            }
            return null;
        }

    }
}