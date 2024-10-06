using System;
using System.Collections.Generic;


namespace VR {

    public class RoleRepo {

        Dictionary<int, RoleEntity> all;

        RoleEntity[] temArray;

        public RoleRepo() {
            all = new Dictionary<int, RoleEntity>();
            temArray = new RoleEntity[5];
        }

        public void Add(RoleEntity entity) {
            all.Add(entity.id, entity);
        }

        public void Remove(RoleEntity entity) {
            all.Remove(entity.id);
        }

        public int TakeAll(out RoleEntity[] array) {
            if (all.Count > temArray.Length) {
                temArray = new RoleEntity[all.Count * 2];
            }
            all.Values.CopyTo(temArray, 0);

            array = temArray;
            return all.Count;

        }

        public bool TryGet(int id, out RoleEntity entity) {
            return all.TryGetValue(id, out entity);
        }

        public void Foreach(Action<RoleEntity> action) {
            foreach (var item in all.Values) {
                action(item);
            }
        }
        public RoleEntity Find(Predicate<RoleEntity> predicate) {
            foreach (RoleEntity Role in all.Values) {
                bool isMatch = predicate(Role);

                if (isMatch) {
                    return Role;
                }
            }
            return null;
        }

    }
}