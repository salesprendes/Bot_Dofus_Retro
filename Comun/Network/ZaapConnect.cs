using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Bot_Dofus_Retro.Comun.Network
{
    public class ZaapConnect
    {
        public static async Task<string> get_ApiKey(string login, string password)
        {
            WinHttpHandler handler = new WinHttpHandler();

            using (HttpClient cliente_web = new HttpClient(handler))
            {
                HttpRequestMessage req = new HttpRequestMessage
                {
                    RequestUri = new Uri("https://haapi.ankama.com/json/Ankama/v5/Api/CreateApiKey"),
                    Method = HttpMethod.Post,
                    Headers =
                    {
                        { "user-agent", "Zaap 3.7.4" }
                    },
                    Content = new StringContent($"login={login}&password={password}", Encoding.UTF8, "text/plain")
                };
                HttpResponseMessage respuesta = await cliente_web.SendAsync(req);

                if(respuesta.StatusCode == HttpStatusCode.OK)
                {
                    Dictionary<string, object> get_ApiRespuesta = await JsonSerializer.DeserializeAsync<Dictionary<string, object>>(await respuesta.Content.ReadAsStreamAsync());
                    string key = get_ApiRespuesta?["key"].ToString();
                    return key;
                }

                return null;
            }
        }

        public static async Task<string> get_Token(string apiKey)
        {
            WinHttpHandler handler = new WinHttpHandler();

            using (HttpClient cliente_web = new HttpClient(handler))
            {
                HttpRequestMessage req = new HttpRequestMessage
                {
                    RequestUri = new Uri($"https://haapi.ankama.com/json/Ankama/v5/Account/CreateToken?game=101"),
                    Method = HttpMethod.Get,
                    Headers =
                    {
                        { "apiKey", $"{apiKey}" },
                        { "user-agent", "Zaap 3.7.4" }
                    }
                };
                HttpResponseMessage respuesta = await cliente_web.SendAsync(req);

                if (respuesta.StatusCode == HttpStatusCode.OK)
                {
                    Dictionary<string, object> get_ApiRespuesta = await JsonSerializer.DeserializeAsync<Dictionary<string, object>>(await respuesta.Content.ReadAsStreamAsync());
                    string token = get_ApiRespuesta?["token"].ToString();
                    return token;
                }

                return null;
            }
        }
    }
}
