using System;
using System.Collections.Generic;
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
        public int? accuracy { get; set; }
        [JsonInclude]
        public int? power { get; set; }
        [JsonInclude]
        public int? pp { get; set; }

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
                pp = neuf.pp
            };
            return newa;
        }
    }
}