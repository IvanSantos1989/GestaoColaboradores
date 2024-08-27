
using System;
using System.Drawing;

namespace ColabEFinanceiro
{
    public class Financeiro
    {
        private int contaID;
        private double plafondAlim;
        private double vencAnual;
        private Colaborador colaborador = new Colaborador();

        public Financeiro(double criaVencAnual, double criaPlafondAlim)
        {
            setContaID();
            setVencAnual(criaVencAnual);
            setPlafondAlim(criaPlafondAlim);
        }
        public Financeiro()
        {

        }

        //métodos acessores da classe
        public int getContaID()
        {
            return contaID;
        }
        public double getVencAnual()
        {
            return vencAnual;
        }
        public double getSubsAlim()
        {
            return plafondAlim;
        }


        public void setContaID()
        {
            Random random = new Random();
            contaID = random.Next(1, 101);
        }
        public void setVencAnual(double criaVencAnual)
        {
            vencAnual = criaVencAnual;
        }
        public void setPlafondAlim(double criaPlafondAlim)
        {
            plafondAlim = criaPlafondAlim;
        }

       
    }
}


