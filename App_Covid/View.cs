using App_Covid.Objetos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace App_Covid
{
    public class View
    {
        private List<string> lista_paises;
        private List<DadosPais> lista_dados_pais;
        private janela_Inicial janela;
        private Janela_Detalhes janela_det;

        public delegate void GetEventHandler(ref List<string> listaPaises);
        public event GetEventHandler GetListaPaises;

        public delegate void GetDadosPaisHandler(ref List<DadosPais> lista);
        public event GetDadosPaisHandler GetDadosPais;

        public delegate void DeserializeJsonStringHandler(string jsonString);
        public event DeserializeJsonStringHandler DeserializeListaPaises;
        public event DeserializeJsonStringHandler DeserializeListaDadosPaises;

        public delegate void FecharHandler(EventArgs e); // aqui vai referenciada a janela que pediu para fechar
        public event FecharHandler FecharJanela;

        //**********************************************************
        //  1ra Parte - Preencher com a lista disponivel de paises
        //__________________________________________________________

        //ponto 1
        public void AtivarInterface()
        {
            janela = new Janela_Inicial();
            janela.View = this;
            janela.ShowDialog();

            //solicitar lista de Paises ao webservice
            Solicitar_lista_Paises();
        }
        private void Solicitar_lista_Paises()
        {
            // solicitar ListaPaises ao Webservice
            //Verificar Resposta

            string enviar_string = "dados Json";
            DeserializeListaPaises(enviar_string); // Ponto 2
        }

        // Ponto 4
        public void ObterListaPaises(object obj,EventArgs e)
        {
            GetListaPaises(ref lista_paises); // Ponto 5
        }

        // ponto 6
        public void Preencher_lista_Paises(object onj, EventArgs e)
        {
            //Combobox.itens== lista_Paises:
        }



        //**********************************************************
        //  2da Parte - Pesquisa de Dados
        //__________________________________________________________

        public void AlguemCarregouEmPesquisar()
        {
            // solicitar Lista de dados do Pais ao Webservice
            //Verificar Resposta

            string enviar_string = "dados Json";
            DeserializeListaDadosPaises(enviar_string); // Ponto 7

        }

        // ponto 8 alterar a janela
        public void ActivaViewPorPais()
        {
            janela_det = new Janela_Detalhes();
            janela_det.View = this;
            janela_det.ShowDialog();
        }


        //ponto 10
        public void ObterDadosPais(object obj, EventArgs e)
        {
            GetDadosPais(ref lista_dados_pais); // Ponto 11
        }

        // Ponto12
        public void Escreve_resultados_calculos(object obj, EventArgs e)
        {
            // passa dados para tabela ou whatever
        }

        // Ponto 13
        public void AlguemClicouEmFechar(EventArgs e)
        {
            FecharJanela(e);
        }

        //Ponto 14
        public void CloseForm(EventArgs e)
        {

        }
    }



}
