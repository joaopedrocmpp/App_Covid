using App_Covid.Objetos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace App_Covid
{
    public class Controller
    {
        Model model;
        View view;


        public Controller()
        {
            /*Joao*/
            view.DeserializeListaPaises += PaisesResult; // Ponto 2
            model.NotificaListaPaisesPronta += view.ObterListaPaises; // Ponto 4
            view.GetListaPaises += model.PreencheListaDePaises; // Ponto 5
            model.NotificaListaPaisesPreenchida += view.Preencher_lista_Paises; // Ponto 6
            view.DeserializeListaDadosPaises += DadosPaisResult; // Ponto 7s
            model.NotificaCalculosDadosPais += view.ObterDadosPais; // Ponto 10
            view.GetDadosPais += model.PreencheListaDadosPais;  // Ponto 11
            model.NotificaDadosPaisPreenchidos += view.Escreve_resultados_calculos; // Ponto 12
            view.FecharJanela += ClosePressed; // Ponto 13
        }


        //Ponto 2 - Recebe Dados da consulta
        private void PaisesResult(string jsonString)
        {
            model.DeserializeListaPaises(jsonString); // ponto 3
        }

        // ponto 7 - Recebe dados dos paises 
        public void DadosPaisResult(string jsonString)
        {
            view.ActivaViewPorPais();
            model.DeserializeListaDadosPais(jsonString); // Ponto 9
        }



        public void ClosePressed(EventArgs e)
        {
            view.CloseForm(e);
            Environment.Exit(0);
        }




    }
}
