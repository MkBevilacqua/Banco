using Banco_Aula1.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Banco_Aula1.Dao;

namespace Banco_Aula1
{
    class Program
    {
        static void Main(string[] args)
        {
            Aluno a = new Aluno();
            bool sair = false;
            do
            {
                string teste;
                Console.Clear();
                Console.WriteLine("1- Gravar Aluno.");
                Console.WriteLine("2- Procurar pelo id.");
                Console.WriteLine("3- Remover Aluno.");
                Console.WriteLine("4- Alterar Aluno.");
                Console.WriteLine("5- Listar todos os alunos.");
                Console.WriteLine("6-  Mostrar Apenas um nome ");
                Console.WriteLine("7-  Mostrar todos os nomes iguais.");
                Console.WriteLine("8- Sair.");
                Console.WriteLine("Digite uma opção:");
                int op = int.Parse(Console.ReadLine());

                switch (op)
                {
                    case 1:
                        a = new Aluno();
                        Console.WriteLine("Informe Nome:");
                        a.Nome = Console.ReadLine();
                        Console.WriteLine("Informe o número de matrícula:");
                        a.Matricula = Console.ReadLine();
                        Console.WriteLine("Informe o curso:");
                        a.Curso = Console.ReadLine();

                        if (AlunoDAO.AdicionarAluno(a))
                        {
                            Console.WriteLine("Cadastro Realizado com sucesso!");
                        }
                        else
                        {
                            Console.WriteLine("Não foi possível efetuar o cadastro...");
                        }
                        break;
                    case 2:
                        Console.Clear();
                        a = new Aluno();
                        Console.WriteLine("Digite o Id do registro:");
                        a.Id = int.Parse(Console.ReadLine());

                        a = AlunoDAO.ProcurarAlunoPorId(a);
                        if (a != null)
                        {
                            Console.WriteLine("Nome: " + a.Nome + " Matricula: " + a.Matricula + " Curso: " + a.Curso + " Id: " + a.Id);
                        }
                        else
                        {
                            Console.WriteLine("Aluno não encontrado!!!");
                        }
                        break;
                    case 3:
                        Console.Clear();
                        a = new Aluno();
                        Console.WriteLine("informe o Id a ser REMOVIDO:");
                        a.Id = int.Parse(Console.ReadLine());

                        a = AlunoDAO.ProcurarAlunoPorId(a);
                        if (a != null)
                        {
                            Console.WriteLine("Nome: " + a.Nome + " Matricula: " + a.Matricula + " Curso: " + a.Curso + " Id: " + a.Id);
                            Console.WriteLine("\nTem certeza que deseja Excluir este Registro?(S/N)");
                            string pg = Console.ReadLine();
                            if (pg.Equals("S") || pg.Equals("s"))
                            {
                                if (AlunoDAO.RemoverAluno(a))
                                {
                                    Console.WriteLine("Remoção realizada com sucesso...");
                                }
                                else
                                {
                                    Console.WriteLine("Erro ao realizar exclusão no banco...");
                                }
                            }
                        }
                        else
                        {
                            Console.WriteLine("Aluno não Removido pela sua escolha!!!");
                        }


                        break;
                    case 4:
                        Console.Clear();
                        a = new Aluno();
                        Console.WriteLine("informe o Id a ser REMOVIDO:");
                        a.Id = int.Parse(Console.ReadLine());

                        a = AlunoDAO.ProcurarAlunoPorId(a);
                        if (a != null)
                        {
                            Console.WriteLine("Nome: " + a.Nome + " Matricula: " + a.Matricula + " Curso: " + a.Curso + " Id: " + a.Id);
                            Console.WriteLine("\nDeseja fazer alguma alteração?(S/N)");
                            string pgalt = Console.ReadLine();
                            if (pgalt.Equals("S") || pgalt.Equals("s"))
                            {
                                Console.WriteLine("Informe Nome:");
                                a.Nome = Console.ReadLine();
                                Console.WriteLine("Informe o número de matrícula:");
                                a.Matricula = Console.ReadLine();
                                Console.WriteLine("Informe o curso:");
                                a.Curso = Console.ReadLine();
                                if (AlunoDAO.AlterarAluno(a))
                                {
                                    Console.WriteLine("Alteração realizada com sucesso...");
                                }
                                else
                                {
                                    Console.WriteLine("Erro ao realizar exclusão no banco...");
                                }
                            }
                        }
                        else
                        {
                            Console.WriteLine("Aluno não Removido pela sua escolha!!!");
                        }


                        break;
                    case 5:
                        List<Aluno> lista = AlunoDAO.ListarAlunos();
                        if (lista.Count > 0)
                        {
                            foreach (Aluno aluno in lista)
                            {
                                Console.WriteLine("Nome: " + aluno.Nome);
                            }
                        }
                        else
                        {
                            Console.WriteLine("Não há registros!");
                        }
                        break;
                    case 6:
                        a = new Aluno();
                        Console.WriteLine("Informe o Nome:");
                        a.Nome = Console.ReadLine();
                        a = AlunoDAO.ProcurarAlunoProNome(a);

                        if (a != null)
                        {
                            Console.WriteLine("Nome: " + a.Nome + " Matricula: " + a.Matricula + " Curso: " + a.Curso);
                        }
                        else
                        {
                            Console.WriteLine("Não há registro!");
                        }
                        break;
                    case 7:
                        a = new Aluno();
                        Console.WriteLine("Informe o Nome:");
                        a.Nome = Console.ReadLine();

                        List<Aluno> nomes = new List<Aluno>();
                        nomes = AlunoDAO.ProcurarAlunoPorNomeTodos(a);
                        if (nomes.Count > 0)
                        {
                            foreach (Aluno alunos in nomes)
                            {
                                Console.WriteLine("Nome: " + alunos.Nome + " Matricula: " + alunos.Matricula + " Curso: " + alunos.Curso);
                            }
                        } else
                        {
                            Console.WriteLine("Não há registro!");
                        }
                        break;
                    case 8:
                        Console.WriteLine("Saindo...");
                        sair = true;
                        break;


                    default:
                        break;
                }
                Console.ReadKey();
            } while (sair == false);
        }
    }
}
