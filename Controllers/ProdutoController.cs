using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Produtos.Context;
using Produtos.Entities;


namespace Produtos.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class ProdutoController : ControllerBase
    {
        private readonly ProdutoContext _context;

        public ProdutoController(ProdutoContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult Create(Produto produto)
        {
            _context.Add(produto);
            _context.SaveChanges();
            return Ok(produto);
        }

        [HttpGet("PegarTodos")]
        public IActionResult Todos(){
            var todos = _context.Produtos.ToList();
            return Ok(todos);
        }

        [HttpGet("{id}")]
        public IActionResult ObterPorID(int id){
            var tarefa = _context.Produtos.Find(id);
            if(tarefa == null)
            return NotFound();

            return Ok(tarefa);
            
        }

        [HttpPut("{id}")]
        public IActionResult Atualizar(int id, Produto produto)
        {
             var tarefaBanco = _context.Produtos.Find(id);
            if (tarefaBanco == null)
                return NotFound();
            tarefaBanco.Nome = produto.Nome;
            tarefaBanco.Valor = produto.Valor;
            _context.Produtos.Update(tarefaBanco);
            _context.SaveChanges();
            return Ok(tarefaBanco);
        }

        [HttpDelete("{id}")]
        public IActionResult Deletar(int id){
            var produtoBanco = _context.Produtos.Find(id);
            if(produtoBanco == null)
                return NotFound();

            _context.Produtos.Remove(produtoBanco);
            _context.SaveChanges();
            return NoContent();
        }
        
    }
}