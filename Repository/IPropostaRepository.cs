using ZurichAPI.Model.Entity;

namespace ZurichAPI.Repository
{
    public interface IPropostaRepository
    {
        public Proposta GetPropostaById(Int64 id);
        public Proposta GetPropostaByCPF(string cpf);
        public List<Proposta> GetPropostasPendentes();
        public Proposta UpdateProposta(Proposta proposta);
        public bool Save(Proposta proposta);
        public bool Remove(Proposta proposta);
    }
}
