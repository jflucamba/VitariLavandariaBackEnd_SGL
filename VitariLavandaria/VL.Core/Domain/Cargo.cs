﻿using System.Collections.Generic;

namespace VL.Core.Domain
{
    public class Cargo
    {
        public int Id { get; set; }
        public string Descricao { get; set; }

        public ICollection<Usuario> Usuarios { get; set; }
    }
}