using System;
using System.Collections.Generic;
using System.Text;

namespace exercicio8.models
{
    public abstract class Funcionario
    {

        public String nome;
        public String cargo;
        public double salarioBase;

        public Funcionario(string nome, String cargo, double salarioBase) {
            this.nome = nome;
            this.cargo = cargo;
            this.salarioBase = salarioBase;
        }

        public abstract double ExibirSalario();

    }
}
