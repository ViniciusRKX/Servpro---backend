﻿using System.Text.Json.Serialization;

namespace SERVPRO.Models
{
    public class Tecnico: Usuario
    {

        [JsonPropertyOrder(6)]
        public string Especialidade { get; set; }
        [JsonIgnore]
        public List<OrdemDeServico>? OrdensDeServico { get; set; }

    }

}
