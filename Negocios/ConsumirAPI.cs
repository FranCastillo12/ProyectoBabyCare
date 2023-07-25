using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Negocios
{
    public class ConsumirAPI
    {
        public List<Entidades.NombresSignificados> ObtenerNombresSignificados(string letra,int Sexo)
        {
            using (var producto = new HttpClient())
            {
                var task = Task.Run(
                async () => {
                    return await producto.GetAsync($"http://localhost:5041/NombresSignificados/{letra}/{Sexo}");
                });
                    
                HttpResponseMessage message = task.Result;
                List<Entidades.NombresSignificados> lstNombres = new List<Entidades.NombresSignificados>();
                if (message.StatusCode == System.Net.HttpStatusCode.OK)
                {

                    var task2 = Task<string>.Run(
                        async () => {
                            return await message.Content.ReadAsStringAsync();
                        }
                    );
                    string resultstr = task2.Result;
                    List<Entidades.NombresSignificados> lstp = Entidades.NombresSignificados.FromJson(resultstr);
                    lstNombres = lstp;

                }
                return lstNombres;
            }
        }

        public List<Entidades.ConsejosApi> ObtenerConsejos()
        {
            using (var producto = new HttpClient())
            {
                var task = Task.Run(
                async () => {
                    return await producto.GetAsync($"");
                });

                HttpResponseMessage message = task.Result;
                List<Entidades.ConsejosApi> lstConsejos = new List<Entidades.ConsejosApi>();
                if (message.StatusCode == System.Net.HttpStatusCode.OK)
                {

                    var task2 = Task<string>.Run(
                        async () => {
                            return await message.Content.ReadAsStringAsync();
                        }
                    );
                    string resultstr = task2.Result;
                    List<Entidades.ConsejosApi> lstp = Entidades.ConsejosApi.FromJson(resultstr);
                    lstConsejos = lstp;

                }
                return lstConsejos;
            }
        }


    }
}
