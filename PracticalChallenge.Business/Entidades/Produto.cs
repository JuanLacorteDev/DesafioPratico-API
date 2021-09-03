using System;
using System.Collections.Generic;
using System.Text;

namespace PracticalChallenge.Business.Entidades
{
    public class Produto : EntidadeBase
    {
        public string Nome { get; set; }
        public int Quantidade { get; set; }
        public decimal ValorUnitario { get; set; }  
    }
}
