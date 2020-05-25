using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace webapptest.Models
{
    [Serializable]
    public class User
    {
        private int id;
        private string name;
        private int gender;
        private string birth;
        private int pass;

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public int Gender { get => gender; set => gender = value; }
        public string Birth { get => birth; set => birth = value; }
        public int Pass { get => pass; set => pass = value; }
    }
}
