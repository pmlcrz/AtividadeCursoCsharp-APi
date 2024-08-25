using Microsoft.AspNetCore.Mvc;

namespace GeladeiraAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GeladeiraController : ControllerBase
    {
        private static string[,,] geladeira = new string[3, 2, 4];

        [HttpGet]
        public IActionResult GetAll()
        {
            var itens = new List<string>();
            for (int andar = 0; andar < 3; andar++)
            {
                for (int container = 0; container < 2; container++)
                {
                    for (int posicao = 0; posicao < 4; posicao++)
                    {
                        string item = geladeira[andar, container, posicao];
                        if (!string.IsNullOrEmpty(item))
                        {
                            itens.Add($"Andar {andar}, Container {container}, Posição {posicao}: {item}");
                        }
                    }
                }
            }
            return Ok(itens);
        }

        [HttpGet("{andar}/{container}/{posicao}")]
        public IActionResult GetById(int andar, int container, int posicao)
        {
            string item = geladeira[andar, container, posicao];
            if (!string.IsNullOrEmpty(item))
            {
                return Ok($"Item '{item}' está na posição {posicao} do container {container} no andar {andar}.");
            }
            return NotFound("Item não encontrado nessa posição.");
        }

        [HttpPost]
        public IActionResult PostItem(int andar, int container, int posicao, string item)
        {
            if (string.IsNullOrEmpty(geladeira[andar, container, posicao]))
            {
                geladeira[andar, container, posicao] = item;
                return Ok($"Item '{item}' adicionado na posição {posicao} do container {container} no andar {andar}.");
            }
            return BadRequest("Posição já ocupada.");
        }

        [HttpPut("{andar}/{container}/{posicao}")]
        public IActionResult PutItem(int andar, int container, int posicao, string item)
        {
            geladeira[andar, container, posicao] = item;
            return Ok($"Item na posição {posicao} do container {container} no andar {andar} foi atualizado para '{item}'.");
        }

        [HttpDelete("{andar}/{container}/{posicao}")]
        public IActionResult DeleteItem(int andar, int container, int posicao)
        {
            if (!string.IsNullOrEmpty(geladeira[andar, container, posicao]))
            {
                geladeira[andar, container, posicao] = null;
                return Ok($"Item removido da posição {posicao} do container {container} no andar {andar}.");
            }
            return NotFound("Item não encontrado nessa posição.");
        }
    }
}
