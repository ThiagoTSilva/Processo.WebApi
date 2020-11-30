namespace Processo.WebApi.Model
{
    public class Beneficio
    {
        public int Id { get; set; }
        public string DescricaoTipoBeneficio { get; set; }
        public Beneficiario Beneficiario { get; set; }
    }
}
