using Application.Desafio.Easynvest.Options;

namespace Desafio.Easynvest.WebApi.Options
{
    public class ApplicationOptions
    {
		public string Titulo { get; set; }
		public string Versao { get; set; }
		public string Descricao { get; set; }
		public ServicesOptions Services { get; set; }
		public PoliciesOptions Policies { get; set; }
		public CacheOptions Cache { get; set; }
	}
}
