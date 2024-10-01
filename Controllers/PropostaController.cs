using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ZurichAPI.Model.Dto;
using ZurichAPI.Model.Entity;
using ZurichAPI.Repository;
using ZurichAPI.Utils;

namespace ZurichAPI.Controllers
{
    [ApiController]
    public class PropostaController : BaseController
    {
        private readonly ILogger<PropostaController> _logger;


        public PropostaController(ILogger<PropostaController> logger,
                                IUserRepository userRepository,
                                IRoleRepository roleRepository) : base( userRepository,
                                                                        roleRepository)
        {
            _logger = logger;
        }

        [HttpGet("api/v1/proposta/cpf")]
        public Proposta GetPropostaByCPF([FromBody] GetPropostaByCpfDto getPropostaByCpfDto)
        {
            return new Proposta();
        }

        [HttpGet("api/v1/proposta/")]
        public Proposta GetPropostaById([FromBody] GetPropostaByIdDto getPropostaByIdDto)
        {
            return new Proposta();
        }

        [HttpGet("api/v1/proposta/pendentes")]
        public List<Proposta> GetPropostasPendentes()
        {
            return new List<Proposta>();
        }

        [HttpDelete("api/v1/proposta")]
        public bool Remove([FromBody] GetPropostaByIdDto getPropostaByIdDto)
        {
            return true;
        }

        [HttpPost("api/v1/proposta")]
        public bool Save(Proposta proposta)
        {
            return true;
        }

        [HttpPut("api/v1/proposta")]
        public Proposta UpdateProposta(Proposta proposta)
        {
            return proposta;
        }
    }
}
