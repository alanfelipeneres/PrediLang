using PrediLang.Api.Utils;

namespace PrediLang.Api.Request
{
    public class RespostaBuscaPaginadaRequest : RequestPaged<RespostaBuscaPaginadaRequest>
    {
        public int idResposta { get; set; }
        public int idTemplate { get; set; }
        public string descricao { get; set; }
        public string usuario { get; set; }
        public string dataRegistro { get; set; }
    }
}
