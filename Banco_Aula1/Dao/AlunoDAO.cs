using Banco_Aula1.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banco_Aula1.Dao
{
    class AlunoDAO
    {
        private static Contexto ctx = new Contexto();


        public static bool AdicionarAluno(Aluno a)
        {
            try
            {
                ctx.Alunos.Add(a);
                ctx.SaveChanges();// Add , remover, alterar, tem que chamar isso para confirmar a ação...
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }
        public static Aluno ProcurarAlunoPorId(Aluno a)
        {
            return ctx.Alunos.Find(a.Id);// FInd só faz a procura por um inteiro, só faz a procura pela chave Primária...
            // PODERIA CRIAR UM OBJETO RETORNANDO QUE FICARIA ASSIM....

            //Aluno aluno = ctx.Alunos.Find(a.Id);
        }
        public static bool RemoverAluno(Aluno a)
        {


            try
            {
                ctx.Alunos.Remove(a);
                ctx.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public static bool AlterarAluno(Aluno a)
        {
            try
            {
                ctx.Entry(a).State = EntityState.Modified; //Este comando altera o estado do Objeto, ou coloca o caminho completo ou faz o using
                ctx.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }
        public static List<Aluno> ListarAlunos() 
        {
           return ctx.Alunos.ToList();
           
        }
        public static Aluno ProcurarAlunoProNome(Aluno a)
        {
           return ctx.Alunos.FirstOrDefault(x => x.Nome.Equals(a.Nome));  // se tver mais de um nome igual, ele vai trazer o primeiro nome encontrado  "=> tal que"
           //PARA MOSTRAR TODOS AO INVEZ DO FIRST  USA-SE WHERE E NO LUGAR DO EQUALS USA-SE CONTAINS. E O METODO TEM QUE RETORNA UMA LISTA.
        }
        public static List<Aluno> ProcurarAlunoPorNomeTodos(Aluno a)
        {
            return ctx.Alunos.Where(x => x.Nome.Contains(a.Nome)).ToList();
        }
    }
}
