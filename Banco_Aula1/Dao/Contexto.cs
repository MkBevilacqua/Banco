using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Banco_Aula1.Model;

namespace Banco_Aula1.Dao
{
    class Contexto : DbContext // Responsável por habilitar todos os comandos do banco...
    {
        public DbSet<Aluno> Alunos { get; set; } //DBset , faz com que a classe vire uma tabela...
    }
}
