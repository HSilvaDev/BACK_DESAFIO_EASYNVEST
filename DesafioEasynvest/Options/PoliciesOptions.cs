namespace Desafio.Easynvest.WebApi.Options
{
    public class PoliciesOptions
	{
		public WaitAndRetryConfigOptions WaitAndRetryConfig { get; set; }
	}
	public class WaitAndRetryConfigOptions
	{
		public int Retry { get; set; }
		public int Wait { get; set; }
		public int Timeout { get; set; }
	}
}
