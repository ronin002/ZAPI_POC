using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ZurichAPI.Model.Entity
{
    public class Proposta
    {

        [Key]
        public Int64 Id { get; set; }
        public int NaoProcessar { get; set; }

        public int EficienciaArea { get; set; }

        public int EficienciaRobo { get; set; }

        public string ArqProposta { get; set; }
        public string ArqOrigem { get; set; }
        public string ArqCSV { get; set; }
        public string NmProponente { get; set; }
        public string NumCPF { get; set; }

        public string DtNascimento { get; set; }
        public string NumCadastro { get; set; }
        public string NmSexo { get; set; }
        public bool ServidorPublico { get; set; }
        public bool ExpPublica { get; set; }
        public string NmPlano { get; set; }
        public string TipoContribuicao { get; set; }
        public string DtAssinatura { get; set; }

        public int idStatusImportArq { get; set; }
        public DateTime DtInicioImportArq { get; set; }
        public DateTime DtFimImportArq { get; set; }
        public string DtAdmissao { get; set; }
        public string DescErroImportArq { get; set; }
        public string NmMaqImportArq { get; set; }
        public int idStatusConsultaProposta { get; set; }
        public DateTime DtInicioConsultaProposta { get; set; }
        public DateTime DtFimConsultaProposta { get; set; }
        public string DescErroConsultaProposta { get; set; }
        public string NmMaqConsultaProposta { get; set; }
        public int idStatusExportacaoCSV { get; set; }
        public DateTime DtInicioExportacaoCSV { get; set; }
        public DateTime DtFimExportacaoCSV { get; set; }
        public string DescErroExportacaoCSV { get; set; }
        public string NmMaqExportacaoCSV { get; set; }
        public int idStatusEnviaEmail { get; set; }
        public DateTime DtInicioEnviaEmail { get; set; }
        public DateTime DtFimEnviaEmail { get; set; }
        public string DescErroErroEnviaEmail { get; set; }
        public string NmMaqEnviaEmail { get; set; }
    }
}
