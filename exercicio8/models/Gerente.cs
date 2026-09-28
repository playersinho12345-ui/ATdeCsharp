using System;
using System.Collections.Generic;
using System.Text;

namespace exercicio8.models
{
    public class Gerente : Funcionario
    {
        public Gerente(string nome, string cargo, double salarioBase):
            base( nome, cargo, salarioBase) { }
        public override double ExibirSalario()
        {
            return salarioBase * 1.20;
        }
    }
}
