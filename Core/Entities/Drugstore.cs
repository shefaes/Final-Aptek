﻿using Core.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Drugstore: IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public byte ContactNumber { get; set; }
        public List<Druggists>Druggists { get; set; }
        public List<Drug> Drugs { get; set; }
        public string Owner { get; set; }


    }
}