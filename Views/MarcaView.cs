﻿/*
 * @file MarcaView.cs
 * @author Marcos Vasconcelos (a18568@alunos.ipca.pt)
 * @author Diogo Oliveira (a20468@alunos.ipca.pt)
 * @brief Classe MarcaView para visualizar o menu que permite adicionar, listar, atualizar e remover marcas, ao utilizar o controller associado
 * @date dezembro 2023
 * 
 * @copyright Copyright (c) 2023
 * 
 */

using Controllers;
using Models;

namespace Views
{
    public class MarcaView
    {
        #region Attributes

        private MarcaController marcaController;

        #endregion

        #region Methods

        #region Constructor

        /// <summary>
        /// Construtor da classe MarcaView
        /// Inicializa uma nova instância de classe associando-a ao controller
        /// Carrega as marcas a partir do ficheiro binário
        /// </summary>
        /// <param name="controller"></param>
        public MarcaView(MarcaController controller)
        {
            marcaController = controller;
            marcaController.CarregarMarcasBin("marcas.bin");
        }

        #endregion

        #region Menu Marca

        /// <summary>
        /// Método para mostrar o menu de marcas
        /// </summary>
        public void MenuMarca()
        {
            int op;
            do
            {
                Console.WriteLine("========== Marcas ==========");
                Console.WriteLine("1. Adicionar marca");
                Console.WriteLine("2. Ver marcas");
                Console.WriteLine("3. Atualizar marca");
                Console.WriteLine("4. Remover marca");
                Console.WriteLine("5. Voltar");
                Console.Write("Escolha uma opção: ");

                if (int.TryParse(Console.ReadLine(), out op))
                {
                    Opcao(op);
                }
                else
                {
                    Console.WriteLine("Opção inválida");
                }
            } while (op != 5);
        }

        /// <summary>
        /// Método para lidar com a opção selecionada no menu de marcas
        /// </summary>
        /// <param name="op"></param>
        private void Opcao(int op)
        {
            switch (op)
            {
                case 1:
                    Console.Clear();
                    AdicionarMarcaView();
                    marcaController.GuardarMarcasBin("marcas.bin");
                    marcaController.GuardarMarcasJSON("marcas.json");
                    break;
                case 2:
                    Console.Clear();
                    VerMarcasView();
                    break;
                case 3:
                    Console.Clear();
                    AtualizarMarcaView();
                    marcaController.GuardarMarcasBin("marcas.bin");
                    marcaController.GuardarMarcasJSON("marcas.json");
                    break;
                case 4:
                    Console.Clear();
                    RemoverMarcaView();
                    marcaController.GuardarMarcasBin("marcas.bin");
                    marcaController.GuardarMarcasJSON("marcas.json");
                    break;
                case 5:
                    Console.Clear();
                    break;
                default:
                    Console.WriteLine("Opção inválida");
                    break;
            }
        }

        #endregion

        #region Other Methods

        /// <summary>
        /// Método para adicionar uma nova marca
        /// </summary>
        private void AdicionarMarcaView()
        {
            Console.WriteLine("Insira o ID da marca: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("Insira o nome da marca: ");
                string nome = Console.ReadLine();

                Marca novaMarca = new Marca(id, nome);

                if (marcaController.AdicionarMarcaController(novaMarca))
                {
                    Console.WriteLine("Marca adicionada com sucesso");
                }
                else
                {
                    Console.WriteLine("Marca já existente ou ID duplicado");
                }
            }
            else
            {
                Console.WriteLine("ID inválido");
            }
        }

        /// <summary>
        /// Método para listar as marcas existentes
        /// </summary>
        private void VerMarcasView()
        {
            List<Marca> marcas = marcaController.ListarMarcasController();

            Console.WriteLine("Lista de marcas:\n");

            if (marcas.Count == 0)
            {
                Console.WriteLine("Não existe nenhuma marca");
            }
            else
            {
                foreach (Marca marca in marcas)
                {
                    Console.WriteLine($"Marca #{marca.IdMarca}\nNome: {marca.Nome}\n");
                }
            }
            Console.WriteLine();
        }

        /// <summary>
        /// Método para atualizar uma marca
        /// </summary>
        private void AtualizarMarcaView()
        {
            Console.WriteLine("Insira o ID da marca para atualizar: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                Marca marcaExistente = marcaController.EncontraMarcaPorId(id);

                if (marcaExistente != null)
                {
                    Console.WriteLine("Insira o novo nome da marca: ");
                    string novoNome = Console.ReadLine();

                    Marca marcaAtualizada = new Marca(id, novoNome);

                    if (marcaController.AtualizarMarcaController(marcaAtualizada))
                    {
                        Console.WriteLine("Marca atualizada com sucesso");
                    }
                    else
                    {
                        Console.WriteLine("Marca já existente");
                    }
                }
                else
                {
                    Console.WriteLine("Marca não encontrada");
                }
            }
            else
            {
                Console.WriteLine("ID inválido");
            }
        }

        /// <summary>
        /// Método para remover uma marca
        /// </summary>
        private void RemoverMarcaView()
        {
            Console.Write("Insira o ID da marca que deseja excluir: ");
            int id = int.Parse(Console.ReadLine());

            Marca marcaExistente = marcaController.EncontraMarcaPorId(id);

            if (marcaExistente != null)
            {
                marcaController.RemoverMarcaController(id);
                Console.WriteLine("Marca removida com sucesso");
            }
            else
            {
                Console.WriteLine("Marca não encontrada.");
            }
        }

        #endregion

        #endregion
    }
}
