using System;
using System.Collections.Generic;
using System.Text;

namespace PracticalChallenge.Business.Mensagens
{
    public static class MensagensValidacao
    {
        public const string ME001 = "O campo {PropertyName} precisa ser fornecido";
        public const string ME002 = "O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres";
        public const string ME003 = "O campo Valor Unitario está em formato inválido";
    }
}
