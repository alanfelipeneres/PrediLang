using PrediLang.Api.Utils;

namespace PrediLang.Api.Request
{
    public class CenarioBuscarPaginadoRequest : RequestPaged<CenarioBuscarPaginadoRequest>
    {
        public int idCenario { get; set; }
        public int idTemplate { get; set; }
        public string pergunta { get; set; }
        public string usuario { get; set; }
        public string dataRegistro { get; set; }
    }
}
