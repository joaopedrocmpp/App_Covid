using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App_Covid.Objetos;
using Newtonsoft.Json;

namespace App_Covid
{
    public class Model
    {
        // Handlers
        public event EventHandler NotificaListaPaisesPronta; // 4
        public event EventHandler NotificaListaPaisesPreenchida; // 6
        public event EventHandler NotificaCalculosDadosPais; //10
        public event EventHandler NotificaDadosPaisPreenchidos; //12

        //Dados
        private List<string> listaPaises;
        private List<DadosPais> listaDadosPais;

        public Model()
        {

        }

        /* Lista de paises*/
        // ponto 3
        public void DeserializeListaPaises(string jsonString)
        {
            //Converte para lista do objecto Pais
            var res = JsonConvert.DeserializeObject<List<Pais>>(jsonString);

            listaPaises = new List<string>();
            
            // Retira nome do pais para a lista de paises
            foreach(Pais p in res)
            {
                listaPaises.Add(p.Country);
            }

            NotificaListaPaisesPronta(this, new EventArgs());  // ponto 4 - Notifica a View
        }

        // Ponto 5 
        public void PreencheListaDePaises(ref List<string> lista)
        {
            lista = this.listaPaises;
            NotificaListaPaisesPreenchida(this, new EventArgs()); // ponto 6 - Notifica View
        }


        /* Lista de dados do país*/
        // ponto 9
        public void DeserializeListaDadosPais(string jsonString)
        {
            NotificaCalculosDadosPais(this, new EventArgs()); // Ponto 10
        }

        //Ponto 11
        public void PreencheListaDadosPais(ref List<DadosPais> lista)
        {
            lista = this.listaDadosPais;
            NotificaDadosPaisPreenchidos(this, new EventArgs());  //Ponto 12
        }
    }
}
