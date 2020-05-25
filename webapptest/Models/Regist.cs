using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace webapptest.Models
{
    [Serializable]
    public class Regist
    {
        private string name;
        private int gender;
        private DateTime birth;
        private string birth_kj;
        private string tell;
        private string mail;
        private DateTime createDate;
        private DateTime updateDate;

        public string Name { get => name; set => name = value; }
        public int Gender { get => gender; set => gender = value; }
        public DateTime Birth { get => birth; set => birth = value; }
        public string Birth_kj { get => birth_kj; set => birth_kj = value; }
        public string Tell { get => tell; set => tell = value; }
        public string Mail { get => mail; set => mail = value; }
        public DateTime CreateDate { get => createDate; set => createDate = value; }
        public DateTime UpdateDate { get => updateDate; set => updateDate = value; }
    }
}
