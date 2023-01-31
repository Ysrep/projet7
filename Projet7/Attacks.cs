using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Common;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Projet7
{
    [Serializable]
    public class AttackList
    {
        [JsonInclude]
        public Attack[] Attacks;

    }

    [Serializable]
    public class Attack
    {
        static Dictionary<int, Attack> _attackList;

        static Attack()
        {
            var json = File.ReadAllText("../../../Attacks.json");
            var attackList = JsonSerializer.Deserialize<AttackList>(json);
            _attackList = new Dictionary<int, Attack>(attackList.Attacks.Select(i => new KeyValuePair<int, Attack>(i.id, i)));
        }


        [JsonInclude]
        public int id;
        [JsonInclude]
        public string ename;
        [JsonInclude]
        public string type;
        [JsonInclude]
        public int? accuracy;
        [JsonInclude]
        public int power;
        [JsonInclude]
        public int pp;
        [JsonInclude]
        public string category;
        public int currentPp;

        public static Attack GetAttack(int id)
        {
            var neuf = _attackList.GetValueOrDefault(id);

            var newa = new Attack()
            {
                id = neuf.id,
                ename = neuf.ename,
                type = neuf.type,
                accuracy = neuf.accuracy,
                power = neuf.power,
                pp = neuf.pp,
                category = neuf.category
            };
            int currentPp = newa.pp;
            return newa;
        }
    }
}