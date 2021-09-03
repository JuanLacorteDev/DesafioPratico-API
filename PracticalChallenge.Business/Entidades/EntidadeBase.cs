using System;
using System.Collections.Generic;
using System.Text;

namespace PracticalChallenge.Business.Entidades
{
    public abstract class EntidadeBase
    {
        protected EntidadeBase()
        {
            Id = Guid.NewGuid();
        }
        public Guid Id { set; get; }
    }
}
